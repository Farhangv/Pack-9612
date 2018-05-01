using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritedMethodsDemo
{
    public class Person
    {
        public string name;
        public string family;
        public string phone;

        public override int GetHashCode()
        {
            //return int.Parse(phone);
            return this.phone.GetHashCode();
        }

        public override string ToString()
        {
            return $"{this.name} {this.family} : {this.phone}";
        }

        public override bool Equals(object obj)
        {
            //return this.GetHashCode() == obj.GetHashCode();
            //Person other = (Person) obj;
            //Person other = obj as Person;
            //if(other != null)
            //    return this.name == other.name && this.family == other.family;
            //else
            //{
            //    return false;
            //}

            if (obj is Person)
            {
                Person other = obj as Person;
                return this.name == other.name && this.family == other.family;
            }
            else
            {
                return false;
            }
        }
    }
}
