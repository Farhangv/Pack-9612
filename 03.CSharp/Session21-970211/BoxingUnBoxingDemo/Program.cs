using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxingUnBoxingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Boxing /Upcasting
            object o = new Person()
            {
                name = "John",
                family = "Doe"
            };

            //Unboxing /Downcasting
            Person p = (Person) o;
            Console.WriteLine(p.name);
            Console.WriteLine(p.family);


            Console.ReadKey();
        }
    }
}
