using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritedMethodsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person()
            {
                name = "John",
                family = "Doe",
                phone = "09127418529"
            };
            Person p = new Person()
            {
                name = "John",
                family = "Doe",
                phone = "09127418527"
            };

            Console.WriteLine(p.GetHashCode());
            Console.WriteLine(p1.GetHashCode());
            Console.WriteLine(p.ToString());
            Console.WriteLine(p1.ToString());
            Console.WriteLine(p.GetType());
            Console.WriteLine(p.Equals(p1));
            string name = "kahkeshan";
            Console.WriteLine(p.Equals(name));
            Console.ReadKey();
        }
    }
}
