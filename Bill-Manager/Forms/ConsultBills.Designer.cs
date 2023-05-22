namespace Bill_Manager
{
    partial class ConsultBills
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabBills = new System.Windows.Forms.TabPage();
            this.tabStats = new System.Windows.Forms.TabPage();
            this.lstBoxProviders = new System.Windows.Forms.ListBox();
            this.numMin = new System.Windows.Forms.NumericUpDown();
            this.numMax = new System.Windows.Forms.NumericUpDown();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmdViewBill = new System.Windows.Forms.Button();
            this.cmdQuit = new System.Windows.Forms.Button();
            this.dgvBills = new System.Windows.Forms.DataGridView();
            this.lblProviders = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblBills = new System.Windows.Forms.Label();
            this.tabMain.SuspendLayout();
            this.tabBills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabBills);
            this.tabMain.Controls.Add(this.tabStats);
            this.tabMain.Location = new System.Drawing.Point(12, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(856, 436);
            this.tabMain.TabIndex = 0;
            // 
            // tabBills
            // 
            this.tabBills.Controls.Add(this.lblBills);
            this.tabBills.Controls.Add(this.lblMax);
            this.tabBills.Controls.Add(this.lblMin);
            this.tabBills.Controls.Add(this.lblProviders);
            this.tabBills.Controls.Add(this.dgvBills);
            this.tabBills.Controls.Add(this.cmdQuit);
            this.tabBills.Controls.Add(this.cmdViewBill);
            this.tabBills.Controls.Add(this.cmdSearch);
            this.tabBills.Controls.Add(this.numMax);
            this.tabBills.Controls.Add(this.numMin);
            this.tabBills.Controls.Add(this.lstBoxProviders);
            this.tabBills.Location = new System.Drawing.Point(4, 22);
            this.tabBills.Name = "tabBills";
            this.tabBills.Padding = new System.Windows.Forms.Padding(3);
            this.tabBills.Size = new System.Drawing.Size(848, 410);
            this.tabBills.TabIndex = 0;
            this.tabBills.Text = "Factures";
            this.tabBills.UseVisualStyleBackColor = true;
            // 
            // tabStats
            // 
            this.tabStats.Location = new System.Drawing.Point(4, 22);
            this.tabStats.Name = "tabStats";
            this.tabStats.Padding = new System.Windows.Forms.Padding(3);
            this.tabStats.Size = new System.Drawing.Size(848, 410);
            this.tabStats.TabIndex = 1;
            this.tabStats.Text = "Statistiques";
            this.tabStats.UseVisualStyleBackColor = true;
            // 
            // lstBoxProviders
            // 
            this.lstBoxProviders.FormattingEnabled = true;
            this.lstBoxProviders.Location = new System.Drawing.Point(7, 29);
            this.lstBoxProviders.Name = "lstBoxProviders";
            this.lstBoxProviders.Size = new System.Drawing.Size(160, 368);
            this.lstBoxProviders.TabIndex = 0;
            // 
            // numMin
            // 
            this.numMin.Location = new System.Drawing.Point(215, 29);
            this.numMin.Name = "numMin";
            this.numMin.Size = new System.Drawing.Size(100, 20);
            this.numMin.TabIndex = 1;
            // 
            // numMax
            // 
            this.numMax.Location = new System.Drawing.Point(214, 71);
            this.numMax.Name = "numMax";
            this.numMax.Size = new System.Drawing.Size(100, 20);
            this.numMax.TabIndex = 2;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(215, 116);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(133, 23);
            this.cmdSearch.TabIndex = 3;
            this.cmdSearch.Text = "Recherche";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdViewBill
            // 
            this.cmdViewBill.Location = new System.Drawing.Point(215, 193);
            this.cmdViewBill.Name = "cmdViewBill";
            this.cmdViewBill.Size = new System.Drawing.Size(133, 23);
            this.cmdViewBill.TabIndex = 4;
            this.cmdViewBill.Text = "Voir la facture";
            this.cmdViewBill.UseVisualStyleBackColor = true;
            this.cmdViewBill.Click += new System.EventHandler(this.cmdViewBill_Click);
            // 
            // cmdQuit
            // 
            this.cmdQuit.Location = new System.Drawing.Point(215, 373);
            this.cmdQuit.Name = "cmdQuit";
            this.cmdQuit.Size = new System.Drawing.Size(133, 23);
            this.cmdQuit.TabIndex = 5;
            this.cmdQuit.Text = "Quitter";
            this.cmdQuit.UseVisualStyleBackColor = true;
            this.cmdQuit.Click += new System.EventHandler(this.cmdQuit_Click);
            // 
            // dgvBills
            // 
            this.dgvBills.AllowUserToAddRows = false;
            this.dgvBills.AllowUserToDeleteRows = false;
            this.dgvBills.AllowUserToOrderColumns = true;
            this.dgvBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBills.Location = new System.Drawing.Point(400, 28);
            this.dgvBills.MultiSelect = false;
            this.dgvBills.Name = "dgvBills";
            this.dgvBills.Size = new System.Drawing.Size(442, 368);
            this.dgvBills.TabIndex = 6;
            // 
            // lblProviders
            // 
            this.lblProviders.AutoSize = true;
            this.lblProviders.Location = new System.Drawing.Point(8, 9);
            this.lblProviders.Name = "lblProviders";
            this.lblProviders.Size = new System.Drawing.Size(63, 13);
            this.lblProviders.TabIndex = 7;
            this.lblProviders.Text = "Founisseurs";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(214, 9);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(89, 13);
            this.lblMin.TabIndex = 8;
            this.lblMin.Text = "Montant minimum";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(215, 52);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(92, 13);
            this.lblMax.TabIndex = 9;
            this.lblMax.Text = "Montant maximum";
            // 
            // lblBills
            // 
            this.lblBills.AutoSize = true;
            this.lblBills.Location = new System.Drawing.Point(400, 8);
            this.lblBills.Name = "lblBills";
            this.lblBills.Size = new System.Drawing.Size(48, 13);
            this.lblBills.TabIndex = 10;
            this.lblBills.Text = "Factures";
            // 
            // ConsultBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 460);
            this.Controls.Add(this.tabMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ConsultBills";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulter mes factures";
            this.Load += new System.EventHandler(this.ConsultBills_Load);
            this.tabMain.ResumeLayout(false);
            this.tabBills.ResumeLayout(false);
            this.tabBills.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabBills;
        private System.Windows.Forms.TabPage tabStats;
        private System.Windows.Forms.DataGridView dgvBills;
        private System.Windows.Forms.Button cmdQuit;
        private System.Windows.Forms.Button cmdViewBill;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.NumericUpDown numMax;
        private System.Windows.Forms.NumericUpDown numMin;
        private System.Windows.Forms.ListBox lstBoxProviders;
        private System.Windows.Forms.Label lblBills;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblProviders;
    }
}