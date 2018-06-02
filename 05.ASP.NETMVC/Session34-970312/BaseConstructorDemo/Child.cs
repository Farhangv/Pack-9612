using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseConstructorDemo
{
    class Child:Parent
    {
        public Child(string name, string family)
            //:base("John" , "Doe")
            :base(name,family)
        {
            Console.WriteLine("Child Created!");
        }
    }
}
