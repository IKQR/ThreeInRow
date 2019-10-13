using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeInRow
{
    public class Cursor
    {
        protected Point max { get; set; }
        protected Point min { get; set; }

        public Cursor(Point min, Point max)
        {
            this.max = max;
            this.min = min;
        }
        public Cursor(Point min, Size size)
        {
            this.min = min;
            max = new Point(min.X + size.Width - 1, min.Y + size.Height - 1);
        }
        public void Go(Direction dir, Point startPosition)
        {
            switch (dir)
            {
                case Direction.Up:
                    if (startPosition.Y > min.Y)
                        Console.SetCursorPosition(
                            startPosition.X,
                            startPosition.Y - 1
                            );
                    else goto default;
                    break;
                case Direction.Down:
                    if (startPosition.Y < max.Y)
                        Console.SetCursorPosition(
                            startPosition.X,
                            startPosition.Y + 1
                            );
                    else goto default;
                    break;
                case Direction.Left:
                    if (startPosition.X > min.X)
                        Console.SetCursorPosition(
                            startPosition.X - 1,
                            startPosition.Y
                            );
                    else goto default;
                    break;
                case Direction.Right:
                    if (startPosition.X < max.X)
                        Console.SetCursorPosition(
                            startPosition.X + 1,
                            startPosition.Y
                            );
                    else goto default;
                    break;
                default:
                    Console.SetCursorPosition(
                       startPosition.X,
                       startPosition.Y
                       );
                    break;
            }
        }
        public bool Live(Level lvl)
        {
            Point cursorPosition = new Point(
                Console.CursorLeft,
                Console.CursorTop
                );
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.UpArrow: Go(Direction.Up, cursorPosition); break;
                case ConsoleKey.DownArrow: Go(Direction.Down, cursorPosition); break;
                case ConsoleKey.RightArrow: Go(Direction.Right, cursorPosition); break;
                case ConsoleKey.LeftArrow: Go(Direction.Left, cursorPosition); break;
                case ConsoleKey.Enter:
                    Console.SetCursorPosition(cursorPosition.X, cursorPosition.Y);
                    lvl.Check(cursorPosition); goto enter;
                case ConsoleKey.Tab:
                    Console.SetCursorPosition(cursorPosition.X, cursorPosition.Y);
                    lvl.DrawCandys();
                    lvl.DrawFance();
                    break;
                case ConsoleKey.Escape: return false;
                default: Console.SetCursorPosition(cursorPosition.X, cursorPosition.Y); break;
            }
            lvl.Candys[
                cursorPosition.X - lvl.StartPosition.X,
                cursorPosition.Y - lvl.StartPosition.Y
                ].Draw();
        enter:
            return true;
        }
        public void Move(Level lvl, Point main)
        {
            onemore:
            Point cursorPosition = new Point(
                Console.CursorLeft,
                Console.CursorTop
                );
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    if(main.Y > min.Y)
                        lvl.Exchange(
                            main, 
                            new Point(main.X, main.Y - 1),
                            true);
                    else goto default;
                    break;
                case ConsoleKey.DownArrow:
                    if(main.Y < max.Y)
                        lvl.Exchange(
                            main, 
                            new Point(main.X, main.Y + 1),
                            true);
                    else goto default;
                    break;
                case ConsoleKey.RightArrow:
                    if(main.X < max.X)
                        lvl.Exchange(
                            main, 
                            new Point(main.X + 1, main.Y),
                            true);
                    else goto default;
                    break;
                case ConsoleKey.LeftArrow:
                    if(main.X > min.X)
                        lvl.Exchange(
                            main, 
                            new Point(main.X - 1, main.Y),
                            true);
                    else goto default;
                    break;
                case ConsoleKey.Tab:
                    Console.SetCursorPosition(cursorPosition.X, cursorPosition.Y);
                    lvl.DrawCandys();
                    lvl.DrawFance();
                    goto onemore;
                case ConsoleKey.Enter:
                    lvl.Candys[
                        main.X - lvl.StartPosition.X,
                        main.Y - lvl.StartPosition.Y
                        ].ChangeAct();
                    break;
                default:
                    lvl.Candys[
                cursorPosition.X - lvl.StartPosition.X,
                cursorPosition.Y - lvl.StartPosition.Y
                ].Draw();
                Console.SetCursorPosition(
                cursorPosition.X,
                cursorPosition.Y
                );
                    goto onemore;
            }
            
            Console.SetCursorPosition(
                cursorPosition.X,
                cursorPosition.Y
                );
        }
    }
}
