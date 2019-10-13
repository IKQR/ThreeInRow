using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TreeInRow
{
    public class Table
    {
        public Candy[,] Candys { get; set; }
        private Size size;
        public Size Size
        {
            get
            {
                return size;
            }
            set
            {
                if (value.Width == value.Height)
                    size = value;
            }
        }
        private Point startPosition;
        public Point StartPosition
        {
            get
            {
                return startPosition;
            }
            set
            {
                if (value.X > 0 && value.Y > 0)
                    startPosition = value;
            }
        }
    }
    public class Level : Table
    {
        public Level(Size size, Point startPosition)
        {
            Size = size;
            StartPosition = startPosition;
            Console.SetCursorPosition(
                startPosition.X,
                startPosition.Y
                );
            Fill();
        }
        private void Fill()
        {
            Rnd rand = new Rnd();
            Candys = new Candy[Size.Width, Size.Height];
            for(int i = 0; i < Size.Width; i++)
            {
                for(int j = 0; j < Size.Height; j++)
                {
                    Candys[i, j] = new Candy(
                        new Point(
                            StartPosition.X + i,
                            StartPosition.Y + j
                            ),
                        rand.RColor(),
                        rand.RSymbol()
                        );
                }
            }
        }
        public void DrawCandys()
        {
            DrawCandys(StartPosition.Y,StartPosition.Y+Size.Height);
        }
        public void DrawCandys(int start)
        {
            DrawCandys(start, start);
        }
        public void DrawCandys(int start, int finish)
        {
            Point CurorPosition = new Point(
                Console.CursorLeft,
                Console.CursorTop
                );
            finish = finish < start ? start : finish;
            finish = finish > Size.Height ? Size.Height : finish;
            for (int i = start-1; i < finish; i++)
            {
                for (int j = 0; j < Size.Width; j++)
                {
                    if (!Candys[i, j].IsActive)
                        Console.ForegroundColor = (ConsoleColor)Candys[i, j].Color;
                    else Console.ForegroundColor = (ConsoleColor)Colors.Active;
                    Console.SetCursorPosition(
                        Candys[i, j].Position.X,
                        Candys[i, j].Position.Y
                        );
                    Candys[i, j].Draw();
                    Console.ResetColor();
                }
            }
            Console.SetCursorPosition(
                CurorPosition.X,
                CurorPosition.Y
                );
        }
        public void DrawFance()
        {
            Point CurorPosition = new Point(
                Console.CursorLeft,
                Console.CursorTop
                );

            Console.SetCursorPosition(StartPosition.X-1, StartPosition.Y-1);
            Print.write((char)Symbols.Block);
            Console.SetCursorPosition(Size.Width+StartPosition.X, StartPosition.Y-1);
            Print.write((char)Symbols.Block);
            Console.SetCursorPosition(StartPosition.X - 1, Size.Height+StartPosition.Y);
            Print.write((char)Symbols.Block);
            Console.SetCursorPosition(Size.Width+StartPosition.X, Size.Height+StartPosition.Y);
            Print.write((char)Symbols.Block);

            for(int i = 0; i < Size.Width; i++)
            {
                Console.SetCursorPosition(
                    StartPosition.X + i,
                    StartPosition.Y - 1
                    );
                Print.write((char)Symbols.FanceUp);
                Console.SetCursorPosition(
                    StartPosition.X + i,
                    StartPosition.Y + Size.Height
                    );
                Print.write((char)Symbols.FanceDown);
                Console.SetCursorPosition(
                    StartPosition.X - 1,
                    StartPosition.Y + i
                    );
                Print.write((char)Symbols.FanceLeft);
                Console.SetCursorPosition(
                    StartPosition.X + Size.Width,
                    StartPosition.Y + i
                    );
                Print.write((char)Symbols.FanceRight);
            }
            
            Console.SetCursorPosition(
                CurorPosition.X,
                CurorPosition.Y
                );
            //System.Threading.Thread.Sleep(100);
        }
        public void Activate(Point pos)
        {
            int x = pos.X - StartPosition.X;
            int y = pos.Y - StartPosition.Y;
            if(!Candys[x, y].IsActive) Candys[x, y].ChangeAct();
        }
        public void Exchange(Point one, Point two, bool flag2 = false, bool flag1 = false)
        {
            Colors tempColor = Candys[
            one.X - StartPosition.X,
            one.Y - StartPosition.Y].Color;
            Candys[
            one.X - StartPosition.X,
            one.Y - StartPosition.Y].Color = Candys[
            two.X - StartPosition.X,
            two.Y - StartPosition.Y].Color;
            Candys[
            two.X - StartPosition.X,
            two.Y - StartPosition.Y].Color = tempColor;

            Symbols tempView = Candys[
            one.X - StartPosition.X,
            one.Y - StartPosition.Y].View;
            Candys[
            one.X - StartPosition.X,
            one.Y - StartPosition.Y].View = Candys[
            two.X - StartPosition.X,
            two.Y - StartPosition.Y].View;
            Candys[
            two.X - StartPosition.X,
            two.Y - StartPosition.Y].View = tempView;
            if(!flag1)Candys[
            one.X - StartPosition.X,
            one.Y - StartPosition.Y].ChangeAct();
            if(!flag2)Candys[
            two.X - StartPosition.X,
            two.Y - StartPosition.Y].ChangeAct();
            Candys[
            one.X - StartPosition.X,
            one.Y - StartPosition.Y].Draw();
            Candys[
            two.X - StartPosition.X,
            two.Y - StartPosition.Y].Draw();
            
        }
        public void Check(Point pos) 
        {
            Cursor cursor = new Cursor(Candys[0,0].Position, Size);
            Activate(pos);
            cursor.Move(this, pos);
        }
        public bool isNear(Point one, Point two)
        {
            if (Math.Abs(one.X - two.X) == 1 && Math.Abs(one.Y - two.Y) == 1)
                return true;
            return false;
        }
    }
}
