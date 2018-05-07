using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    class Service: ICalculable
    {
        public int Cost { get; set; }

        public int GetTotalAmount()
        {
            return Cost * 2;
        }
    }
}
