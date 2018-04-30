using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}");
            //int[] nums = new[] {12, 34, 56, 34, 76, 98, 69, 97, 36, 85, 45, 76};
            //Console.WriteLine(sum(nums));
            Console.WriteLine(sum(12, 34, 56, 34, 76, 98, 69, 97, 36, 85, 45, 76));

            Console.ReadKey();
        }

        static int sum(params int[] numbers)
        {
            var sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            return sum;
        }
    }
}
