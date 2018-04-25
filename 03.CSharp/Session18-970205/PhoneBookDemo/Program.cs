using System;
using System.Text.RegularExpressions;
using System.Threading;


namespace PhoneBookDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Size:");
            var count = int.Parse(Console.ReadLine());
            Console.Clear();
            var names = new string[count];
            var families = new string[count];
            var phones = new string[count];

            bool isPhoneValid = true;

            for (int x = 0;true;)
            {
                if (!isPhoneValid)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Phone Number Is Not Valid!");
                    Console.CursorVisible = false;
                    isPhoneValid = true;
                    Thread.Sleep(3000);
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.CursorVisible = true;
                Console.Clear();

                for (int i = 0; i < count; i++)
                {
                    if(names[i] != null)
                        Console.WriteLine($"{names[i]}\t{families[i]}\t{phones[i]}");
                }

                Console.WriteLine("_________________________");
                if (x < count)
                {
                    Console.Write("Name:");
                    names[x] = Console.ReadLine();
                    Console.Write("Family:");
                    families[x] = Console.ReadLine();
                    Console.Write("Phone:");
                    var phone = Console.ReadLine();
                    if (Regex.IsMatch(phone, @"^09\d{9}$"))
                    {
                        phones[x] = phone;
                        x++;
                    }
                    else
                    {
                        names[x] = null;
                        families[x] = null;
                        isPhoneValid = false;
                    }
                }
                else
                {
                    Console.WriteLine("Phone Book is full!");
                    Console.ReadKey();
                }

                
            }
        }
    }
}
