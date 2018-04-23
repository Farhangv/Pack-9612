using System;

namespace CSharpIntroDemo
{
    class Program
    {
        /// <summary>
        /// این تابع مشخص کننده نقطه شروع و پایان برنامه است
        /// </summary>
        /// <param name="args">این پارامتر ها معمولا توسط سیستم عامل به تابع ارسال میشوند</param>
        static void Main(string[] args)
        {
            //Console.Write("Csharp Intro Course");
            ////نوشتن یک متن در کنسول
            //Console.WriteLine("Hello");
            //Console.WriteLine(123);
            //Console.WriteLine(DateTime.Now);
            //Console.WriteLine("Goodbye");

            string name = "Mr.Doe";
            double balance = 2000;
            double withdraw = 500;
            DateTime date = DateTime.Now;

            Console.WriteLine("Hello" + name + "\n" +
                              "Withdraw Amount:" + withdraw + "\t" +
                              "Your Balance:" + balance + "\n" +
                              "Date:" + date
                              );

            Console.WriteLine("Hello {0}\nWithdraw Amount:{1}\tYour Balance:{2}\nDate:{3}",
                name,
                withdraw,
                balance,
                date);

            Console.WriteLine($"Hello {name}\nWithdraw Amount:{withdraw}\tYour Balance:{balance - withdraw}\nDate:{date}");
            Console.ReadKey();
            /*
             * در
             *این
             *بخش
             *برنامه
             * تمام
             * میشود
             */

        }
    }
}
