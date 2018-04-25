using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DArrayDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] table = new int[10,10];

            int x = 0;
            while (x <= table.GetUpperBound(0))
            {
                int y = 0;
                while (y <= table.GetUpperBound(1))
                {
                    table[x, y] = (x + 1) * (y + 1);
                    y++;
                }
                x++;
            }

            x = 0;
            while (x <= table.GetUpperBound(0))
            {
                int y = 0;
                while (y <= table.GetUpperBound(1))
                {
                    Console.Write("\t" + table[x,y]);
                    y++;
                }
                x++;
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
