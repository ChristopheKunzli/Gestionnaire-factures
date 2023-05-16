namespace Bill_Manager
{
    partial class ImportBill
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
            this.txtBillNumber = new System.Windows.Forms.TextBox();
            this.dateDate = new System.Windows.Forms.DateTimePicker();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.txtAmountHT = new System.Windows.Forms.TextBox();
            this.txtAmountTTC = new System.Windows.Forms.TextBox();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.cmbProvider = new System.Windows.Forms.ComboBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.rtxtStorage = new System.Windows.Forms.RichTextBox();
            this.cmdFile = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.lblBillNumber = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.lblAmountHT = new System.Windows.Forms.Label();
            this.lblAmountTTC = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblProvider = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblStorage = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBillNumber
            // 
            this.txtBillNumber.Location = new System.Drawing.Point(12, 30);
            this.txtBillNumber.Name = "txtBillNumber";
            this.txtBillNumber.Size = new System.Drawing.Size(200, 20);
            this.txtBillNumber.TabIndex = 0;
            // 
            // dateDate
            // 
            this.dateDate.Location = new System.Drawing.Point(13, 80);
            this.dateDate.Name = "dateDate";
            this.dateDate.Size = new System.Drawing.Size(218, 20);
            this.dateDate.TabIndex = 1;
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(13, 134);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(121, 21);
            this.cmbCurrency.TabIndex = 2;
            // 
            // txtAmountHT
            // 
            this.txtAmountHT.Location = new System.Drawing.Point(13, 186);
            this.txtAmountHT.Name = "txtAmountHT";
            this.txtAmountHT.Size = new System.Drawing.Size(200, 20);
            this.txtAmountHT.TabIndex = 3;
            // 
            // txtAmountTTC
            // 
            this.txtAmountTTC.Location = new System.Drawing.Point(13, 241);
            this.txtAmountTTC.Name = "txtAmountTTC";
            this.txtAmountTTC.Size = new System.Drawing.Size(200, 20);
            this.txtAmountTTC.TabIndex = 4;
            // 
            // cmbUser
            // 
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(13, 336);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(200, 21);
            this.cmbUser.TabIndex = 5;
            // 
            // cmbProvider
            // 
            this.cmbProvider.FormattingEnabled = true;
            this.cmbProvider.Location = new System.Drawing.Point(264, 336);
            this.cmbProvider.Name = "cmbProvider";
            this.cmbProvider.Size = new System.Drawing.Size(200, 21);
            this.cmbProvider.TabIndex = 6;
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(527, 336);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(200, 21);
            this.cmbType.TabIndex = 7;
            // 
            // rtxtStorage
            // 
            this.rtxtStorage.Location = new System.Drawing.Point(279, 30);
            this.rtxtStorage.MaxLength = 500;
            this.rtxtStorage.Name = "rtxtStorage";
            this.rtxtStorage.Size = new System.Drawing.Size(448, 179);
            this.rtxtStorage.TabIndex = 8;
            this.rtxtStorage.Text = "";
            // 
            // cmdFile
            // 
            this.cmdFile.Location = new System.Drawing.Point(280, 241);
            this.cmdFile.Name = "cmdFile";
            this.cmdFile.Size = new System.Drawing.Size(132, 23);
            this.cmdFile.TabIndex = 9;
            this.cmdFile.Text = "Sélectionner fichier*";
            this.cmdFile.UseVisualStyleBackColor = true;
            this.cmdFile.Click += new System.EventHandler(this.cmdFile_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(13, 407);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(132, 23);
            this.cmdAdd.TabIndex = 10;
            this.cmdAdd.Text = "Ajouter facture";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(595, 407);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(132, 23);
            this.cmdCancel.TabIndex = 11;
            this.cmdCancel.Text = "Annuler";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // lblBillNumber
            // 
            this.lblBillNumber.AutoSize = true;
            this.lblBillNumber.Location = new System.Drawing.Point(13, 13);
            this.lblBillNumber.Name = "lblBillNumber";
            this.lblBillNumber.Size = new System.Drawing.Size(99, 13);
            this.lblBillNumber.TabIndex = 12;
            this.lblBillNumber.Text = "Numéro de facture*";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(13, 64);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 13;
            this.lblDate.Text = "Date";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(13, 115);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(44, 13);
            this.lblCurrency.TabIndex = 14;
            this.lblCurrency.Text = "Devise*";
            // 
            // lblAmountHT
            // 
            this.lblAmountHT.AutoSize = true;
            this.lblAmountHT.Location = new System.Drawing.Point(13, 170);
            this.lblAmountHT.Name = "lblAmountHT";
            this.lblAmountHT.Size = new System.Drawing.Size(68, 13);
            this.lblAmountHT.TabIndex = 15;
            this.lblAmountHT.Text = "Montant HT*";
            // 
            // lblAmountTTC
            // 
            this.lblAmountTTC.AutoSize = true;
            this.lblAmountTTC.Location = new System.Drawing.Point(13, 222);
            this.lblAmountTTC.Name = "lblAmountTTC";
            this.lblAmountTTC.Size = new System.Drawing.Size(74, 13);
            this.lblAmountTTC.TabIndex = 16;
            this.lblAmountTTC.Text = "Montant TTC*";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(13, 317);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(58, 13);
            this.lblUser.TabIndex = 17;
            this.lblUser.Text = "Receveur*";
            // 
            // lblProvider
            // 
            this.lblProvider.AutoSize = true;
            this.lblProvider.Location = new System.Drawing.Point(264, 316);
            this.lblProvider.Name = "lblProvider";
            this.lblProvider.Size = new System.Drawing.Size(65, 13);
            this.lblProvider.TabIndex = 18;
            this.lblProvider.Text = "Fournisseur*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(527, 317);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Type de facture*";
            // 
            // lblStorage
            // 
            this.lblStorage.AutoSize = true;
            this.lblStorage.Location = new System.Drawing.Point(279, 13);
            this.lblStorage.Name = "lblStorage";
            this.lblStorage.Size = new System.Drawing.Size(242, 13);
            this.lblStorage.TabIndex = 20;
            this.lblStorage.Text = "Lieu de stockage physique (max 500 charactères)";
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(279, 267);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(87, 13);
            this.lblFile.TabIndex = 21;
            this.lblFile.Text = "Nom du fichier ...";
            // 
            // ImportBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 450);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.lblStorage);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblProvider);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblAmountTTC);
            this.Controls.Add(this.lblAmountHT);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblBillNumber);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cmdFile);
            this.Controls.Add(this.rtxtStorage);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.cmbProvider);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.txtAmountTTC);
            this.Controls.Add(this.txtAmountHT);
            this.Controls.Add(this.cmbCurrency);
            this.Controls.Add(this.dateDate);
            this.Controls.Add(this.txtBillNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ImportBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importer une facture";
            this.Load += new System.EventHandler(this.ImportBill_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBillNumber;
        private System.Windows.Forms.DateTimePicker dateDate;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.TextBox txtAmountHT;
        private System.Windows.Forms.TextBox txtAmountTTC;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.ComboBox cmbProvider;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.RichTextBox rtxtStorage;
        private System.Windows.Forms.Button cmdFile;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label lblBillNumber;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Label lblAmountHT;
        private System.Windows.Forms.Label lblAmountTTC;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblProvider;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblStorage;
        private System.Windows.Forms.Label lblFile;
    }
}