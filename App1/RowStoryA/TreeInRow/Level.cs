using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Fill();
        }
        private void Fill()
        {
            Rnd rand = new Rnd();
            Candys = new Candy[Size.Height, Size.Width];
            for(int i = 0; i < Size.Height; i++)
            {
                for(int j = 0; j < Size.Width; j++)
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
            Point CurorPosition = new Point(
                Console.CursorLeft, 
                Console.CursorTop
                );
            for (int i = 0; i < Size.Height; i++)
            {
                for (int j = 0; j < Size.Width; j++)
                {
                    Console.SetCursorPosition(
                        Candys[i,j].Position.X,
                        Candys[i,j].Position.Y
                        );
                    Candys[i, j].Draw();
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

            Console.SetCursorPosition(0, 0);
            Print.write((char)Symbols.Block);
            Console.SetCursorPosition(Size.Width+1, 0);
            Print.write((char)Symbols.Block);
            Console.SetCursorPosition(0, Size.Height+1);
            Print.write((char)Symbols.Block);
            Console.SetCursorPosition(Size.Width+1, Size.Height+1);
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
        }
    }
}
