using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace StringFunctionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("    Hello           " + "John");
            //Console.WriteLine("    Hello           ".Trim() + "John");

            //Console.WriteLine("Hello John".Substring(1,3));
            //Console.WriteLine("Hello"[2]);
            //Console.WriteLine("Hello John".Contains("David"));
            //Console.WriteLine("Hello John".Replace("John", "David"));
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.Persian To Gregorian\n2.Gregorian To Persian");

                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        PersianToGregorian();
                        break;
                    case 2:
                        GregorianToPersian();
                        break;
                }

                Console.ReadKey();
            }
        }

        private static void GregorianToPersian()
        {
            Console.WriteLine("Enter you Gregorian BirthDate:(YYYY/MM/DD)");
            DateTime dt = DateTime.Parse(Console.ReadLine());
            var pc = new PersianCalendar();
            Int32 year = pc.GetYear(dt);
            var month = pc.GetMonth(dt);
            var day = pc.GetDayOfMonth(dt);

            Console.WriteLine($"{year}/{month}/{day}");
        }

        private static void PersianToGregorian()
        {
                Console.WriteLine("Enter you Jalali BirthDate:(YYYY/MM/DD)");
                var splittedText = Console.ReadLine().Split('/');
                var year = int.Parse(splittedText[0]);
                var month = int.Parse(splittedText[1]);
                var day = int.Parse(splittedText[2]);

                var pc = new PersianCalendar();
                DateTime dt = pc.ToDateTime(year, month, day, 0, 0, 0, 0);
                Console.WriteLine(dt.ToString("yyyy/MM/dd dddd"));
           
        }
    }
}
