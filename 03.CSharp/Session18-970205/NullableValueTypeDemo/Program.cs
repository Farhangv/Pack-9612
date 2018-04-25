using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableValueTypeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //int num;
            //num = null;

            int? num;
            num = null;

            Console.WriteLine(num);

            Console.ReadKey();

        }
    }
}
