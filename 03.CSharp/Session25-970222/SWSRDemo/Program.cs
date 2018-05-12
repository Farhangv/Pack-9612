using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWSRDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (StreamWriter sw = new StreamWriter(@"output.txt", true))
            //{
            //    //sw.AutoFlush = true;
            //    sw.WriteLine(Console.ReadLine());
            //    //sw.Flush();
            //}//sw.Close();

            using (StreamReader sr = new StreamReader("output.txt"))
            {
                //Console.WriteLine(sr.Read());
                //Console.WriteLine((char)sr.Read());
                //Console.WriteLine((char)sr.Read());
                //Console.WriteLine((char)sr.Read());
                //Console.WriteLine((char)sr.Read());
                //Console.WriteLine((char)sr.Read());

                //while (sr.Peek() != -1)
                //{
                //    Console.Write((char)sr.Read());
                //}

                //while (sr.Peek() != -1)
                //{
                //    Console.WriteLine(sr.ReadLine());
                //}

                Console.WriteLine(sr.ReadToEnd());
            }

            Console.ReadKey();

        }
    }
}
