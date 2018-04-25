using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Start Position:");
            Console.Write("Left:");
            var left = int.Parse(Console.ReadLine());
            Console.Write("Top:");
            var top = int.Parse(Console.ReadLine());
            Console.CursorVisible = false;
            Console.Clear();

            while (true)
            {
                ConsoleKey inputKey = Console.ReadKey().Key;
                
                switch (inputKey)
                {
                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(left, --top);
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(" ");
                        break;
                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(left, ++top);
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(" ");
                        break;
                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(++left, top);
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(" ");
                        break;
                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(--left, top);
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write(" ");
                        break;
                }
            }
        }
    }
}
