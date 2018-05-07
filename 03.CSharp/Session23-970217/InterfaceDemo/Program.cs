using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            //ICalculable c = new ICalculable();
            //ICalculable p1 = new Product();
            List<ICalculable> calculables = new List<ICalculable>();
            calculables.Add(new Employee() { TotalWorkingHours = 100 });
            calculables.Add(new Teacher() { TotalTeachingHours = 100 });
            calculables.Add(new Product() { Price = 1000 });
            calculables.Add(new Service() { Cost = 2500 });

            foreach (var calculable in calculables)
            {
                Console.WriteLine(calculable.GetTotalAmount());
            }

            Console.ReadKey();
        }
    }
}
