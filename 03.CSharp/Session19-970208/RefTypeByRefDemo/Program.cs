using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefTypeByRefDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] {10};
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("______________________");
            AddDoubledValueToArray(ref numbers);
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.ReadKey();
        }

        static void AddDoubledValueToArray(ref int[] input)
        {
            var newArray = new int[input.Length + 1];
            for (int i = 0; i < input.Length; i++)
            {
                newArray[i] = input[i];
            }

            newArray[newArray.Length - 1] = input[input.Length - 1] * 2;

            input = newArray;
        }
    }
}
