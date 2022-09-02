using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Fatti_di_Carta.Utility
{
    class Receipt
    {
        private Dictionary<int, int> items;
        /// <summary>
        /// Constructor for the receipt.
        /// </summary>
        public Receipt()
        {
            this.items = new Dictionary<int, int>();
        }
        /// <summary>
        /// Add an item to the receipt.
        /// </summary>
        /// <param name="item"></param>
        public void addItem(Book book)
        {
            if (this.items.ContainsKey(book.Id))
            {
                this.items[book.Id]++;
            }
            else
            {
                this.items.Add(book.Id, 1);
            }
        }
        /// <summary>
        /// Save the receipt into the DB.
        /// </summary>
        /// <param name="connection">A opened connection with Access</param>
        /// <returns></returns>
        public bool save(OleDbConnection connection)
        {
            bool result = false;
            //Save the recipt entry into Scontrini
            int id = this.saveReceipt(connection);
            if (id != -1)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                try
                {
                    //Now loop over the books and add the many-to-many entries
                    foreach (KeyValuePair<int, int> item in this.items)
                    {
                        cmd.CommandText =
                            "INSERT INTO LibriScontrini (id_libro, id_scontrino, quantita)" +
                            "VALUES (@id_libro, @id_scontrino, @quantita);";
                        cmd.Parameters.AddWithValue("@id_libro", item.Key);
                        cmd.Parameters.AddWithValue("@id_scontrino", id);
                        cmd.Parameters.AddWithValue("@quantita", item.Value);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    result = true;
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Lo scontrino non è stato salvato correttamente!");
                }
                finally
                {
                    cmd.Dispose();
                }
            }
            return result;
        }
        /// <summary>
        /// Save the receipt entry into the Scontrini table.
        /// </summary>
        /// <param name="connection">An active connection with Access</param>
        /// <returns></returns>
        private int saveReceipt(OleDbConnection connection)
        {
            int id;
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO Scontrini (data) values (@date);";
            cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);
            try
            {
                cmd.ExecuteNonQuery();
                //Get the ID of the receipt
                cmd.CommandText = "SELECT @@Identity;";
                id = (int)cmd.ExecuteScalar();
            }
            catch (InvalidOperationException)
            {
                id = -1;
            }
            finally
            {
                cmd.Dispose();
            }
            return id;
        }
    }
}
