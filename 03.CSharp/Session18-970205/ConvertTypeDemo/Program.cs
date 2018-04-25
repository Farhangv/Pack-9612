using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertTypeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Base Number:");
            var baseNum = double.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter Power:");
            var powerNum = Convert.ToDouble(Console.ReadLine());

            var result = Math.Pow(baseNum, powerNum);

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
