using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>()
            {
                "C#",
                "Java",
                "HTML",
                "PHP",
                "Go",
                "JavaScript",
                "Python",
                "C",
                "C++"
            };

            names.Sort();
            Console.WriteLine(names.Contains("HTML"));
            names.Remove("Go");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("--------------------------------");

            List<Person> people = new List<Person>()
            {
                new Person() {Id = 1, Name = "Ross" , Family = "Geller"},
                new Person() {Id = 2, Name = "Monica", Family = "Geller"},
                new Person() {Id = 3, Name = "Chandler", Family = "Bing"},
                new Person() {Id = 4, Name = "John" , Family = "Doe"}
            };

            //people.Remove(new Person() { Id = 4, Name = "John", Family = "Doe" });
            //Console.WriteLine(people.Contains(new Person() { Id = 4, Name = "John", Family = "Doe" }));
            people.Sort();

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }

            //foreach (var item in Person)
            //{

            //}
            Console.ReadKey();
        }
    }
}
