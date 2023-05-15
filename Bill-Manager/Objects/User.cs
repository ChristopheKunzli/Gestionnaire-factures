using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill_Manager
{
    public class User
    {
        private int id;
        private string firstName;
        private string lastName;
        private string email;
        private string password;
        private bool isAdmin;
        private bool hasChangedPassword;

        public int Id { get { return id; } }
        public string FirstName { get { return firstName; } }
        public string LastName { get { return lastName; } }
        public string Email { get { return email; } }
        public string Password { get { return password; } }
        public bool IsAdmin { get { return isAdmin; } }
        public bool HasChangedPassword { get { return hasChangedPassword; } }

        public User(int id, string firstName, string lastName, string email, string password, bool isAdmin, bool hasChangedPassword)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.isAdmin = isAdmin;
            this.hasChangedPassword = hasChangedPassword;
        }

        public User(string firstName, string lastName, string email, string password, bool isAdmin, bool hasChangedPassword)
        {
            this.id = -1;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.isAdmin = isAdmin;
            this.hasChangedPassword = hasChangedPassword;
        }

        public override string ToString()
        {
            return $"{firstName} {lastName}";
        }
    }
}
