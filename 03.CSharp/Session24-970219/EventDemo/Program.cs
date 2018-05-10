using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            User u = new User();
            u.InvalidPassword += new InvalidPasswordHandler(InvalidPasswordEntered);

            do
            {
                u.Username = Console.ReadLine();
                u.Password = Console.ReadLine();

            } while (!u.Authenticate());

            Console.WriteLine("You Are Logged In");
            Console.ReadKey();
        }

        static void InvalidPasswordEntered(string username, int count)
        {
            Console.WriteLine($"{username}, You eneterd invalid password {count} times!");
        }
    }
}
