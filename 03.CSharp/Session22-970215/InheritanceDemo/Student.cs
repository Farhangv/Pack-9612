using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    class Student:Person
    {
        public string StudentCode { get; set; }
        public int EntranceYear { get; set; }
        public string[] Courses { get; set; }

        public override double GetBalance()
        {
            return Courses.Length * 1000000;
        }

        public override string ToString()
        {
            //return $"{this.Id}.{this.Name} {this.Family} - NationalCode: {this.NationalCode} (STUDENT{this.EntranceYear})";
            return $"{base.ToString()}\t|(STUDENT{this.EntranceYear})";
        }
    }
}
