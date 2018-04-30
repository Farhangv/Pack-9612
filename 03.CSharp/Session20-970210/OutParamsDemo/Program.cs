using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutParamsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Array Size:");
            var numbers = new int[int.Parse(Console.ReadLine())];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            //int sum, max;
            //double avg;

            Console.WriteLine(
                    calculations(numbers,
                        out int sum,
                        out int min,
                        out int max,
                        out double avg)
                );
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Average: {avg}");

            Console.ReadKey();
        }

        static string calculations(int[] numbers,
            out int sum, out int min, out int max, out double average)
        {
            //Console.WriteLine(sum);
            sum = 0;
            min = numbers[0];
            max = numbers[0];
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
                if (numbers[i] < min)
                    min = numbers[i];

                if (numbers[i] > max)
                    max = numbers[i];
            }

            average = 
                Convert.ToDouble(sum) / 
                Convert.ToDouble(numbers.Length);

            return $"Array has {numbers.Length} members!";
        }
    }
}
