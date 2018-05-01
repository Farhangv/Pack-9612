using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetterSetterDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p = new Product()
            {
                //name = "Laptop",
                //count = 10
            };
            p.SetName("LapTop");
            p.SetCount(10);

            //...

            //if(p.count > 15)
                //p.count = p.count - 15;

            Console.WriteLine($"Count Before Sale {p.GetCount()}");

            p.SetCount(p.GetCount() - 5);

            Console.WriteLine($"Count After Sale {p.GetCount()}");

            Console.ReadKey();
        }
    }
}
