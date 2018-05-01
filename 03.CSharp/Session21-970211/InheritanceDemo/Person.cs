using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }

        public override string ToString()
        {
            return $"{this.Id}|\t{this.Name}\t{this.Family}\t\t|NationalCode: {this.NationalCode}\t|";
        }
    }
}
