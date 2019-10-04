using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Element;
using Control;

namespace Control
{
    public static class Keys
    {
        public const System.ConsoleKey Right = System.ConsoleKey.RightArrow;
        public const System.ConsoleKey Left = System.ConsoleKey.LeftArrow;
        public const System.ConsoleKey Up = System.ConsoleKey.UpArrow;
        public const System.ConsoleKey Down = System.ConsoleKey.DownArrow;
        public const System.ConsoleKey Enter = System.ConsoleKey.Enter;
        public const System.ConsoleKey Non = System.ConsoleKey.Delete;
    }
    public static class CursorControl
    {
        public static ConsoleKey getKey()
        {
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case Keys.Right: goto yes;
                case Keys.Up: goto yes;
                case Keys.Left: goto yes;
                case Keys.Down: goto yes;
                case Keys.Enter: goto yes;
                default: goto no;
            }
        yes: return key;
        no: return Keys.Non;
        }
        public static void CursorGo(Direction Dir, Position min, Position max, Position CursorPosition)
        {
            
            //CursorPosition.X;
            switch (Dir)
            {
                case Direction.Down:
                    if (CursorPosition.Y < max.Y)
                        Console.SetCursorPosition(
                            CursorPosition.X,
                            ++CursorPosition.Y
                            );
                    else goto default;
                    break;
                case Direction.Up:
                    if (CursorPosition.Y > min.Y)
                        Console.SetCursorPosition(
                            CursorPosition.X,
                            --CursorPosition.Y
                            );
                    else goto default;
                    break;
                case Direction.Right:
                    if (CursorPosition.X < max.X)
                        Console.SetCursorPosition(
                            ++CursorPosition.X,
                            CursorPosition.Y
                            );
                    else goto default;
                    break;
                case Direction.Left:
                    if (CursorPosition.X > min.X)
                        Console.SetCursorPosition(
                            --CursorPosition.X,
                            CursorPosition.Y
                            );
                    else goto default;
                    break;
                default:
                    Console.SetCursorPosition(
                            CursorPosition.X,
                            CursorPosition.Y
                            );
                    break;
            }
        }
    }
    class LevelControl
    {
        Table level { get; set; }
        Position StartPosition { get; set; }
        Position LastPosition { get; set; }
        Position candyPosition { get; set; }
        public LevelControl(Table lvl)
        {
            level = lvl;
            StartPosition = lvl.table[0, 0].Position;
            LastPosition = lvl.table[lvl.Size.Width-1, lvl.Size.Width-1].Position;
        }
        public void Cursor()
        {
            Position CursorPosition = new Position(Console.CursorLeft, Console.CursorTop);
            switch (CursorControl.getKey())
            {
                case Keys.Right:
                    CursorControl.CursorGo(Direction.Right, StartPosition, LastPosition, CursorPosition);
                    break;
                case Keys.Left:
                    CursorControl.CursorGo(Direction.Left, StartPosition, LastPosition, CursorPosition);
                    break;
                case Keys.Up:
                    CursorControl.CursorGo(Direction.Up, StartPosition, LastPosition, CursorPosition);
                    break;
                case Keys.Down:
                    CursorControl.CursorGo(Direction.Down, StartPosition, LastPosition, CursorPosition);
                    break;
                case Keys.Enter:
                    {
                        Candy candy = level.table[CursorPosition.X - StartPosition.X, CursorPosition.Y - StartPosition.Y];
                        level.table[CursorPosition.X - StartPosition.X, CursorPosition.Y - StartPosition.Y].ChangeAct();
                        
                        if (Candy.getCountAct() == 1) candyPosition = level.table[CursorPosition.X - StartPosition.X, CursorPosition.Y - StartPosition.Y].Position;
                        if (Candy.getCountAct() == 2)
                        {
                            Candy temp = level.table[CursorPosition.X - StartPosition.X, CursorPosition.Y - StartPosition.Y];
                            level.table[CursorPosition.X - StartPosition.X, CursorPosition.Y - StartPosition.Y].setType(
                                level.table[candyPosition.X - StartPosition.X, candyPosition.Y - StartPosition.Y].Type
                                );
                            level.table[CursorPosition.X - StartPosition.X, CursorPosition.Y - StartPosition.Y].ChangeAct();
                            level.table[candyPosition.X - StartPosition.X, candyPosition.Y - StartPosition.Y].setType(temp.Type);
                            Candy.nullCountAct();
                            level.table[candyPosition.X - StartPosition.X, candyPosition.Y - StartPosition.Y].ChangeAct();
                        }
                        Console.SetCursorPosition(CursorPosition.X, CursorPosition.Y);
                    }
                    break;
                default: Console.SetCursorPosition(CursorPosition.X, CursorPosition.Y); break;
            }
            level.draw();
        }
        protected void Exchange(Candy candy)
        {
            
        }
        public void Do()
        {
            while(true)
            {
                level.draw();
                Cursor();
            }
        }
    }
}
