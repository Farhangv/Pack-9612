using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{
    public delegate void TextWriter(string text);
    class Program
    {
        static void Main(string[] args)
        {
            TextWriter myMethods = new TextWriter(WriteHello);
            myMethods += WriteHowRU;
            myMethods += WriteGoodbye;
            //myMethods += SampleMethod;

            myMethods("John");

            Console.ReadKey();
        }

        static void WriteHello(string name)
        {
            Console.WriteLine($"Hello {name}");
        }

        static void WriteHowRU(string name)
        {
            Console.WriteLine($"How Are You {name}?");
        }

        static void WriteGoodbye(string name)
        {
            Console.WriteLine($"Goodbye {name}");
        }

        static int SampleMethod(string name, string family)
        {
            return 0;
        }
    }
}
