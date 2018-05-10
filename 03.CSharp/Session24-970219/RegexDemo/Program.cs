using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RegexDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter Pattern:");
                var pattern = Console.ReadLine();
                if (pattern == "exit")
                    break;
                Regex re = new Regex(pattern);
                while (true)
                {
                    Console.Write("Enter Text: ");
                    var text = Console.ReadLine();
                    if (text == "exit")
                        break;

                    var isMatch = re.IsMatch(text);
                    Console.ForegroundColor = isMatch ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.WriteLine(text);
                    Console.ForegroundColor = ConsoleColor.White;
                    //Console.WriteLine(re.IsMatch(text));
                }
            }

            
        }
    }
}
