﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoWhileDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 10;
            while (num < 10)
            {
                Console.WriteLine("Text From While Loop!");
            }

            do
            {
                Console.WriteLine("Text From Do...While");
            } while (num < 10);

            Console.ReadKey();
        }
    }
}
