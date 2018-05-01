using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Student std = new Student()
            {
                fullname = "John Doe",
                //scores = new double[] { 12.3,15.4,20,9.9,1.5, 16.8,19.4 }
                scores = new double[] { 200000.1 , 2000000.1 }
            };

            Console.WriteLine(std.GetAverage().ToString("000.00"));
            Console.WriteLine(std.GetAverage().ToString("###.##"));
            Console.WriteLine(std.GetAverage().ToString("#,###.00"));

            Console.ReadKey();
        }
    }
}
