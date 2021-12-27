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
    public partial class SelectEditor : Form
    {
        private AddBook parent;
        public SelectEditor(AddBook parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void SelectEditor_Load(object sender, EventArgs e)
        {
            // TODO: questa riga di codice carica i dati nella tabella 'databaseDataSet.Editori'. È possibile spostarla o rimuoverla se necessario.
            this.editoriTableAdapter.Fill(this.databaseDataSet.Editori);

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
        /// Store the selected editor into the book reference and close the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmButton_Click(object sender, EventArgs e)
        {
            int id = (int)this.editorGridView.SelectedRows[0].Cells[0].Value;
            string editorName = this.editorGridView.SelectedRows[0].Cells[1].Value.ToString();
            this.parent.setEditor(id, editorName);
            this.Close();
        }
        /// <summary>
        /// When the user hit enter then we should update the filter with the given parameter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchEditorTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchText = ((TextBox)sender).Text;
                this.editoriBindingSource.Filter = "nome like '%" + searchText + "%'";
                e.Handled = true;
            }
        }
    }
}
