using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SalesEmployee salesEmployee1 = new SalesEmployee()
            {
                Id = 1,
                Base = 1000,
                WorkingHours = 100,
                ExtraHours = 5,
                Name = "John",
                Family = "Doe",
                NationalCode = "1234567890",
                TotalSales = 10000000,
                Percentage = 0.02
            };
            Teacher teacher1 = new Teacher()
            {
                Id = 2,
                Name = "Sarah",
                Family = "Smith",
                Base = 2000,
                WorkingHours = 50,
                NationalCode = "9876543210",
                Experience = 3,
                Courses = new string[] { "Java", "PHP", "MySQL" }

            };
            Student student1 = new Student()
            {
                Id = 3, 
                Name = "David",
                Family = "Doe",
                Course = new string[] {"PHP", "MySQL"},
                EntranceYear = 1396,
                NationalCode = "8521479630"
            };
            Employee employee1 = new Employee()
            {
                Id = 4,
                Name = "Payam",
                Family = "Payami",
                Base = 3000,
                WorkingHours = 120,
                ExtraHours = 10,
                NationalCode = "4568527419"
            };

            Person[] people = new Person[]
            {
                employee1, teacher1, student1, salesEmployee1
            };

            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }

            Console.ReadKey();
        }
    }
}
