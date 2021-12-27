using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fatti_di_Carta.ModalForms
{
    public partial class SelectSupplier : Form
    {
        private AddBook parent;
        public SelectSupplier(AddBook parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void SelectSupplier_Load(object sender, EventArgs e)
        {
            // TODO: questa riga di codice carica i dati nella tabella 'databaseDataSet.Fornitori'. È possibile spostarla o rimuoverla se necessario.
            this.fornitoriTableAdapter.Fill(this.databaseDataSet.Fornitori);

        }
        /// <summary>
        /// Simply close this form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// On enter press we update the filter of the binding source in order to search the supplier.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchSupplierTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string searchText = ((TextBox)sender).Text;
                this.fornitoriBindingSource.Filter = "nome like '%" + searchText + "%'";
                e.Handled = true;
            }
        }
        /// <summary>
        /// We set the value into the book model and close the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmButton_Click(object sender, EventArgs e)
        {
            int id = (int)this.supplierGridView.SelectedRows[0].Cells[0].Value;
            string supplierName = this.supplierGridView.SelectedRows[0].Cells[1].Value.ToString();
            this.parent.setSupplier(id, supplierName);
            this.Close();
        }
    }
}
