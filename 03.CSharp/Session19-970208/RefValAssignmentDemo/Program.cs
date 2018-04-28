using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefValAssignmentDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = a;
            Console.WriteLine(b);
            a = 20;
            Console.WriteLine(b);

            Console.WriteLine("-------------------------");
            int[] aa = new int[] {10};
            int[] bb = aa;
            Console.WriteLine(bb[0]);
            aa[0] = 20;
            Console.WriteLine(bb[0]);

            Console.ReadKey();
        }
    }
}
