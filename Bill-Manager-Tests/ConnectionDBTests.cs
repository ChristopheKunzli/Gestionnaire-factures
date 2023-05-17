using Bill_Manager;
using MySqlConnector;

namespace Bill_Manager_Tests
{
    public class ConnectionDBTests
    {
        ConnectionDB connection;

        [SetUp]
        public void Setup()
        {
            string connectionString = "SERVER=127.0.0.1; PORT=3306; DATABASE=bill-manager_test; UID=client_bill-manager; PASSWORD=Pa$$w0rd";
            string path = @"C:\db_test.sql";

            resetDB(connectionString, path);

            connection = new ConnectionDB(connectionString);

        }

        /// <summary>
        /// Resets the DB from a backup file
        /// </summary>
        /// <param name="connectionString">The connection string</param>
        /// <param name="path">The script containing the backup</param>
        private void resetDB(string connectionString, string path)
        {
            //The file containg the backup script
            FileInfo file = new FileInfo(path);

            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                mySqlConnection.Open();

                //Get the backup script
                string script = file.OpenText().ReadToEnd();

                MySqlCommand cmd = new MySqlCommand(script, mySqlConnection);
                cmd.ExecuteNonQuery();

                mySqlConnection.Close();
            }
        }

        [Test]
        public void getTypes_success()
        {
            List<Bill_Manager.Type> expected = new List<Bill_Manager.Type>
            {
                new Bill_Manager.Type(1, "médicale"),
                new Bill_Manager.Type(2, "communication"),
                new Bill_Manager.Type(3, "électricité"),
                new Bill_Manager.Type(4, "loyer")
            };

            //Get the actual list of types present in DB and sort it by id
            List<Bill_Manager.Type> actual = connection.GetAllTypes();
            actual = actual.OrderBy(x => x.Id).ToList();

            //Check that both lists have equal length
            Assert.AreEqual(expected.Count, actual.Count);

            //Check that the names of each type in both lists correspond
            for (int i = 0; i < expected.Count; ++i)
            {
                Assert.AreEqual(expected[i].Name, actual[i].Name);
            }
        }
    }
}
