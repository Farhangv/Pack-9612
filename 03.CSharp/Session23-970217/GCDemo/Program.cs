using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                var t = new Test();
                Console.WriteLine(Test.Count);
            }
        }
    }
}
