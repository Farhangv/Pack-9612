using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsDemo
{
    class Student
    {
        public string fullname;
        public double[] scores;

        public double GetAverage()
        {
            var sum = 0.0;
            for (int i = 0; i < scores.Length; i++)
            {
                sum += scores[i];
            }
            return sum / Convert.ToDouble(scores.Length);
        }
    }
}
