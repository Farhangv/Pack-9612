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
            List<string> names = new List<string>();
            names.Add("C#");
            names.Add("PHP");
            names.Add("Java");
            names.Add("Python");
            names.Add("Haskell");
            names.Add("Go");
            //names.Add(DateTime.Now);
            //names.Sort();
            names.Remove("Python");
            Console.WriteLine(names.Count);

            names.AddRange(new string[] { "JavaScript", "CSS", "HTML" });
            names.Insert(1, "Pascal");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("----------------------------");
            Console.WriteLine(names.Contains("Ruby"));
            Console.WriteLine(names.Contains("HTML"));
            Console.WriteLine(names.IndexOf("Ruby"));
            Console.WriteLine(names.IndexOf("HTML"));
            
            Console.ReadKey();
        }
    }
}
