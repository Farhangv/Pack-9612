using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListDemo
{
    class Person:IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }

        public override string ToString()
        {
            return $"{this.Id} {this.Name} {this.Family}";
        }

        public override int GetHashCode()
        {
            return this.Id;

        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            var other = obj as Person;
            return (this.Family+this.Name).CompareTo((other.Family+other.Name)) * -1;
        }
    }
}
