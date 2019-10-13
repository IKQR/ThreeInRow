using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;

namespace Element
{
    class Table
    {
        public Candy[,] table { get; set; }
        public Size Size { get; set; }
        Position startPosition = new Position(0, 0);
        public Table(Size size)
        {
            Size = size;
            fill();
        }
        public void fill()
        {
            Candy.Types t = Candy.Types.Hearth;
            table = new Candy[Size.Height, Size.Width];
            for (Int32 i = 0; i < Size.Height; i++)
            {
                for (Int32 j = 0; j < Size.Width; j++)
                {
                    if (i == 2) t = Candy.Types.Triangle;
                    table[i, j] = new Candy(new Position(i, j), Candy.Colors.Red, t);
                }
            }
        }
        public void draw(Position start)
        {
            Position CursorPosition = new Position(Console.CursorLeft, Console.CursorTop);
            startPosition = start;
            for (Int32 i = 0; i < Size.Height; i++)
            {
                for (Int32 j = 0; j < Size.Width; j++)
                {
                    table[i, j].Position = new Position(
                        startPosition.X + i,
                        startPosition.Y + j
                        );
                    Console.SetCursorPosition(
                        table[i, j].Position.X,
                        table[i, j].Position.Y);
                    Console.ForegroundColor = (ConsoleColor)table[i, j].getColor();
                    Console.Write(table[i, j].getType());
                    Console.ResetColor();
                }
            }
            Console.SetCursorPosition(CursorPosition.X, CursorPosition.Y);
        }
        public void draw()
        {
            draw(startPosition);
        }
        /*public Candy getCandy(Position pos)
        {
            return ;
        }*/
    }
}
