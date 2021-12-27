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
    public partial class SelectAuthor : Form
    {
        private AddBook parent;
        public SelectAuthor(AddBook parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        private void AddBook_Load(object sender, EventArgs e)
        {
            this.autoriTableAdapter.Fill(this.databaseDataSet.Autori);
        }
        /// <summary>
        /// When the cancel button is clicked we simply close the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// On search key enter we should filter the displayed data into the data grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string searchText = ((TextBox)sender).Text;
                this.autoriBindingSource.Filter = "nome like '%" + searchText + "%'";
                e.Handled = true;
            }
        }
        /// <summary>
        /// When confirmed we should check the selected author in the list and save the ID.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmButton_Click(object sender, EventArgs e)
        {
            int id = (int)this.dataGridViewAuthor.SelectedRows[0].Cells[0].Value;
            string authorName = this.dataGridViewAuthor.SelectedRows[0].Cells[1].Value.ToString();
            this.parent.setAuthor(id, authorName);
            this.Close();
        }
    }
}
