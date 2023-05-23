using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bill_Manager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            DialogResult result = DialogResult.None;
            User user = null;

            using (Login login = new Login())
            {
                Application.Run(login);
                result = login.DialogResult;
                user = login.User;
            }

            //End if the user closed the form without logging in
            if (result != DialogResult.OK)
            {
                return;
            }

            //Determine what to do next based on user's privileges
            Form nextAction = null;

            switch (user.IsAdmin)
            {
                case true:
                    nextAction = new ChooseAction(user);
                    break;
                case false:
                    nextAction = new ConsultBills(user);
                    break;
                default:
                    MessageBox.Show("erreur");
                    break;
            }

            if (nextAction != null)
            {
                Application.Run(nextAction);
            }
        }
    }
}
