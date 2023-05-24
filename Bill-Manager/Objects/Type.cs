using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill_Manager
{
    public class Type
    {
        private int id;
        private string name;

        public int Id { get { return id; } }
        public string Name { get { return name; } }

        public Type(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public override string ToString()
        {
            return $"{name}";
        }
    }
}
