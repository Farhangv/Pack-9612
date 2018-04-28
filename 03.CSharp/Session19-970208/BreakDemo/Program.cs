using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please enter a number:(enter 'exit' to exit app...)");
                var input = Console.ReadLine();
                //TODO: Write code to exit app
                if (input.ToLower() == "exit")
                    break;


                var number = int.Parse(input);
                var result = 1;
                for (; number > 1; number --)
                {
                    result *= number;
                }

                Console.WriteLine("--------------");
                Console.WriteLine(result);
                Console.ReadKey();
            }
        }
    }
}
