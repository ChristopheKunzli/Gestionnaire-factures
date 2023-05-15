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

        /// <summary>
        /// Creates a connection to the database
        /// </summary>
        /// <returns></returns>
        private MySqlConnection openConnection()
        {
            string connectionString = "SERVER=127.0.0.1; PORT=3306; DATABASE=bill-manager; UID=client_bill-manager; PASSWORD=Pa$$w0rd";
            return new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Fetches a user from the database
        /// </summary>
        /// <param name="email"></param>
        /// <returns>the user or null if not present in databse</returns>
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

        /// <summary>
        /// Changes a user's password
        /// </summary>
        /// <param name="user"></param>
        /// <param name="newPassword"></param>
        public void UpdateUserPassword(User user, string newPassword)
        {
            using (MySqlConnection connection = openConnection())
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmdUpdate = connection.CreateCommand();

                    //Change the password hash stored in DB
                    cmdUpdate.CommandText = "UPDATE users SET password=@pass WHERE email=@mail";

                    cmdUpdate.Parameters.AddWithValue("@pass", newPassword);
                    cmdUpdate.Parameters.AddWithValue("@mail", user.Email);

                    cmdUpdate.ExecuteNonQuery();

                    //Indicate that this user has now changed password
                    cmdUpdate.CommandText = "UPDATE users SET hasChangedPassword=1 WHERE email=@mail";
                    cmdUpdate.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Adds a new provider to the database
        /// </summary>
        /// <param name="provider"></param>
        public void AddProvider(Provider provider)
        {
            using (MySqlConnection connection = openConnection())
            {
                try
                {
                    string cmdText =
                        "INSERT INTO providers (name, email, phoneNumber, roadName, number, zip, city) " +
                        "VALUES (@name, @email, @phone, @roadName, @num, @zip, @city)";

                    MySqlCommand cmd = new MySqlCommand(cmdText, connection); ;
                    cmd.Parameters.AddWithValue("@name", provider.Name);
                    cmd.Parameters.AddWithValue("@email", provider.Email);
                    cmd.Parameters.AddWithValue("@phone", provider.Phone);
                    cmd.Parameters.AddWithValue("@roadName", provider.RoadName);
                    cmd.Parameters.AddWithValue("@num", provider.Number);
                    cmd.Parameters.AddWithValue("@zip", provider.Zip);
                    cmd.Parameters.AddWithValue("@city", provider.City);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
