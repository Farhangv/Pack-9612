using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(3));
            Console.ReadKey();
        }

        static int Factorial(int num)
        {
            if (num == 1)
                return 1;
            else
                return num * Factorial(--num);
        }
    }
}
