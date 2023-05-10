using Bill_Manager.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BC = BCrypt.Net.BCrypt;

namespace Bill_Manager
{
    public partial class frmLogin : Form
    {
        public User User;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void attemptConnection()
        {
            string mail = txtEmail.Text;
            string password = txtPassword.Text;

            //Errors
            if (mail == string.Empty)
            {
                MessageBox.Show("Veuillez rentrer une adresse email valide");
                return;
            }

            if (password == string.Empty)
            {
                MessageBox.Show("Veuillez rentrer votre mot de passe");
                return;
            }

            ConnectionDB connection = new ConnectionDB();
            this.User = connection.GetUser(mail);

            if (this.User == null)
            {
                MessageBox.Show("Email ou mot de passe erroné");
                return;
            }

            if (!BC.Verify(password, User.Password))
            {
                MessageBox.Show("Mot de passe incorrecte");
                this.User = null;
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            attemptConnection();
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                attemptConnection();
            }
        }
    }
}
