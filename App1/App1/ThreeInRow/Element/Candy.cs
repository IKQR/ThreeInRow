using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;

namespace Element
{
    class Candy
    {
        public enum Types
        {
            Square = '\u2588',
            Triangle = '\u25B2',
            Сircle = '\u25CF',
            Hearth = '\u2665',
            Fance = '\u2588',
            Empty = '\u0000'
        };
        public enum Colors
        {
            Active = ConsoleColor.White,
            Warning = ConsoleColor.Gray,
            //Chosen = ConsoleColor.Blue,
            Green = ConsoleColor.Green,
            Yellow = ConsoleColor.Yellow,
            Red = ConsoleColor.Red,
            Blue = ConsoleColor.Blue,
        };

        public bool IsActive = false;
        static short countActive = 0;
        public Position Position { get; set; }
        public Types Type { get; set; }
        Colors Color { get; set; }
        Colors TempColor { get; set; }
        public Candy(Position position, Colors color, Types type = Types.Square)
        {
            Position = position;
            Color = color;
            Type = type;
        }
        public char getType() => (char)Type;
        public void setType(Types t) => Type = t;  
        public ConsoleColor getColor() => (ConsoleColor)Color;
        public void setColor(Colors color)
        {
            Color = color;
        }
        public void ChangeAct()
        {
            if (IsActive == false) { TempColor = Color; setColor(Colors.Active); IsActive = true; countActive++; }
            else { setColor(TempColor); IsActive = false; countActive--; }
        }
        public static short getCountAct() => countActive;
        public static short nullCountAct() => countActive = 0;

    }
}
