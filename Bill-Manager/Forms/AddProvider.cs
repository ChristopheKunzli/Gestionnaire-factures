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

namespace Bill_Manager
{
    public partial class AddProvider : Form
    {
        public AddProvider()
        {
            InitializeComponent();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            //Extract data from form
            string name = txtName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string road = txtRoadName.Text;
            int number = (int)numNumber.Value;
            string city = txtCity.Text;
            string zip = txtZip.Text;

            //Check that mandatory fields are not empty
            if(name == "" || road == "" || city == "" || zip == "" || number == 0)
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires (*)");
            }

            //Send the provider to DB via connection class
            ConnectionDB connection = new ConnectionDB();
            connection.AddProvider(new Provider(name, email, phone, road, number, city, zip));
            
            //close form
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
