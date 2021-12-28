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

namespace Fatti_di_Carta
{
    public partial class Main : Form
    {
        //Reference to sub forms used by the main one
        private readonly ModalForms.AddBook addBookForm;
        private readonly ModalForms.Scontrino scontrinoForm;
        public Main()
        {
            InitializeComponent();
            //Initialize the various sub forms
            this.addBookForm = new ModalForms.AddBook();
            this.addBookForm.Visible = false;
            this.scontrinoForm = new ModalForms.Scontrino();
            this.scontrinoForm.Visible = false;
            //Set up shown callback to fire on first show
            this.Shown += this.getBaseStats;
            //Set the version number on the label
            this.labelVersion.Text = "v" + Application.ProductVersion;
        }
        /// <summary>
        /// Fetch the stats to show on the main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void getBaseStats(object sender, EventArgs args)
        {
            int i = 0;
            string cs = Config.getConnectionString();
            //Fill the list of queries to perform
            List<String> queries = new List<string>(3);
            queries.Add("SELECT COUNT(*) as nbooks FROM Libri;");
            queries.Add("SELECT COUNT(*) as nauthor FROM Autori;");
            queries.Add("SELECT COUNT(*) as neditor FROM Editori");
            //Fill the array of label
            List<Label> labels = new List<Label>(3);
            labels.Add(this.labelBooks);
            labels.Add(this.labelAuthors);
            labels.Add(this.labelEditors);
            //Perform the connection and the queries
            using(OleDbConnection c = new OleDbConnection(cs))
            {
                try
                {
                    c.Open();
                    foreach (string q in queries)
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        //Setup the command
                        cmd.Connection = c;
                        cmd.CommandText = q;
                        //Execute the query
                        OleDbDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            labels[i].Text = reader[0].ToString();
                        }
                        reader.Close();
                        cmd.Dispose();
                        i++;
                    }
                }
                catch (OleDbException)
                {
                    MessageBox.Show("Impossible comunicare con Access!");
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Operazione di lettura non valida!");
                }
                finally
                {
                    c.Close();
                }
            }
        }
        /// <summary>
        /// Handle the click on the make scontrino button. Open the proper dialog form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scontrinoButton_Click(object sender, EventArgs e)
        {
            this.scontrinoForm.resetForm();
            this.scontrinoForm.ShowDialog();
        }
        /// <summary>
        /// Handle the click on add book button. Open the proper dialog form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBookButton_Click(object sender, EventArgs e)
        {
            this.addBookForm.ShowDialog();
            //Fetch again the stats to stay updated
            this.getBaseStats(sender, e);
        }
    }
}
