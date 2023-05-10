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

            frmLogin login = new frmLogin();
            Application.Run(login);

            DialogResult result = login.DialogResult;

            //End if the user closed the form without logging in
            if (result != DialogResult.OK)
            {
                return;
            }

            User user = login.User;

            //Destroy login form
            login.Dispose();
            login = null;

            //Determine what to do next based on user's privileges
            Form nextAction = null;

            switch (user.IsAdmin)
            {
                case true:
                    nextAction = new ChooseAction(user);
                    break;
                case false:
                    MessageBox.Show("pas admin");
                    break;
                default:
                    MessageBox.Show("erreur");
                    break;
            }
            
            Application.Run(nextAction);
        }
    }
}
