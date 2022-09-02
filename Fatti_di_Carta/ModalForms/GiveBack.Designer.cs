namespace Fatti_di_Carta.ModalForms
{
    partial class GiveBack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GiveBack));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.isbnTextBox = new System.Windows.Forms.TextBox();
            this.listBookView = new System.Windows.Forms.ListView();
            this.columnTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.removeItemButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.folderBrowserDialogForCSV = new System.Windows.Forms.FolderBrowserDialog();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.isbnTextBox);
            this.flowLayoutPanel1.Controls.Add(this.listBookView);
            this.flowLayoutPanel1.Controls.Add(this.removeItemButton);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(8);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(654, 357);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // isbnTextBox
            // 
            this.isbnTextBox.Location = new System.Drawing.Point(11, 11);
            this.isbnTextBox.Name = "isbnTextBox";
            this.isbnTextBox.Size = new System.Drawing.Size(631, 20);
            this.isbnTextBox.TabIndex = 0;
            this.isbnTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.isbnTextBox_KeyUp);
            // 
            // listBookView
            // 
            this.listBookView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnTitle,
            this.columnQuantity});
            this.listBookView.FullRowSelect = true;
            this.listBookView.GridLines = true;
            this.listBookView.HideSelection = false;
            this.listBookView.Location = new System.Drawing.Point(11, 37);
            this.listBookView.Name = "listBookView";
            this.listBookView.Size = new System.Drawing.Size(631, 279);
            this.listBookView.TabIndex = 1;
            this.listBookView.UseCompatibleStateImageBehavior = false;
            this.listBookView.View = System.Windows.Forms.View.Details;
            // 
            // columnTitle
            // 
            this.columnTitle.Text = "Titolo";
            this.columnTitle.Width = 527;
            // 
            // columnQuantity
            // 
            this.columnQuantity.Text = "Quantità";
            this.columnQuantity.Width = 90;
            // 
            // removeItemButton
            // 
            this.removeItemButton.Location = new System.Drawing.Point(11, 322);
            this.removeItemButton.Name = "removeItemButton";
            this.removeItemButton.Size = new System.Drawing.Size(127, 23);
            this.removeItemButton.TabIndex = 2;
            this.removeItemButton.Text = "Rimuovi selezionato";
            this.removeItemButton.UseVisualStyleBackColor = true;
            this.removeItemButton.Click += new System.EventHandler(this.removeItemButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.reportCheckBox);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.confirmButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 363);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(654, 82);
            this.panel1.TabIndex = 1;
            // 
            // reportCheckBox
            // 
            this.reportCheckBox.AutoSize = true;
            this.reportCheckBox.Checked = true;
            this.reportCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.reportCheckBox.Location = new System.Drawing.Point(12, 35);
            this.reportCheckBox.Name = "reportCheckBox";
            this.reportCheckBox.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.reportCheckBox.Size = new System.Drawing.Size(102, 17);
            this.reportCheckBox.TabIndex = 2;
            this.reportCheckBox.Text = "Genera Report";
            this.reportCheckBox.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(430, 26);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(97, 32);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Annulla";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(545, 26);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(97, 32);
            this.confirmButton.TabIndex = 0;
            this.confirmButton.Text = "Conferma Reso";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // folderBrowserDialogForCSV
            // 
            this.folderBrowserDialogForCSV.Description = "Dove devo salvare il report?";
            // 
            // GiveBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 445);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GiveBack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fai un Reso";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox isbnTextBox;
        private System.Windows.Forms.ListView listBookView;
        private System.Windows.Forms.ColumnHeader columnTitle;
        private System.Windows.Forms.ColumnHeader columnQuantity;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button removeItemButton;
        private System.Windows.Forms.CheckBox reportCheckBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogForCSV;
    }
}