using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList names = new ArrayList();
            names.Add("C#");
            names.Add("PHP");
            names.Add(DateTime.Now);
            names.Add(12);
            names.Add("Java");
            foreach (var name in names)
            {
                Console.WriteLine(name);
                
            }
            names.Sort();
            names.Remove("C#");

            Console.ReadKey();
        }
    }
}
