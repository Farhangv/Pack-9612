using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    class Product : ICalculable
    {
        public int Price { get; set; }
        public int GetTotalAmount()
        {
            return Price;
        }
    }
}
