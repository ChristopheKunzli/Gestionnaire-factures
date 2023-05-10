using Bill_Manager;

using BC = BCrypt.Net.BCrypt;

namespace Bill_Manager_Tests
{
    public class UserTests
    {
        User user;

        [SetUp]
        public void Setup()
        {
            string password = BC.HashPassword("Pa$$w0rd");
            user = new User(1, "jean", "paul", "jean.paul@cpnv.ch", password, false, false);
        }

        [Test]
        public void toString_Success()
        {
            Assert.AreEqual("jean paul", user.ToString());
        }

        [Test]
        public void passwordCheck_Failure()
        {
            string inputPassword = "aWrongPass$w0rd";
            string passwordHash = user.Password;

            Assert.False(BC.Verify(inputPassword, passwordHash));
        }

        [Test]
        public void passwordCheck_Success()
        {
            string inputPassword = "Pa$$w0rd";
            string passwordHash = user.Password;

            Assert.True(BC.Verify(inputPassword, passwordHash));
        }

        [Test]
        public void defaultID_Failure()
        {
            User newUser = new User("t", "t", "t.t@gmail.com", BC.HashPassword(""), true, true);

            Assert.AreNotEqual(1, newUser.Id);
        }

        [Test]
        public void defaultID_Success()
        {
            User newUser = new User("t", "t", "t.t@gmail.com", BC.HashPassword(""), true, true);

            Assert.AreEqual(-1, newUser.Id);
        }
    }
}