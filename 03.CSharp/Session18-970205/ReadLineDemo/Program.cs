using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadLineDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Your Name:");
            string name = Console.ReadLine();

            Console.WriteLine($"Hello {name}");
            Console.ReadKey();
        }
    }
}
