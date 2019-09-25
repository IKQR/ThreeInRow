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
        Position startPosition { get; set; }
        public Table(Size size)
        {
            Size = size;
            fill();
        }
        public void fill()
        {
            table = new Candy[Size.Height, Size.Width];
            for (Int32 i = 0; i < Size.Height; i++)
            {
                for (Int32 j = 0; j < Size.Width; j++)
                {
                    table[i, j] = new Candy(new Position(i, j), Candy.Colors.Red, Candy.Types.Hearth);
                }
            }
        }

        public void draw(Position start)
        {
            startPosition = start;
            for (Int32 i = 0; i < Size.Height; i++)
            {
                for (Int32 j = 0; j < Size.Width; j++)
                {
                    table[i, j].Position = new Position(
                        startPosition.X + j,
                        startPosition.Y + i
                        );
                    Console.SetCursorPosition(
                        table[i, j].Position.X,
                        table[i, j].Position.Y);
                    Console.ForegroundColor = (ConsoleColor)table[i, j].getColor();
                    Console.Write(table[i, j].getType());
                    Console.ResetColor();
                }
            }
        }
        public void draw()
        {
            startPosition = new Position(0,0);
            for (Int32 i = 0; i < Size.Height; i++)
            {
                for (Int32 j = 0; j < Size.Width; j++)
                {
                    table[i, j].Position = new Position(
                        startPosition.X + table[i, j].Position.X,
                        startPosition.Y + table[i, j].Position.Y
                        );
                    Console.SetCursorPosition(
                        table[i, j].Position.X,
                        table[i, j].Position.Y);
                    Console.ForegroundColor = (ConsoleColor)table[i, j].getColor();
                    Console.Write(table[i, j].getType());
                    Console.ResetColor();
                }
            }
        }
    }
}
