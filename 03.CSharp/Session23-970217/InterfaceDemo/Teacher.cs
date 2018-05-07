using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    class Teacher : Person, ICalculable
    {
        public int TotalTeachingHours { get; set; }
        public int GetTotalAmount()
        {
            return -1 * TotalTeachingHours * 1000;
        }
    }
}
