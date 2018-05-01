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
        public string[] Course { get; set; }
        public override string ToString()
        {
            //return $"{this.Id}.{this.Name} {this.Family} - NationalCode: {this.NationalCode} (STUDENT{this.EntranceYear})";
            return $"{base.ToString()} (STUDENT{this.EntranceYear})";
        }
    }
}
