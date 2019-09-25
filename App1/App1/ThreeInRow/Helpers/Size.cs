using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    class Size
    {
        public Int32 Height { get; set; }
        public Int32 Width { get; set; }

        public Size(Int32 width, Int32 height)
        {
            Width = width;
            Height = height;
        }
        public Size(Int32 size)
        {
            Height = size;
            Width = size;
        }
    }
}
