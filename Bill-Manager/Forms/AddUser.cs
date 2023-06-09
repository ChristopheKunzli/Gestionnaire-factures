﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bill_Manager
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the add user button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            //Errors
            if (txtEmail.Text == string.Empty || txtFirstName.Text == string.Empty || txtLastName.Text == string.Empty)
            {
                MessageBox.Show("Veuillez renseigner tous les champs");
                return;
            }

            ConnectionDB connectionDB = new ConnectionDB();

            if (connectionDB.GetUser(txtEmail.Text) is User)
            {
                MessageBox.Show("Cet utilisateur existe déjà");
                return;
            }

            //Extract data
            string email = txtEmail.Text;
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;

            bool isAdmin = chkAdmin.Checked;

            User newUser = new User(firstName, lastName, email, BCrypt.Net.BCrypt.HashPassword("1234"), isAdmin, false);

            //Send new user to DB connection class
            connectionDB.AddUser(newUser);

            Close();
        }

        /// <summary>
        /// Event handler for the cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
