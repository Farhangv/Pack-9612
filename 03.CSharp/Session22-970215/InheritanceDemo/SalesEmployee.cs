using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    class SalesEmployee:Employee
    {
        public int TotalSales { get; set; }
        public double Percentage { get; set; }
        //public new double GetTotalPaymentAmount()
        public override double GetTotalPaymentAmount()
        {
            return base.GetTotalPaymentAmount() + (TotalSales * Percentage);
        }

        
    }
}
