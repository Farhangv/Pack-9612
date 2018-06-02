using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseConstructorDemo
{
    class Parent
    {
        public Parent(string name, string family)
        {
            Console.WriteLine("Parent Created!");
            Console.WriteLine($"Hello {name} {family}");
        }
    }
}
