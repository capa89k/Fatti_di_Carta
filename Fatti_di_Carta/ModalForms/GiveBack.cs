using System;
using System.Windows.Forms;
using System.Text;
using System.Data.OleDb;
using System.IO;

namespace Fatti_di_Carta.ModalForms
{
    public partial class GiveBack : Form
    {
        public GiveBack()
        {
            InitializeComponent();
        }
        /// <summary>
        /// On ISBN enter we fetch the book and add it to the give back list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void isbnTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Utility.Book book;
                //Get the ISBN from the text field and find the book 
                string isbn = ((TextBox)sender).Text;
                try
                {
                    book = Utility.Book.FindByISBN(isbn);
                    if(book == null)
                    {
                        MessageBox.Show("Libro non trovato!");
                    }
                    else
                    {
                        this.updateUIOnBookAdd(book);
                    }
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Non sono riuscito a comunicare con Access!");
                }
                finally
                {
                    e.Handled = true;
                }
            }
        }
        /// <summary>
        /// Update the book listview by adding or updating the book row.
        /// </summary>
        /// <param name="book"></param>
        private void updateUIOnBookAdd(Utility.Book book)
        {
            ListViewItem item;
            int currentQty;
            int index = this.listBookView.Items.IndexOfKey(book.Isbn);
            if (index != -1)
            {
                //Book already in list add one to the quantity
                item = this.listBookView.Items[index];
                currentQty = int.Parse(item.SubItems[1].Text);
                //We can not give back more then what we have in store
                if(book.Quantity > currentQty)
                {
                    item.SubItems[1].Text = (currentQty + 1).ToString();
                }
                else
                {
                    MessageBox.Show(String.Format("Non hai altre copie di {0}", book.Title));
                }
            }
            else
            {
                //We check to have some copy of this book in the store
                if(book.Quantity > 0)
                {
                    //Add the book to the list view with quantity set to one
                    item = new ListViewItem(book.Title);
                    item.SubItems.Add("1");
                    item.Name = book.Isbn;
                    item.Tag = book;
                    this.listBookView.Items.Add(item);
                }
                else
                {
                    MessageBox.Show(String.Format("Deposito del libro {0} uguale a zero", book.Title));
                }
            }
            //Reset the ISBN text field
            this.isbnTextBox.Text = "";
        }
        /// <summary>
        /// Remove one quantity of the selected item from the list view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeItemButton_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in this.listBookView.SelectedItems)
            {
                //Parse the quantity of book for the current selection
                int q = int.Parse(item.SubItems[1].Text);
                if(q == 1)
                {
                    //No more book we can remove the item from the selected
                    this.listBookView.Items.RemoveByKey(item.Name);
                }
                else
                {
                    //We should subtract book quantity by one
                    q--;
                    item.SubItems[1].Text = q.ToString();
                }
            }
        }
        /// <summary>
        /// On cancel click we should close the modal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.listBookView.Items.Clear();
            this.Close();
        }
        /// <summary>
        /// Remove the given quantity for each book in the list and create a report.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmButton_Click(object sender, EventArgs e)
        {
            int r = 0;
            //The connection string is required to actually connect
            string cs = Utility.Config.getConnectionString();
            //Check that the list view is not empty
            if(this.listBookView.Items.Count == 0)
            {
                MessageBox.Show("Inserire almeno un libro per il reso.");
                return;
            }
            //using will dispose for me the connection
            using (OleDbConnection connection = new OleDbConnection(cs))
            {
                //Prepare the command object
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                try
                {
                    connection.Open();
                    //Loop over the books and update Access
                    foreach (ListViewItem item in this.listBookView.Items)
                    {
                        int q = int.Parse(item.SubItems[1].Text);
                        Utility.Book current = (Utility.Book)item.Tag;
                        //Prepare the update statement
                        cmd.CommandText = "UPDATE Libri SET deposito=deposito-@dep WHERE id=@id;";
                        cmd.Parameters.AddWithValue("@dep", q);
                        cmd.Parameters.AddWithValue("@id", current.Id);
                        //Perform the update and save the amount of row updated (should be always 1)
                        r += cmd.ExecuteNonQuery();
                        //Clear the params to use the same object on the next book
                        cmd.Parameters.Clear();
                    }
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Impossibile comunicare con Access! Operazione non valida.");
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Errore da Access: " + ex.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                    //Check that all the books has been processed
                    if(r != this.listBookView.Items.Count)
                    {
                        MessageBox.Show("Attenzione ultima riga processata: " + r);
                    }
                    else
                    {
                        if (this.reportCheckBox.Checked)
                        {
                            this.saveGiveBackReport();
                        }
                        MessageBox.Show("Reso completato con successo!");
                        this.listBookView.Items.Clear();
                        this.Close();
                    }
                }
            }
        }
        /// <summary>
        /// Save the give back report using the content of the list view
        /// </summary>
        private void saveGiveBackReport()
        {
            StringBuilder sb = new StringBuilder();
            //Append to the string the header of the csv
            sb.AppendLine("\"Titolo\";\"ISBN\";\"Prezzo\";\"Quantita\"");
            //Loop over the list book view and build the csv
            foreach(ListViewItem item in this.listBookView.Items)
            {
                int q = int.Parse(item.SubItems[1].Text);
                Utility.Book b = (Utility.Book)item.Tag;
                sb.AppendLine(
                    String.Format("\"{0}\";\"{1}\";\"{2}\";\"{3}\"", b.Title, b.Isbn, b.Price, q)
                );
            }
            //Choose where to store the csv report
            if(this.folderBrowserDialogForCSV.ShowDialog() == DialogResult.OK)
            {
                string path = this.folderBrowserDialogForCSV.SelectedPath;
                if (!String.IsNullOrWhiteSpace(path))
                {
                    //File name is the current date time
                    string name = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".csv";
                    //Write the file to the disk on the given path
                    try
                    {
                        File.WriteAllText(path + "\\\\" + name, sb.ToString());
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Impossible salvare il file csv.");
                    }
                }
            }
        }
    }
}
