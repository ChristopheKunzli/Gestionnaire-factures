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
    public partial class Login : Form
    {
        private User user;
        public User User { get { return user; } }

        public Login()
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
            user = connection.GetUser(mail);

            if (user == null)
            {
                MessageBox.Show("Email ou mot de passe erroné");
                return;
            }

            if (!BC.Verify(password, User.Password))
            {
                MessageBox.Show("Mot de passe incorrecte");
                user = null;
                return;
            }

            if(!User.HasChangedPassword)
            {
                Form changePass = new ChangePassword(user);

                //Determine what to do when the changePassword form is closed based on it's dialog result
                changePass.FormClosing += delegate
                {
                    if (changePass.DialogResult == DialogResult.OK)
                    {
                        //If user successfully changed their password, go to main form
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        this.Show();
                        user = null;
                    }
                };

                changePass.Show();
                this.Hide();

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
