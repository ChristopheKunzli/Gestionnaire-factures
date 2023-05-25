using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill_Manager
{
    public class Provider
    {
        private int id;
        private string name;
        private string email;
        private string phone;
        private string roadName;
        private int number;
        private string city;
        private string zip;

        public int Id { get { return id; } }
        public string Name { get { return name; } }
        public string Email { get { return email; } }
        public string Phone { get { return phone; } }
        public string RoadName { get { return roadName; } }
        public int Number { get { return number; } }
        public string City { get { return city; } }
        public string Zip { get { return zip; } }

        public Provider(int id, string name, string email, string phone, string roadName, int number, string city, string zip)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.roadName = roadName;
            this.number = number;
            this.city = city;
            this.zip = zip;
        }

        public Provider(string name, string email, string phone, string roadName, int number, string city, string zip)
        {
            this.id = -1;
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.roadName = roadName;
            this.number = number;
            this.city = city;
            this.zip = zip;
        }

        public override string ToString()
        {
            return $"{name}";
        }
    }
}
