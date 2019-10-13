using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TreeInRow;

namespace Algorythm_try
{
    class Program
    {
        public static void down(Level lvl)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for(int x = 0; x < lvl.Size.Width; x++)
                {
                    for(int y = 0; y < lvl.Size.Height-1; y++)
                    {
                        if(lvl.Candys[x,y+1].View == Symbols.Empty && lvl.Candys[x,y].View != Symbols.Empty)
                        {
                            Console.SetCursorPosition(lvl.Candys[x,y+1].Position.X, lvl.Candys[x, y + 1].Position.Y);
                            lvl.Exchange(lvl.Candys[x, y + 1].Position, lvl.Candys[x, y].Position, true, true);
                            flag = true;
                            System.Threading.Thread.Sleep(10);
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Random rnd = new Random();
            Level lvl = new Level(new Size(15), new Point(1,1));
            lvl.Candys[0, 1].View = Symbols.Empty;
            for(int i = 0; i< lvl.Size.Height+20; i++)
                lvl.Candys[rnd.Next(0, lvl.Size.Height-1), rnd.Next(0, lvl.Size.Height-1)].View = Symbols.Empty;
            lvl.DrawCandys();
            down(lvl);
            lvl.DrawCandys();

            Console.ReadKey();
        }
    }
}
