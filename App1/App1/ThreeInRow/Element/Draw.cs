using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Element
{
    static class Draw
    {
        public static char fanceUp = '\u2580';
        public static char fanceDown = '\u2584';
        public static char fanceLeft = '\u258C';
        public static char fanceRight = '\u2590';

        public static char cornerUR = '\u259B';
        public static char cornerUL = '\u259C';
        public static char cornerDR = '\u259F';
        public static char cornerDL = '\u2599';

        public static char block = '\u2588'; 

        public static void DrawFance(Int32 Width, Int32 Height)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            Console.Write(new string(fanceUp, Width));
            for (int j = 0; j < Height; j++)
            {
                Console.SetCursorPosition(0, j);
                Console.Write(fanceLeft);
                Console.SetCursorPosition(Width - 1, j);
                Console.Write(fanceRight);
            }
            Console.SetCursorPosition(0, Height - 1);
            for (int i = 0; i < Width; i++)
            {
                Console.Write(fanceDown);
            }
            DrawCorners(Width, Height);
            Console.ResetColor();
            Console.SetCursorPosition(0, Height);
        }
        public static void DrawCorners(Int32 Width, Int32 Height)
        {
            Console.SetCursorPosition(0,0);
            Console.Write(block);
            Console.SetCursorPosition(Width-1,0);
            Console.Write(block);
            Console.SetCursorPosition(0,Height-1);
            Console.Write(block);
            Console.SetCursorPosition(Width-1,Height-1);
            Console.Write(block);
        }
    }
}
