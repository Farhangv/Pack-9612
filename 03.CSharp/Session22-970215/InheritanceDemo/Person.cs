using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }

        //public static string Institute { get; set; }

        private static string institute;

        public static string Institute
        {
            get { return institute; }
            set { institute = value; }
        }

        public static void SampleStaticMethod()
        {
            
        }

        public abstract double GetBalance();

        public override string ToString()
        {
            //Person.Institute
            return $"{this.Id}|\t{this.Name}\t{this.Family}\t\t|NationalCode: {this.NationalCode}";
        }
    }
}
