using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    class Teacher:Employee
    {
        public string[] Courses { get; set; }
        public int Experience { get; set; }
    }
}
