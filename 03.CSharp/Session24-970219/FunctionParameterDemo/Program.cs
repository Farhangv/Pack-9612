using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionParameterDemo
{
    public delegate bool NumberFilter(int number);
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //PrintFilteredNumbers(numbers, OddFilter);
            //PrintFilteredNumbers(numbers, EvenFilter);

            //PrintFilteredNumbers(numbers, 
            //(x) => 
            //{
            //    return x % 2 == 0;
            //});

            PrintFilteredNumbers(numbers, x => x % 2 == 0);
            Console.ReadKey();
        }

        public static void PrintFilteredNumbers(int[] numbers, NumberFilter filter)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if(filter(numbers[i]))
                    Console.WriteLine(numbers[i]);
            }
        }

        static bool OddFilter(int num)
        {
            return num % 2 != 0;
        }

        static bool EvenFilter(int num)
        {
            return num % 2 == 0;
        }
    }
}
