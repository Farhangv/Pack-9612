using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerDemo
{
    class Person
    {
        public string this[string _key]
        {
            get {
                switch (_key)
                {
                    case "name":
                        return this.name;
                    case "family":
                        return this.family;
                    case "nationalCode":
                        return this.nationalCode;
                    case "age":
                        return this.age.ToString();
                    default:
                        return "";
                }
            }

            set
            {
                switch (_key)
                {
                    case "name":
                        this.name = value;
                        break;
                    case "family":
                        this.family = value;
                        break;
                    case "nationalCode":
                        this.nationalCode = value;
                        break;
                    case "age":
                        this.age = int.Parse(value);
                        break;
                   
                }
            }
        }

        private string name;
        private string family;
        private string nationalCode;
        private int age;
    }
}
