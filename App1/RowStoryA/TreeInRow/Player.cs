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
                startInfoBox.X,
                startInfoBox.Y+1
                );
            Print.write("Don't know how to play? -> press Space");

            Console.SetCursorPosition(
                startInfoBox.X,
                startInfoBox.Y + 2
                );
            Print.write("To ESCape the game -> press ESC");

            Console.SetCursorPosition(
                cursorPosition.X,
                cursorPosition.Y
                );
        }
        public void PrintScore()
        {
            Point cursorPosition = new Point(
                Console.CursorLeft,
                Console.CursorTop
                );

            Console.SetCursorPosition(
                startInfoBox.X+ "Score:".Length,
                startInfoBox.Y
                );
            Print.write(Score.ToString()+"   ");

            Console.SetCursorPosition(
                cursorPosition.X,
                cursorPosition.Y
                );
        }
        public void UpScore(int value)
        {
            Score += 50*value;
            PrintScore();
        }
        public string GetScore()
        {
            return Score.ToString();
        }
        public void HowToPlay()
        {
            Console.Clear();
            Print.writeLn("To play you should use only Arrows and enter.", 5);
            Print.writeLn("If you want to exchange the elements you should press Enter and chose a direction by using Arrows.", 5);
            Print.writeLn("When your Score rich 5000 you WON");
            Print.writeLn("Press any button to continue the game");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
