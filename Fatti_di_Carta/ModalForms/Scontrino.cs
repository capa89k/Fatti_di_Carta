using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Fatti_di_Carta.Utility;

namespace Fatti_di_Carta.ModalForms
{
    public partial class Scontrino : Form
    {
        //The totale price for this receipt
        private decimal total;
        public Scontrino()
        {
            InitializeComponent();
            this.total = 0;
        }
        /// <summary>
        /// Reset the form to the initial state.
        /// </summary>
        public void resetForm()
        {
            this.total = 0;
            this.totLabel.Text = "Totale: 0€";
            this.listView.Items.Clear();
        }
        /// <summary>
        /// When hiting enter we should fetch the book, add to the list and update the total.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barCodeTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                //Prepare an object for the receipt line
                ReceiptItem item;
                //Grab the bar code and connect to access
                string isbn = ((TextBox)sender).Text;
                //The connection string is required to actually connect
                string cs = Config.getConnectionString();
                //The using statement will dispose the connection
                using (OleDbConnection connection = new OleDbConnection(cs))
                {
                    try
                    {
                        //The command will the the select query
                        OleDbCommand cmd = new OleDbCommand();
                        //Connecting to access
                        connection.Open();
                        //Set up the command
                        cmd.Connection = connection;
                        cmd.CommandText = "SELECT id, titolo, prezzo, deposito FROM Libri WHERE isbn = @isbn;";
                        cmd.Parameters.AddWithValue("@isbn", isbn);
                        //Perform the query
                        OleDbDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            item = new ReceiptItem(
                                (int)reader[0], reader[1].ToString(), (decimal)reader[2]
                            );
                            //Update the total
                            this.total += item.Price;
                            //Update the UI with the new item
                            this.updateUiOnItemAdd(item);
                        }
                        else
                        {
                            MessageBox.Show("Libro non trovato!");
                        }
                        reader.Close();
                    }
                    catch (OleDbException)
                    {
                        MessageBox.Show("Errore durante la comunicazione con access!");
                    }
                    catch (InvalidOperationException)
                    {
                        MessageBox.Show("Errore durante la comunicazione con access");
                    }
                    finally
                    {
                        e.Handled = true;
                        connection.Close();
                    }
                }
            }
        }
        /// <summary>
        /// Perform the update on the UI when a book is added.
        /// </summary>
        /// <param name="item"></param>
        private void updateUiOnItemAdd(ReceiptItem item)
        {
            //Create a new list view item
            ListViewItem listItem = new ListViewItem(new[] { item.Title, item.Price + " €" });
            //Link the item with the model
            listItem.Tag = item;
            //Add to the list view
            this.listView.Items.Add(listItem);
            //Clean up the text box
            this.isbnTextBox.Text = "";
            //Finally update the total label
            this.totLabel.Text = "Totale: " + this.total + " €";
        }
        /// <summary>
        /// Close and dispose this form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            //The connection string is required to actually connect
            string cs = Config.getConnectionString();
            //The number of line updated
            int r = 0;
            //Create the receipt that will be later stored
            Receipt receipt = new Receipt();
            //using will dispose for me the connection
            using (OleDbConnection connection = new OleDbConnection(cs))
            {
                //Prepare the command object
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                try
                {
                    //Connect with the database
                    connection.Open();
                    //Loop over the items
                    foreach (ListViewItem item in this.listView.Items)
                    {
                        ReceiptItem receiptItem = (ReceiptItem)item.Tag;
                        receipt.addItem(receiptItem);
                        cmd.CommandText = "UPDATE Libri SET deposito=deposito-1 WHERE id=@id;";
                        cmd.Parameters.AddWithValue("@id", receiptItem.Id);
                        r += cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    //Now save the receipt data into the DB
                    if(r > 0)
                    {
                        if (receipt.save(connection))
                        {
                            MessageBox.Show("Scontrino salvatato e deposito aggiornato!");
                        }
                        else
                        {
                            MessageBox.Show("Deposito aggiornato, ma scontrino non salvato!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Inserire almeno un elemento nello scontrino!");
                    }
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Impossible scaricare i libri." + ex.Message);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Impossibile scaricare i libri. Access: operazione non valida.");
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                    //If the number of update is the same of the number of items everything is ok
                    if (r > 0 && r == this.listView.Items.Count)
                    {
                        this.Close();
                    }
                }
            }

        }
    }
}
