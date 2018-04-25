using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //int i = 0;
            //for (string text = "Hello";;i++)//while(true)
            //{
            //    Console.WriteLine(text + i);
            //}
            var names = new string[10]
            {
                "C#", "Java", "PHP", "Go", "TypeScript", "JavaScript", "Haskell", "R", "Python", "Ruby"
            };

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }

            Console.ReadKey();
        }
    }
}
