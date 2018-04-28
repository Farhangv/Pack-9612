using System;
using System.Text.RegularExpressions;
using System.Threading;


namespace PhoneBookDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            var names = new string[1];
            var families = new string[1];
            var phones = new string[1];


            InitializePhoneBook();
            while (true)
            {
                Console.Clear();
                var selectedMenuItem = ShowMenu();

                Console.Clear();
                switch (selectedMenuItem)
                {
                    case 1:
                        
                        ShowContactList(names, families, phones);
                        break;
                    case 2:
                        if (!AddToContactList(ref names, ref families, ref phones))
                            ShowInvalidPhoneNotification();
                        break;

                }

            }
        }

        static void ShowInvalidPhoneNotification()
        {

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Phone Number Is Not Valid!");
            Console.CursorVisible = false;
            Thread.Sleep(3000);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = true;

        }

        static bool AddToContactList(ref string[] names, ref string[] families, ref string[] phones)
        {
            Console.Write("Name:");
            var name = Console.ReadLine();
            Console.Write("Family:");
            var family = Console.ReadLine();
            Console.Write("Phone:");
            var phone = Console.ReadLine();
            if (Regex.IsMatch(phone, @"^09\d{9}$"))
            {
                AddToStringArray(ref names, name);
                AddToStringArray(ref families, family);
                AddToStringArray(ref phones, phone);
                return true;
            }
            else
            {
                return false;
            }
        }

        static void ShowContactList(string[] names, string[] families, string[] phones)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] != null)
                    Console.WriteLine($"{names[i]}\t{families[i]}\t{phones[i]}");
            }

            Console.WriteLine("-------------------------------");
            Console.ReadKey();
        }

        static void InitializePhoneBook()
        {
            Console.WriteLine("Welcome To Phonebook");
            //var count = int.Parse(Console.ReadLine());
            Thread.Sleep(2000);
            Console.Clear();
        }

        static int ShowMenu()
        {
            Console.WriteLine("1.Show Contact List\n2.Add New Contact\n3.Edit Contact\n4.Remove Contact\n5.Exit");
            return int.Parse(Console.ReadLine());
        }


        static void AddToStringArray(ref string[] array, string newValue)
        {
            string[] newArray;

            if (array[0] != null)
                newArray = new string[array.Length + 1];
            else
                newArray = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            newArray[newArray.Length - 1] = newValue;
            array = newArray;
        }
    }
}
