using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeInRow
{
    public class Player
    {
        private Int64 score;
        protected Int64 Score
        {
            get
            {
                return score;
            }
            set
            {
                if (value > 0) score = value;
                else score = 0;
            }
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Replace(" ", "") != "")
                    name = value;
                else name = "Player1";
            }
        }
        private Point startInfoBox { get; set; }
        public Player(string name, Point startInfoBox)
        {
            Name = name;
            Score = 0;
            this.startInfoBox = startInfoBox;
        }
        public void PrintInfo()
        {
            Point cursorPosition = new Point(
                Console.CursorLeft,
                Console.CursorTop
                );
            Console.SetCursorPosition(
                startInfoBox.X,
                startInfoBox.Y
                );

            Print.write("Score:" + Score);

            Console.SetCursorPosition(
                cursorPosition.X,
                cursorPosition.Y
                );
        }
        public void UpScore(int value)
        {
            Score += 50*value;
            PrintInfo();
        }
        public string GetScore()
        {
            return Score.ToString();
        }
    }
}
