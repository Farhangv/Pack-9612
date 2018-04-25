using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WhileDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[5];
            int index = 0;
            while (index < names.Length)
            {
                names[index] = Console.ReadLine();
                //index = index + 1;
                //index += 1;
                index++;
            }

            index = 0;
            while (index < names.Length)
            {
                Console.WriteLine(names[index++]);
                //index = index + 1;
                
            }

            Console.ReadKey();
        }
    }
}
