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
            Fance = '\u2588'
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
        Types Type { get; set; }
        Colors Color { get; set; }
        public Position Position { get; set; }
        public bool IsActive = false;
        /*
        public Candy(Position position, Colors color)
        {
            Position = position;
            Color = color;
            Type = Types.Square;
        }
        */
        public Candy(Position position, Colors color, Types type = Types.Square)
        {
            Position = position;
            Color = color;
            Type = type;
        }
        public char getType()
        {
            return (char)Type;
        }
        public ConsoleColor getColor()
        {
            return (ConsoleColor)Color;
        }
    }
}
