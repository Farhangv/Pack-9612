using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    class Employee:Person
    {
        public string EmployeeCode { get; set; }
        public int WorkingHours { get; set; }
        public int ExtraHours { get; set; }
        public int Base { get; set; }
    }
}
