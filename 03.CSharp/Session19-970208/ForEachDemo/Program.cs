using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEachDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new string[]
            {
                "C#",
                "PHP",
                "Java",
                "JavaScript",
                "Python"
            };

            foreach (var name in names)
            {
                //name += ", Hello";
                Console.WriteLine(name);
            }

            Console.ReadKey();
        }
    }
}
