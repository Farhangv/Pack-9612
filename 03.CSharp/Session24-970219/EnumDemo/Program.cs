using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Media m = new Media();
            m.MediaType = MediaType.Audio;
            m.MediaType = (MediaType)479;
            Console.WriteLine((int)m.MediaType);


            Console.ReadKey();
        }
    }
}
