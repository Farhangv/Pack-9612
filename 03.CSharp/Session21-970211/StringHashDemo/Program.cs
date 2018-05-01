using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringHashDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            string name = new String(new char[] {'D', 'a', 'v', 'i', 'd'}); //= "David";
            Console.WriteLine(name.GetHashCode());
            Console.WriteLine("David".GetHashCode());
            string name2 = "David";
            Console.WriteLine(name2.GetHashCode());
            Console.ReadKey();
        }
    }
}
