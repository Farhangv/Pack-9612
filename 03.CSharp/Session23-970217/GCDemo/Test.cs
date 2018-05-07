using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCDemo
{
    class Test
    {
        public static int Count;
        public Test()
        {
            Test.Count++;
        }
        ~Test()
        {
            Test.Count--;
        }

    }
}
