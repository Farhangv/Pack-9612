using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeepDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var r = new Random();
                var freq = r.Next(1000, 20000);
                var duration = r.Next(500, 2000);
                Console.Beep(freq, duration);
                
            }
            
        }
    }
}
