using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetterSetterDemo
{
    class Product
    {
        private string name;
        public string GetName()
        {
            return this.name;
        }

        public void SetName(string _name)
        {
            this.name = _name;
        }


        private int count;
        public void SetCount(int _count)
        {
            if (_count > 0)
                this.count = _count;
        }

        public int GetCount()
        {
            return this.count;
        }
    }
}
