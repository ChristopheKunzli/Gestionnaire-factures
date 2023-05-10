using Bill_Manager.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using BC = BCrypt.Net.BCrypt;

namespace Bill_Manager
{
    public partial class ChangePassword : Form
    {
        private User user;

        public ChangePassword(User user)
        {
            InitializeComponent();

            this.user = user;
        }

        private readonly HashSet<char> SPECIAL_CHARS = new HashSet<char>("#$%&()*+-<=>?@".ToCharArray());

        private void cmdConfirm_Click(object sender, EventArgs e)
        {
            string password = txtNewPassword.Text;
            string confirmPass = txtConfirmNewPassword.Text;

            //Errors
            if (password == string.Empty)
            {
                MessageBox.Show("Veuillez rentrer un mot depasse");
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Minimum 8 caractères");
                return;
            }

            if (confirmPass == string.Empty || !confirmPass.Equals(password))
            {
                MessageBox.Show("Veuillez confirmer votre mot de passe ");
                return;
            }

            //Check if password meets requirements
            if (isPasswordValid(password))
            {
                //Update the password in the databse
                ConnectionDB connection = new ConnectionDB();
                connection.UpdateUserPassword(user, BC.HashPassword(password));

                //Leave this form and login form
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Mot de passe invalide");
            }
        }

        /// <summary>
        /// Method used to check if the password fulfills all our requirements of a valid password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool isPasswordValid(string password)
        {
            return new Regex("^.*(?=.{8,})(?=.*[a-zA-Z])(?=.*\\d)(?=.*[#$%&()*+<=>?@]).*$").IsMatch(password);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
