using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeInRow
{
    public class Element
    {
        public Colors Color { get; set; }
        public Point Position { get; set; }
    }
    public class Candy : Element
    {
        bool isActive { get; set; }
        protected Symbols view;
        public Symbols View
        {
            get
            {
                return view;
            }
            set
            {
                switch(value)
                {
                    case Symbols.Сircle: goto yes;
                    case Symbols.Triangle: goto yes;
                    case Symbols.Square: goto yes;
                    case Symbols.Hearth: goto yes;
                    case Symbols.Empty: goto yes;
                    default: goto no;
                }
                yes: view = value;
                no:;
            }
        }
        public Candy(Point position, Colors color, Symbols view)
        {
            isActive = false;
            Color = color;
            Position = position;
            View = view;
        }
        public void Draw()
        {
            Print.write((char)View);
        }
    }
}
