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
        protected Symbols view;
    }
    public class Candy : Element
    {
        protected bool isActive { get; set; }
        public bool IsActive { 
            get 
            { 
                return isActive; 
            } 
        }
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
            Point cursorPosition = new Point(
                Console.CursorLeft,
                Console.CursorTop
                );

            Console.SetCursorPosition(
                Position.X,
                Position.Y
                );
            if (!IsActive)Console.ForegroundColor = (ConsoleColor)Color;
            else Console.ForegroundColor = (ConsoleColor)Colors.Active;
            Print.write((char)View);
            Console.ResetColor();
            Console.SetCursorPosition(
                cursorPosition.X,
                cursorPosition.Y
                );
        }
        public void ChangeAct()
        {
            isActive = !isActive;
        }
    }
}
