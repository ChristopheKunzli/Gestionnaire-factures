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
            Form nextAction = null;

            Button action = (Button)sender;
            switch (action.Name)
            {
                case "cmdImport":
                    MessageBox.Show("Importer facture");
                    break;

                case "cmdBiller":
                    MessageBox.Show("Ajouter fournisseur");
                    break;

                case "cmdConsultBills":
                    MessageBox.Show("Voir mes factures");
                    break;

                case "cmdNewUser":
                    MessageBox.Show("Ajouter utilisateur");
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
            lblWelcome.Text = $"Welcome {user}";
            lblWelcome.Location = new Point((Size.Width - lblWelcome.Size.Width) / 2 -10, lblWelcome.Location.Y);
        }
    }
}
