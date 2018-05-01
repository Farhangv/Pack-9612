using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyDemo
{
    class Product
    {
        private string name;

        public string Name
        {
            get {
                return name;
            }
            set {
                name = value;
            }
        }

        public string Code { get; set; }


        private int count;

        public int Count
        {
            get { return this.count; }
            set
            {
                if (value > 0)
                    this.count = value;
            }
        }
    }
}
