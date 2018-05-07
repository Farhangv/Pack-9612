using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollectionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, Person> people = new Dictionary<string, Person>();
            //people.Add("73829472719", new Person() { Name = "John", Family = "Doe" });
            //people.Add("73822372719", new Person() { Name = "David", Family = "Smith" });
            //people.Add("47829472719", new Person() { Name = "Sarah", Family = "Smith" });

            //people.Remove("73822372719");
            //Person p = people["73829472719"];

            //foreach (KeyValuePair<string, Person> item in people)
            //{
            //    Console.WriteLine(item.Key);
            //    Console.WriteLine(item.Value.Name);
            //    Console.WriteLine("-----------------------");
            //}

            //Queue<int> q = new Queue<int>();
            //q.Enqueue(1);
            //q.Enqueue(2);
            //q.Enqueue(3);
            //q.Enqueue(4);


            //Console.WriteLine(q.Dequeue());
            //Console.WriteLine(q.Dequeue());
            //Console.WriteLine(q.Dequeue());
            //Console.WriteLine(q.Dequeue());

            Stack<int> s = new Stack<int>();
            s.Push(1);
            s.Push(2);
            s.Push(3);
            s.Push(4);

            Console.WriteLine(s.Pop());
            Console.WriteLine(s.Pop());
            Console.WriteLine(s.Pop());
            Console.WriteLine(s.Pop());
            


            Console.ReadKey();
        }
    }
}
