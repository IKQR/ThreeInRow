using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public enum Direction
    {
        Right,
        Left,
        Up,
        Down
    }
    public class Position
    {
        public Int32 X;
        public Int32 Y;
        public Position(Int32 x, Int32 y)
        {
            Y = y;
            X = x;
        }
    }
    public static class Print
    {
        static public void write(string str, Int32 pouse = 0)
        {
            for (Int32 i = 0; i < str.Length; i++)
            {
                Console.Write(str[i]);
                System.Threading.Thread.Sleep(pouse);
            }
        }
        static public void writeLn(string str, Int32 pouse = 0)
        {
            for (Int32 i = 0; i < str.Length; i++)
            {
                Console.Write(str[i]);
                System.Threading.Thread.Sleep(pouse);
            }
            Console.WriteLine();
        }

    }
    public class Size
    {
        public Int32 Height { get; set; }
        public Int32 Width { get; set; }

        public Size(Int32 width, Int32 height)
        {
            Width = width;
            Height = height;
        }
        public Size(Int32 size)
        {
            Height = size;
            Width = size;
        }
    }
}
