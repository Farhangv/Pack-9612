using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumDemo
{

    enum MediaType
    {
        Video = 250,
        Audio = 324,
        Photo = 479
    }
    class Media
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public MediaType MediaType { get; set; }
    }
}
