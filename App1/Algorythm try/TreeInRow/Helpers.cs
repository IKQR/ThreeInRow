using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeInRow
{
    public enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }
    public enum Symbols
    {
        FanceUp = '\u2580',
        FanceDown = '\u2584',
        FanceLeft = '\u258C',
        FanceRight = '\u2590',

        CornerUR = '\u259B',
        CornerUL = '\u259C',
        CornerDR = '\u259F',
        CornerDL = '\u2599',

        Block = '\u2588',

        Square = '\u25A0',
        Triangle = '\u25B2',
        Сircle = '\u25CF',
        Hearth = '\u2665',

        Empty = '\u0000'
    }
    public enum Elements
    {
        Fance,
        Figure
    }
    public enum Colors
    {
        Active = ConsoleColor.Gray,
        Warning = ConsoleColor.Cyan,
        Green = ConsoleColor.Green,
        Yellow = ConsoleColor.Yellow,
        Red = ConsoleColor.Red,
        Blue = ConsoleColor.Blue,
    }

    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    public struct Size
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Size(int width, int heigh)
        {
            Width = width;
            Height = heigh;
        }
        public Size(int side)
        {
            Width = side;
            Height = side;
        }
    }

    public static class Print
    {
        public static void write(char str, Int32 pouse = 0)
        {
            Console.Write(str);
            System.Threading.Thread.Sleep(pouse);
        }
        public static void write(string str, Int32 pouse = 0)
        {
            for (Int32 i = 0; i < str.Length; i++)
            {
                write(str[i], pouse);
            }
        }
        public static void writeLn(string str, Int32 pouse = 0)
        {
            for (Int32 i = 0; i < str.Length; i++)
            {
                Console.Write(str[i]);
                System.Threading.Thread.Sleep(pouse);
            }
            Console.WriteLine();
        }
    }
    public class Rnd : Random
    {
        public Colors RColor()
        {
            switch((int)Next(1, 4))
            {
                case 1: return Colors.Yellow;
                case 2: return Colors.Blue;
                case 3: return Colors.Red;
                case 4: return Colors.Green;
            }
            return Colors.Warning;
        }
        public Symbols RSymbol()
        {
            switch ((int)Next(1, 4))
            {
                case 1: return Symbols.Square;
                case 2: return Symbols.Triangle;
                case 3: return Symbols.Hearth;
                case 4: return Symbols.Сircle;
            }
            return Symbols.Block;
        }
    }
}
