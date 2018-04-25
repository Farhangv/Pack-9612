using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchCaseDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Programming Language Name:");
            var language = Console.ReadLine();
            switch (language.ToLower())
            {
                case "c#":
                    Console.WriteLine("C# is microsoft's OO language");
                    break;
                case "javascript":
                    Console.WriteLine("javascript is used as client side programming language!");
                    break;
                case "html":
                    Console.WriteLine("HTML is a web markup language for defining structure of a web page!");
                    break;
                    
                default:
                    Console.WriteLine("Programming language is not recognized!");
                    break;
            }

            Console.ReadKey();
        }
    }
}
