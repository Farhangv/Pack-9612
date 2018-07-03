using SOAPClientDemo.CalculatorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAPClientDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorServiceSoapClient client = new CalculatorServiceSoapClient();
            var result = client.Sum(10, 20);
            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
