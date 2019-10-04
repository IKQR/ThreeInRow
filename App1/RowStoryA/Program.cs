using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeInRow;

namespace RowStoryA
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("\u0000" + "\u0000" + "\u2588");
            Console.WriteLine("\u2588" + "\u2588" + "\u2588");
            Console.ReadKey();*/
            Console.OutputEncoding = Encoding.UTF8;
            Level lvl = new Level(new Size(4), new Point(1,1));
            lvl.DrawFance();
            while(true) lvl.DrawCandys();

            Console.ReadKey();
        }
    }
}
