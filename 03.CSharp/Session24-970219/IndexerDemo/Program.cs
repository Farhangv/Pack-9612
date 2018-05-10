using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            Person p = new Person();
            p["name"] = "john";
            p["family"] = "doe";

            Console.WriteLine(p["name"]);
            Console.WriteLine(p["family"]);

            Console.ReadKey();
        }
    }
}
