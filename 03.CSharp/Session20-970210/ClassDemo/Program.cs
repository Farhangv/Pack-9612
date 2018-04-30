using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassDemo.Entities;

namespace ClassDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Object o = new Object();
            
            Person john = new Person();
            john.name = "John";
            john.family = "Doe";
            john.phone = "09124567896";

            Person sarah = new Person()
            {
                name = "Sarah",
                family = "Smith",
                phone = "093945641236"
            };

            Person[] people = new Person[3];
            people[0] = john;
            people[1] = sarah;
            people[2] = new Person()
            {
                name = "Joey",
                family = "Tribbiani",
                phone = "09127412589"
            };

            foreach (var person in people)
            {
                Console.WriteLine($"{person.name}\t{person.family}\t{person.phone}");
            }

            Console.ReadKey();
        }
    }

    //public class Person
    //{
    //    public string name;
    //    public string family;
    //    public string phone;
    //}
}
