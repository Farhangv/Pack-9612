using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo2
{
    public delegate void PrintArrayResult(int[] numbers);

    class Program
    {
        static void Main(string[] args)
        {
            PrintArrayResult par = new PrintArrayResult(PrintMax);
            par += PrintMin;
            par += PrintSum;

            par(new int[] { 10, 45, 78, 96, 45, 12, 30, 12, 452, 13, 65, 85, 15, 95, 65, 74 });
            Console.ReadKey();

        }

        static void PrintMax(int[] numbers)
        {
            var num = numbers[0];
            for (int i = 0; i < numbers.Length; i++)
            {
                //if (numbers[i] > num)
                //    num = numbers[i];
                num = numbers[i] > num ? numbers[i] : num;
            }
            Console.WriteLine($"Max: {num}");
        }

        static void PrintMin(int[] numbers)
        {
            var num = numbers[0];
            for (int i = 0; i < numbers.Length; i++)
            {
                num = numbers[i] < num ? numbers[i] : num;
            }
            Console.WriteLine($"Min: {num}");

        }

        static void PrintSum(int[] numbers)
        {
            var sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
