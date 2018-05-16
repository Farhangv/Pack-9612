using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Exam exam = new Exam()
            {
                Questions = new List<Question>()
                {
                    new Question() { Text = "1" },
                    new Question() { Text = "2" },
                    new Question() { Text = "3" },
                    new Question() { Text = "4" },
                }
            };
            foreach (Question q in exam)
            {
                Console.WriteLine(q.Text);
            }

            Console.ReadKey();
        }
    }
}
