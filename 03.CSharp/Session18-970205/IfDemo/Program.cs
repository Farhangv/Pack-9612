using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Username:");
            var username = Console.ReadLine().ToLower();
            Console.Write("Password:");
            var password = Console.ReadLine();

            if (username == "admin" && password == "admin@123")
            {
                Console.WriteLine("Admin, You Are Logged In!");
            }
            else if (username == "supervisor" && password == "supervisor@123")
            {
                Console.WriteLine("Supervisor, You Are Logged In!");
            }
            else
            {
                Console.WriteLine("Username or Password is invalid!");
            }

            Console.ReadKey();

        }
    }
}
