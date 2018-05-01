using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p = new Product()
            {
                Name = "Laptop",
                Count = 10,
                Code = "LVB-8564"
            };

            Console.WriteLine(p.Count);
            p.Count = 5;
            Console.WriteLine(p.Count);

            Console.ReadKey();
        }
    }
}
