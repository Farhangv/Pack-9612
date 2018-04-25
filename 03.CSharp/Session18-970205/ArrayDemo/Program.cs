using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers;
            numbers = new int[10];
            //numbers = new int[]
            //{
            //    10,25,65,89,32,45,75,20,14,45,74,62,73,28
            //};
            numbers[0] = 20;
            numbers[1] = 26;
            numbers[2] = 45;
            numbers[4] = 3;
            numbers[5] = 78;
            numbers[6] = 85;
            numbers[7] = 34;
            numbers[8] = 16;
            numbers[9] = 39;
            //...

            Console.WriteLine(
                string.Join(",", numbers));
            Array.Sort(numbers);
            Console.WriteLine(
                string.Join(",", numbers));
            Console.WriteLine(numbers.Length);
            

            Console.ReadKey();
        }
    }
}
