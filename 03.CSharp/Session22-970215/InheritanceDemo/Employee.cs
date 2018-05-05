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

        public override double GetBalance()
        {
            return this.GetTotalPaymentAmount() * -1;
        }

        public virtual double GetTotalPaymentAmount()
        {
            return (Base * WorkingHours) + (Base * ExtraHours * 1.4);
        }

        public double GetTotalPaymentAmount(double _tax)
        {
            return this.GetTotalPaymentAmount() * (1 - _tax);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_tax">Tax Percentage, this number should be in 0,1 range.</param>
        /// <param name="_insurance">Insurance Percentage, this number should be in 0,1 range</param>
        /// <returns></returns>
        public double GetTotalPaymentAmount(double _tax, double _insurance)
        {
            return this.GetTotalPaymentAmount() * (1 - _tax - _insurance);
        }

        public override string ToString()
        {
            //"{param:format}"
            //return $"{base.ToString()}\t|{this.GetTotalPaymentAmount(0.1,0.07):#,###}";
            return $"{base.ToString()}\t|{this.GetTotalPaymentAmount():#,###}";
        }
    }
}
