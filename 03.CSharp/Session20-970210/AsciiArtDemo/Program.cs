using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArtDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteX();
            WriteX();
            Console.ReadKey();
        }

        private static void WriteX()
        {
            Console.WriteLine(@" __   __");
            Console.WriteLine(@" \ \ / /");
            Console.WriteLine(@"  \ V / ");
            Console.WriteLine(@"   > <  ");
            Console.WriteLine(@"  / . \ ");
            Console.WriteLine(@" /_/ \_\");
        }
    }
}
