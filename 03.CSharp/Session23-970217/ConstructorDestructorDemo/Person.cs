using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorDestructorDemo
{
    class Person
    {
        public Person(string _name, string _family)
        {
            this.Name = _name;
            this.Family = _family;
        }

        public Person()
        {
            this.Name = "";
            this.Family = "";
        }

        public string Name { get; set; } = "";
        public string Family { get; set; } = "";


        ~Person()
        {
            Console.WriteLine("Object Removed from memory!");
        }
    }
}
