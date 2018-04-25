using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueRefNullDemo
{
    class Program
    {
        
        static int fieldNum;
        static string fieldName;//null
        static bool fieldBool;
        static void Main(string[] args)
        {
            int num;
            string name;

            //Console.WriteLine(num);
            //Console.WriteLine(name);

            Console.WriteLine(fieldNum);
            Console.WriteLine(fieldName);
            Console.WriteLine(fieldBool);
            
            Console.ReadKey();

        }
    }
}
