using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionalParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteHello("Sarah", "Smith");
            WriteHello("John", "Doe", "Mr");
            Console.ReadKey();
        }

        static void WriteHello(string name, string family, string title = "Mrs")
        {
            Console.WriteLine($"Hello {title}.{name} {family}");
        }
    }
}
