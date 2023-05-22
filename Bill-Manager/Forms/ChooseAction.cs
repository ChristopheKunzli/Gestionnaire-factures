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
    public partial class ChooseAction : Form
    {
        private User user;

        public ChooseAction(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void nextAction(object sender, EventArgs e)
        {
            Button action = (Button)sender;

            //Determine what form to open next based on which button was clicked
            Form nextAction = null;

            switch (action.Name)
            {
                case "cmdImport":
                    nextAction = new ImportBill();
                    break;

                case "cmdProvider":
                    nextAction = new AddProvider();
                    break;

                case "cmdconsultBills":
                    nextAction = new ConsultBills(user);
                    break;

                case "cmdNewUser":
                    nextAction = new AddUser();
                    break;

                case "cmdExit":
                    Close();
                    break;

                default:
                    MessageBox.Show("Il y a eu un problème");
                    return;
            }

            if (nextAction != null)
            {
                //Show again the chooseAction form when the next action form closes
                nextAction.FormClosing += delegate
                {
                    Show();
                };
                nextAction.Show();
                Hide();
            }
        }

        private void ChooseAction_Load(object sender, EventArgs e)
        {
            //Display the user's name on the form
            lblWelcome.Text = $"Welcome {user}";
            lblWelcome.Location = new Point((Size.Width - lblWelcome.Size.Width) / 2 - 10, lblWelcome.Location.Y);
        }
    }
}
