namespace Bill_Manager
{
    partial class Viewbill
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
            this.txtNum = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtHT = new System.Windows.Forms.TextBox();
            this.txtTTC = new System.Windows.Forms.TextBox();
            this.rtxtStorage = new System.Windows.Forms.RichTextBox();
            this.lblNum = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblHT = new System.Windows.Forms.Label();
            this.lblTTC = new System.Windows.Forms.Label();
            this.cmdOpenFile = new System.Windows.Forms.Button();
            this.lblStorage = new System.Windows.Forms.Label();
            this.cmdQuit = new System.Windows.Forms.Button();
            this.grpBoxbill = new System.Windows.Forms.GroupBox();
            this.grpBoxbill.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(5, 43);
            this.txtNum.Name = "txtNum";
            this.txtNum.ReadOnly = true;
            this.txtNum.Size = new System.Drawing.Size(202, 20);
            this.txtNum.TabIndex = 0;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(6, 90);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(202, 20);
            this.txtDate.TabIndex = 1;
            // 
            // txtHT
            // 
            this.txtHT.Location = new System.Drawing.Point(257, 42);
            this.txtHT.Name = "txtHT";
            this.txtHT.ReadOnly = true;
            this.txtHT.Size = new System.Drawing.Size(202, 20);
            this.txtHT.TabIndex = 3;
            // 
            // txtTTC
            // 
            this.txtTTC.Location = new System.Drawing.Point(257, 90);
            this.txtTTC.Name = "txtTTC";
            this.txtTTC.ReadOnly = true;
            this.txtTTC.Size = new System.Drawing.Size(202, 20);
            this.txtTTC.TabIndex = 4;
            // 
            // rtxtStorage
            // 
            this.rtxtStorage.Location = new System.Drawing.Point(6, 166);
            this.rtxtStorage.Name = "rtxtStorage";
            this.rtxtStorage.ReadOnly = true;
            this.rtxtStorage.Size = new System.Drawing.Size(456, 254);
            this.rtxtStorage.TabIndex = 5;
            this.rtxtStorage.Text = "";
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Location = new System.Drawing.Point(2, 24);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(95, 13);
            this.lblNum.TabIndex = 6;
            this.lblNum.Text = "Numéro de facture";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(5, 70);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 7;
            this.lblDate.Text = "Date";
            // 
            // lblHT
            // 
            this.lblHT.AutoSize = true;
            this.lblHT.Location = new System.Drawing.Point(257, 24);
            this.lblHT.Name = "lblHT";
            this.lblHT.Size = new System.Drawing.Size(64, 13);
            this.lblHT.TabIndex = 8;
            this.lblHT.Text = "Montant HT";
            // 
            // lblTTC
            // 
            this.lblTTC.AutoSize = true;
            this.lblTTC.Location = new System.Drawing.Point(257, 70);
            this.lblTTC.Name = "lblTTC";
            this.lblTTC.Size = new System.Drawing.Size(70, 13);
            this.lblTTC.TabIndex = 9;
            this.lblTTC.Text = "Montant TTC";
            // 
            // cmdOpenFile
            // 
            this.cmdOpenFile.Location = new System.Drawing.Point(8, 436);
            this.cmdOpenFile.Name = "cmdOpenFile";
            this.cmdOpenFile.Size = new System.Drawing.Size(137, 23);
            this.cmdOpenFile.TabIndex = 1;
            this.cmdOpenFile.Text = "Ouvrir / Imprimer PDF";
            this.cmdOpenFile.UseVisualStyleBackColor = true;
            this.cmdOpenFile.Click += new System.EventHandler(this.cmdOpenFile_Click);
            // 
            // lblStorage
            // 
            this.lblStorage.AutoSize = true;
            this.lblStorage.Location = new System.Drawing.Point(8, 147);
            this.lblStorage.Name = "lblStorage";
            this.lblStorage.Size = new System.Drawing.Size(134, 13);
            this.lblStorage.TabIndex = 10;
            this.lblStorage.Text = "Lieu de stockage physique";
            // 
            // cmdQuit
            // 
            this.cmdQuit.Location = new System.Drawing.Point(322, 436);
            this.cmdQuit.Name = "cmdQuit";
            this.cmdQuit.Size = new System.Drawing.Size(137, 23);
            this.cmdQuit.TabIndex = 2;
            this.cmdQuit.Text = "Quitter";
            this.cmdQuit.UseVisualStyleBackColor = true;
            this.cmdQuit.Click += new System.EventHandler(this.cmdQuit_Click);
            // 
            // grpBoxbill
            // 
            this.grpBoxbill.Controls.Add(this.cmdQuit);
            this.grpBoxbill.Controls.Add(this.lblStorage);
            this.grpBoxbill.Controls.Add(this.cmdOpenFile);
            this.grpBoxbill.Controls.Add(this.lblTTC);
            this.grpBoxbill.Controls.Add(this.lblHT);
            this.grpBoxbill.Controls.Add(this.lblDate);
            this.grpBoxbill.Controls.Add(this.lblNum);
            this.grpBoxbill.Controls.Add(this.rtxtStorage);
            this.grpBoxbill.Controls.Add(this.txtTTC);
            this.grpBoxbill.Controls.Add(this.txtHT);
            this.grpBoxbill.Controls.Add(this.txtDate);
            this.grpBoxbill.Controls.Add(this.txtNum);
            this.grpBoxbill.Location = new System.Drawing.Point(12, 12);
            this.grpBoxbill.Name = "grpBoxbill";
            this.grpBoxbill.Size = new System.Drawing.Size(468, 468);
            this.grpBoxbill.TabIndex = 0;
            this.grpBoxbill.TabStop = false;
            this.grpBoxbill.Text = "Facture";
            // 
            // Viewbill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 492);
            this.Controls.Add(this.grpBoxbill);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Viewbill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facture ";
            this.Load += new System.EventHandler(this.Viewbill_Load);
            this.grpBoxbill.ResumeLayout(false);
            this.grpBoxbill.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtHT;
        private System.Windows.Forms.TextBox txtTTC;
        private System.Windows.Forms.RichTextBox rtxtStorage;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblHT;
        private System.Windows.Forms.Label lblTTC;
        private System.Windows.Forms.Button cmdOpenFile;
        private System.Windows.Forms.Label lblStorage;
        private System.Windows.Forms.Button cmdQuit;
        private System.Windows.Forms.GroupBox grpBoxbill;
    }
}