using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace DynamicDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic user = new ExpandoObject();
            user.name = "Hello";

            Console.WriteLine(user.name);

            Console.ReadKey();
        }

        public static void WriteObject(dynamic obj)
        {
            Console.WriteLine(obj.Name);
        }
    }
}
