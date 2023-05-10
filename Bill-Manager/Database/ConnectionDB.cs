using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySqlConnector;

namespace Bill_Manager.Database
{
    public class ConnectionDB
    {
        public ConnectionDB() { }

        private MySqlConnection openConnection()
        {
            string connectionString = "SERVER=127.0.0.1; PORT=3306; DATABASE=bill-manager; UID=client_bill-manager; PASSWORD=Pa$$w0rd";
            return new MySqlConnection(connectionString);
        }

        public User GetUser(string email)
        {
            User user = null;

            using (MySqlConnection connection = openConnection())
            {
                try
                {
                    string cmdText =
                        "SELECT id, email, firstName, lastName, password, isAdmin, hasChangedPassword " +
                        "FROM users " +
                        "WHERE email = @mail";

                    MySqlCommand cmd = new MySqlCommand(cmdText, connection); ;
                    cmd.Parameters.AddWithValue("@mail", email);
                    connection.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id"]);
                            string mail = reader["email"].ToString();
                            string firstName = reader["firstName"].ToString();
                            string lastName = reader["lastName"].ToString();
                            string pass = reader["password"].ToString();
                            bool isAdmin = (reader["isAdmin"].ToString() == "1");
                            bool hasNewPass = (reader["hasChangedPassword"].ToString() == "1");

                            user = new User(id, firstName, lastName, email, pass, isAdmin, hasNewPass);
                            break;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    user = null;
                }
                finally
                {
                    connection.Close();
                }
            }

            return user;
        }

    }
}
