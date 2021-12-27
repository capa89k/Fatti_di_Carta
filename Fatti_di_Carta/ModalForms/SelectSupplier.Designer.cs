namespace Fatti_di_Carta.ModalForms
{
    partial class SelectSupplier
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectSupplier));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.searchSupplierLabel = new System.Windows.Forms.Label();
            this.searchSupplierTextBox = new System.Windows.Forms.TextBox();
            this.supplierGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipocontrattoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rendicontazioneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scontoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fornitoriBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.databaseDataSet = new Fatti_di_Carta.databaseDataSet();
            this.fornitoriTableAdapter = new Fatti_di_Carta.databaseDataSetTableAdapters.FornitoriTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplierGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornitoriBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.searchSupplierLabel);
            this.flowLayoutPanel1.Controls.Add(this.searchSupplierTextBox);
            this.flowLayoutPanel1.Controls.Add(this.supplierGridView);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(8);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(600, 294);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // searchSupplierLabel
            // 
            this.searchSupplierLabel.AutoSize = true;
            this.searchSupplierLabel.Location = new System.Drawing.Point(11, 8);
            this.searchSupplierLabel.Name = "searchSupplierLabel";
            this.searchSupplierLabel.Size = new System.Drawing.Size(79, 13);
            this.searchSupplierLabel.TabIndex = 0;
            this.searchSupplierLabel.Text = "Cerca Fornitore";
            // 
            // searchSupplierTextBox
            // 
            this.searchSupplierTextBox.Location = new System.Drawing.Point(11, 24);
            this.searchSupplierTextBox.Name = "searchSupplierTextBox";
            this.searchSupplierTextBox.Size = new System.Drawing.Size(577, 20);
            this.searchSupplierTextBox.TabIndex = 1;
            this.searchSupplierTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchSupplierTextBox_KeyUp);
            // 
            // supplierGridView
            // 
            this.supplierGridView.AllowUserToAddRows = false;
            this.supplierGridView.AllowUserToDeleteRows = false;
            this.supplierGridView.AutoGenerateColumns = false;
            this.supplierGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplierGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nomeDataGridViewTextBoxColumn,
            this.tipocontrattoDataGridViewTextBoxColumn,
            this.rendicontazioneDataGridViewTextBoxColumn,
            this.scontoDataGridViewTextBoxColumn,
            this.noteDataGridViewTextBoxColumn});
            this.supplierGridView.DataSource = this.fornitoriBindingSource;
            this.supplierGridView.Location = new System.Drawing.Point(11, 50);
            this.supplierGridView.MultiSelect = false;
            this.supplierGridView.Name = "supplierGridView";
            this.supplierGridView.ReadOnly = true;
            this.supplierGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.supplierGridView.Size = new System.Drawing.Size(577, 233);
            this.supplierGridView.TabIndex = 2;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 80;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipocontrattoDataGridViewTextBoxColumn
            // 
            this.tipocontrattoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tipocontrattoDataGridViewTextBoxColumn.DataPropertyName = "tipo_contratto";
            this.tipocontrattoDataGridViewTextBoxColumn.HeaderText = "Tipo Contratto";
            this.tipocontrattoDataGridViewTextBoxColumn.Name = "tipocontrattoDataGridViewTextBoxColumn";
            this.tipocontrattoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rendicontazioneDataGridViewTextBoxColumn
            // 
            this.rendicontazioneDataGridViewTextBoxColumn.DataPropertyName = "rendicontazione";
            this.rendicontazioneDataGridViewTextBoxColumn.HeaderText = "rendicontazione";
            this.rendicontazioneDataGridViewTextBoxColumn.Name = "rendicontazioneDataGridViewTextBoxColumn";
            this.rendicontazioneDataGridViewTextBoxColumn.ReadOnly = true;
            this.rendicontazioneDataGridViewTextBoxColumn.Visible = false;
            // 
            // scontoDataGridViewTextBoxColumn
            // 
            this.scontoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.scontoDataGridViewTextBoxColumn.DataPropertyName = "sconto";
            this.scontoDataGridViewTextBoxColumn.HeaderText = "Sconto";
            this.scontoDataGridViewTextBoxColumn.Name = "scontoDataGridViewTextBoxColumn";
            this.scontoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // noteDataGridViewTextBoxColumn
            // 
            this.noteDataGridViewTextBoxColumn.DataPropertyName = "note";
            this.noteDataGridViewTextBoxColumn.HeaderText = "note";
            this.noteDataGridViewTextBoxColumn.Name = "noteDataGridViewTextBoxColumn";
            this.noteDataGridViewTextBoxColumn.ReadOnly = true;
            this.noteDataGridViewTextBoxColumn.Visible = false;
            // 
            // fornitoriBindingSource
            // 
            this.fornitoriBindingSource.DataMember = "Fornitori";
            this.fornitoriBindingSource.DataSource = this.databaseDataSet;
            // 
            // databaseDataSet
            // 
            this.databaseDataSet.DataSetName = "databaseDataSet";
            this.databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fornitoriTableAdapter
            // 
            this.fornitoriTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.confirmButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 317);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 49);
            this.panel1.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(386, 11);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(92, 26);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Annulla";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(496, 11);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(92, 26);
            this.confirmButton.TabIndex = 0;
            this.confirmButton.Text = "Conferma";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // SelectSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SelectSupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scegli Fornitore";
            this.Load += new System.EventHandler(this.SelectSupplier_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplierGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornitoriBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private databaseDataSet databaseDataSet;
        private System.Windows.Forms.BindingSource fornitoriBindingSource;
        private databaseDataSetTableAdapters.FornitoriTableAdapter fornitoriTableAdapter;
        private System.Windows.Forms.Label searchSupplierLabel;
        private System.Windows.Forms.TextBox searchSupplierTextBox;
        private System.Windows.Forms.DataGridView supplierGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipocontrattoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rendicontazioneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scontoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteDataGridViewTextBoxColumn;
    }
}