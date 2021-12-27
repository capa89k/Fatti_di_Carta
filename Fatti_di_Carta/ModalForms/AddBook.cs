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
using Fatti_di_Carta.databaseDataSetTableAdapters;

namespace Fatti_di_Carta.ModalForms
{
    public partial class AddBook : Form
    {
        private Utility.Book book;
        private LibriTableAdapter libri;
        private SelectAuthor selectAuthorForm;
        private SelectEditor selectEditorForm;
        private SelectSupplier selectSupplierForm;
        public AddBook()
        {
            InitializeComponent();
            this.book = new Utility.Book();
            this.libri = new LibriTableAdapter();
            this.selectAuthorForm = new SelectAuthor(this);
            this.selectEditorForm = new SelectEditor(this);
            this.selectSupplierForm = new SelectSupplier(this);
        }
        /// <summary>
        /// Set the author by updating both the book model and the label.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editorName"></param>
        public void setAuthor(int id, string authorName)
        {
            this.book.IdAuthor = id;
            this.authorLabel.Text = "Autore: " + authorName;
        }
        /// <summary>
        /// Set the editor by updating both the book model and the label.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editorName"></param>
        public void setEditor(int id, string editorName)
        {
            this.book.IdEditor = id;
            this.editorLabel.Text = "Editore: " + editorName;
        }
        /// <summary>
        /// Set the supplier by updating both the book model and the relative label.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="supplierName"></param>
        public void setSupplier(int id, string supplierName)
        {
            this.book.IdSupplier = id;
            this.supplierLabel.Text = "Fornitore: " + supplierName;
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Open the select author form in order to allow the user to choose a different author.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setAuthorButton_Click(object sender, EventArgs e)
        {
            this.selectAuthorForm.ShowDialog();
        }
        /// <summary>
        /// Open the select editor form in order to allow the user to choose a different editor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setEditorButton_Click(object sender, EventArgs e)
        {
            this.selectEditorForm.ShowDialog();
        }
        /// <summary>
        /// Open the select supplier form in order to allow the user to choose a different one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setSupplierButton_Click(object sender, EventArgs e)
        {
            this.selectSupplierForm.ShowDialog();
        }
        /// <summary>
        /// Save the book into the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.updateBook())
            {
                try
                {
                    libri.Insert(
                        this.book.Title,
                        this.book.Price,
                        this.book.Quantity,
                        this.book.Isbn,
                        this.book.NPage,
                        this.book.Year,
                        this.book.IdEditor,
                        this.book.IdAuthor,
                        this.book.IdSupplier);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Si è verificato un errore inaspettato. Operazione Invalida.");
                    return;
                }
                catch (OleDbException)
                {
                    MessageBox.Show("Si è verificato un errore inaspettato. Forse il libro esiste già.");
                    return;
                }
                MessageBox.Show("Libro inserito con successo!");
                this.resetForm();
            }
        }
        /// <summary>
        /// This method is used to update the book model with the provided data.
        /// </summary>
        private bool updateBook()
        {
            try
            {
                this.book.Title = this.titleTextBox.Text;
                this.book.Price = decimal.Parse(this.priceTextBox.Text);
                this.book.Quantity = (short)this.quantityNumericUpDown.Value;
                this.book.Isbn = this.isbnTextBox.Text;
                this.book.NPage = decimal.ToInt32(this.pageNumericUpDown.Value);
                this.book.Year = decimal.ToInt32(this.yearUpDown.Value);
            }
            catch (OverflowException)
            {
                MessageBox.Show("Valori numerici inseriti troppo grandi.");
                return false;
            }
            catch (FormatException)
            {
                MessageBox.Show("Errore nel campo prezzo. Formato non supportato");
                return false;
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message);
                return false;
            }
            //Check the reference to author, editor and supplier
            if(this.book.IdAuthor == -1)
            {
                MessageBox.Show("Impostare l'autore del libro prima di salvare.");
                return false;
            }
            if(this.book.IdEditor == -1)
            {
                MessageBox.Show("Impostare l'editore del libro prima di salvare.");
                return false;
            }
            if(this.book.IdSupplier == -1)
            {
                MessageBox.Show("Impostare il fornitore del libro prima di salvare.");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Reset the fields of this form.
        /// This should be called after a book has been successfully stored.
        /// </summary>
        private void resetForm()
        {
            this.titleTextBox.Text = "";
            this.priceTextBox.Text = "";
            this.isbnTextBox.Text = "";
            this.quantityNumericUpDown.Value = 0;
            this.yearUpDown.Value = 0;
            this.pageNumericUpDown.Value = 0;
        }
    }
}
