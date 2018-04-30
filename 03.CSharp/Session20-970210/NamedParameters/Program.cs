using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamedParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteHello(family: "Doe", title:"Mrs.");
            WriteHello(family: "Smith", name: "Sarah");
            WriteHello();
            Console.ReadKey();
        }
        static void WriteHello(string name = "", 
            string family = "", 
            string title = "")
        {
            Console.WriteLine($"Hello {title}{name} {family}");
        }
    }
}
