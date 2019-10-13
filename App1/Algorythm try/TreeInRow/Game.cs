using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeInRow
{
    public class Game
    {
        protected Level lvl { get; set; }
        public Game(int size)
        {
            Console.OutputEncoding = Encoding.UTF8;
            lvl = new Level(new Size(size), new Point(1,1));
        }
        public void Start()
        {
            lvl.DrawFance();
            lvl.DrawCandys();
            Cursor cursor = new Cursor(lvl.Candys[0, 0].Position, lvl.Size);
            while(cursor.Live(lvl))
            {

            }
            Console.Clear();
            Print.writeLn("Goodbye!!!", 250);
            Print.write(" ", 1000);

        }
    }
}
