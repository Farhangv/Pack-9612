using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClassDemo
{
    class Financial<T> where T : Student
    {
        public double Calculate(T _args)
        {
            return 0;
        }
    }
}
