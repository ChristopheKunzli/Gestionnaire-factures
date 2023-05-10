namespace Bill_Manager
{
    partial class ChooseAction
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
            this.cmdImport = new System.Windows.Forms.Button();
            this.cmdProvider = new System.Windows.Forms.Button();
            this.cmdconsultBills = new System.Windows.Forms.Button();
            this.cmdNewUser = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdImport
            // 
            this.cmdImport.Location = new System.Drawing.Point(36, 42);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(160, 30);
            this.cmdImport.TabIndex = 0;
            this.cmdImport.Text = "Importer une facture";
            this.cmdImport.UseVisualStyleBackColor = true;
            this.cmdImport.Click += new System.EventHandler(this.nextAction);
            // 
            // cmdProvider
            // 
            this.cmdProvider.Location = new System.Drawing.Point(36, 78);
            this.cmdProvider.Name = "cmdProvider";
            this.cmdProvider.Size = new System.Drawing.Size(160, 30);
            this.cmdProvider.TabIndex = 1;
            this.cmdProvider.Text = "Ajouter fournisseur";
            this.cmdProvider.UseVisualStyleBackColor = true;
            this.cmdProvider.Click += new System.EventHandler(this.nextAction);
            // 
            // cmdconsultBills
            // 
            this.cmdconsultBills.Location = new System.Drawing.Point(36, 114);
            this.cmdconsultBills.Name = "cmdconsultBills";
            this.cmdconsultBills.Size = new System.Drawing.Size(160, 30);
            this.cmdconsultBills.TabIndex = 2;
            this.cmdconsultBills.Text = "Consulter vos factures";
            this.cmdconsultBills.UseVisualStyleBackColor = true;
            this.cmdconsultBills.Click += new System.EventHandler(this.nextAction);
            // 
            // cmdNewUser
            // 
            this.cmdNewUser.Location = new System.Drawing.Point(36, 150);
            this.cmdNewUser.Name = "cmdNewUser";
            this.cmdNewUser.Size = new System.Drawing.Size(160, 30);
            this.cmdNewUser.TabIndex = 3;
            this.cmdNewUser.Text = "Créer nouvel utilisateur";
            this.cmdNewUser.UseVisualStyleBackColor = true;
            this.cmdNewUser.Click += new System.EventHandler(this.nextAction);
            // 
            // cmdExit
            // 
            this.cmdExit.Location = new System.Drawing.Point(36, 186);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(160, 30);
            this.cmdExit.TabIndex = 4;
            this.cmdExit.Text = "Quitter";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.nextAction);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(33, 15);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(59, 13);
            this.lblWelcome.TabIndex = 5;
            this.lblWelcome.Text = "default text";
            // 
            // ChooseAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 231);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdNewUser);
            this.Controls.Add(this.cmdconsultBills);
            this.Controls.Add(this.cmdProvider);
            this.Controls.Add(this.cmdImport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ChooseAction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.ChooseAction_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdImport;
        private System.Windows.Forms.Button cmdProvider;
        private System.Windows.Forms.Button cmdconsultBills;
        private System.Windows.Forms.Button cmdNewUser;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Label lblWelcome;
    }
}