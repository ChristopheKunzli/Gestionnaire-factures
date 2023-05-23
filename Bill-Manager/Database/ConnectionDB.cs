using System;
using System.Collections.Generic;
using System.Windows.Forms;
//using System.Windows.Forms;

using MySqlConnector;

namespace Bill_Manager
{
    public class ConnectionDB
    {
        private string connectionString;

        public ConnectionDB()
        {
            connectionString = "SERVER=SC-C236-PC09; PORT=3306; DATABASE=bill-manager; UID=client_bill-manager; PASSWORD=Pa$$w0rd";
        }

        public ConnectionDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Creates a connection to the database
        /// </summary>
        /// <returns></returns>
        private MySqlConnection openConnection()
        {
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
        /// Fetches entire list of users from the database
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (MySqlConnection connection = openConnection())
            {
                try
                {
                    string cmdText =
                        "SELECT id, email, firstName, lastName, password, isAdmin, hasChangedPassword " +
                        "FROM users";

                    MySqlCommand cmd = new MySqlCommand(cmdText, connection); ;
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

                            users.Add(new User(id, firstName, lastName, mail, pass, isAdmin, hasNewPass));
                        }
                    }

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return users;
        }

        /// <summary>
        /// Fetches entire list of provider from the database
        /// </summary>
        /// <returns></returns>
        public List<Provider> GetAllProviders()
        {
            List<Provider> providers = new List<Provider>();

            using (MySqlConnection connection = openConnection())
            {
                try
                {
                    string cmdText = "SELECT * FROM providers";

                    MySqlCommand cmd = new MySqlCommand(cmdText, connection); ;
                    connection.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id"]);
                            string name = reader["name"].ToString();
                            string email = reader["email"].ToString();
                            string phoneNumber = reader["phoneNumber"].ToString();
                            string roadName = reader["roadName"].ToString();
                            int number = Convert.ToInt32(reader["number"]);
                            int zip = Convert.ToInt32(reader["zip"]);
                            string city = reader["city"].ToString();

                            providers.Add(new Provider(id, name, email, phoneNumber, roadName, number, city, zip.ToString()));
                        }
                    }

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return providers;
        }

        /// <summary>
        /// Fetches entire list of types from the database
        /// </summary>
        /// <returns></returns>
        public List<Type> GetAllTypes()
        {
            List<Type> types = new List<Type>();

            using (MySqlConnection connection = openConnection())
            {
                try
                {
                    string cmdText = "SELECT * FROM types";

                    MySqlCommand cmd = new MySqlCommand(cmdText, connection); ;
                    connection.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id"]);
                            string name = reader["name"].ToString();

                            types.Add(new Type(id, name));
                        }
                    }

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return types;
        }

        /// <summary>
        /// Creates a new user in database
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(User user)
        {
            using (MySqlConnection connection = openConnection())
            {
                try
                {
                    string cmdText =
                        "INSERT INTO users (email, firstName, lastName, password, isAdmin, hasChangedPassword) " +
                        "VALUES (@mail, @first, @last, @pass, @admin, @changed)";

                    MySqlCommand cmd = new MySqlCommand(cmdText, connection); ;
                    cmd.Parameters.AddWithValue("@mail", user.Email);
                    cmd.Parameters.AddWithValue("@first", user.FirstName);
                    cmd.Parameters.AddWithValue("@last", user.LastName);
                    cmd.Parameters.AddWithValue("@pass", user.Password);
                    cmd.Parameters.AddWithValue("@admin", user.IsAdmin);
                    cmd.Parameters.AddWithValue("@changed", user.HasChangedPassword);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Inserts a new biill in the database
        /// </summary>
        /// <param name="bill"></param>
        public void AddBill(Bill bill)
        {
            using (MySqlConnection connection = openConnection())
            {
                try
                {
                    string cmdText =
                        "INSERT INTO bills (billNumber, date, currency, amountHT, amountTTC, storageLocation, imgLink, Provider_id, Type_id, User_id) " +
                        "VALUES (@num, @date, @currency, @HT, @TTC, @storage, @link, @provider, @type, @user)";

                    MySqlCommand cmd = new MySqlCommand(cmdText, connection); ;

                    cmd.Parameters.AddWithValue("@num", bill.BillNumber);
                    cmd.Parameters.AddWithValue("@date", bill.Date);
                    cmd.Parameters.AddWithValue("@currency", bill.Currency);
                    cmd.Parameters.AddWithValue("@HT", bill.AmountHT);
                    cmd.Parameters.AddWithValue("@TTC", bill.AmountTTC);
                    cmd.Parameters.AddWithValue("@storage", bill.StorageLocation);
                    cmd.Parameters.AddWithValue("@link", bill.ImageLink);

                    cmd.Parameters.AddWithValue("@provider", bill.Provider.Id);
                    cmd.Parameters.AddWithValue("@type", bill.Type.Id);
                    cmd.Parameters.AddWithValue("@user", bill.User.Id);

                    connection.Open();

                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
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
                    //MessageBox.Show(ex.Message);
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
                    //MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Fetches a list of every bill linked to a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Bill> GetAllBills(User user)
        {
            List<Provider> providers = GetAllProviders();
            List<Type> types = GetAllTypes();

            List<Bill> bills = new List<Bill>();

            using (MySqlConnection connection = openConnection())
            {
                try
                {
                    string cmdText = 
                        "SELECT * FROM bills " +
                        "WHERE User_id=@id " +
                        "ORDER BY date";

                    MySqlCommand cmd = new MySqlCommand(cmdText, connection); ;
                    cmd.Parameters.AddWithValue("@id", user.Id);

                    connection.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Extract bill data
                            int id = Convert.ToInt32(reader["id"]);
                            string billNumber = Convert.ToString(reader["billNumber"]);
                            DateTime date = Convert.ToDateTime(reader["date"]);
                            string currency = Convert.ToString(reader["currency"]);
                            double amountHT = Convert.ToDouble(reader["amountHT"]);
                            double amountTTC = Convert.ToDouble(reader["amountTTC"]);
                            string storage = Convert.ToString(reader["storageLocation"]);
                            string link = Convert.ToString(reader["imgLink"]);
                            int prov_id = Convert.ToInt32(reader["Provider_id"]);
                            int type_id = Convert.ToInt32(reader["Type_id"]);
                            int user_id = Convert.ToInt32(reader["User_id"]);

                            //Get the provider
                            Provider provider = null;
                            foreach (Provider p in providers)
                            {
                                if (p.Id == prov_id)
                                {
                                    provider = p;
                                }
                            }

                            //Get the type
                            Type type = null;

                            foreach(Type t in types)
                            {
                                if(t.Id ==  type_id)
                                {
                                    type = t;
                                }
                            }

                            //Add the bill to the list
                            Bill bill = new Bill(id, billNumber, date, currency, amountHT, amountTTC, storage, link, provider, type, user);

                            bills.Add(bill);
                        }
                    }

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return bills;
        }
    }
}
