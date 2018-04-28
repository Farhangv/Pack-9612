using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteWelcomeMessage();
            Console.WriteLine("Write your name:");
            WriteHelloMessage(Console.ReadLine());
            var age = GetCalculatedAge();
            Console.WriteLine($"Your age is {age}");

            Console.ReadKey();
        }

        
        static void WriteWelcomeMessage()
        {
            Console.WriteLine("Welcome to my application!");
        }

        static void WriteHelloMessage(string name)
        {
            Console.WriteLine($"Hello {name}");
        }

        static int GetCalculatedAge()
        {
            Console.WriteLine("Please Enter Your Birthdate:");
            var birthdate = DateTime.Parse(Console.ReadLine());
            return DateTime.Now.Year - birthdate.Year;
        }
    }
}
