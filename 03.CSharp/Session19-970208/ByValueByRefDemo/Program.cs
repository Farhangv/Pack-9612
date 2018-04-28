using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByValueByRefDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = 10;
            Console.WriteLine(number);
            ChangeNumber(ref number);
            Console.WriteLine(number);
            Console.WriteLine("------------------------------");
            var text = "Salaam";
            Console.WriteLine(text);
            ChangeText(ref text);
            Console.WriteLine(text);
            Console.WriteLine("------------------------------");
            var date = DateTime.Now;
            Console.WriteLine(date);
            ChangeDate(date);
            Console.WriteLine(date);
            Console.WriteLine("------------------------------");
            var numbers = new int[] { 10 };
            Console.WriteLine(numbers[0]);
            ChangeArray(ref numbers);
            Console.WriteLine(numbers[0]);
            Console.WriteLine("------------------------------");

            Console.ReadKey();
        }

        static void ChangeNumber(ref int input)
        {
            input += 10;
        }

        static void ChangeText(ref string input)
        {
            input += " Text From Function";
        }

        static void ChangeDate(DateTime input)
        {
            input = input.AddDays(10);
        }

        static void ChangeArray(ref int[] input)
        {
            input[0] += 10;
        }
    }
}
