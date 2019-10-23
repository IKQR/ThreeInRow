using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeInRow
{
    public class Game
    {
        protected Level lvl { get; set; }
        protected Player player { get; set; }
        protected bool gamePlay { get; set; }
        public Game()
        {
            SetConfig();
            int printPouse = 10;
            Print.writeLn("Hello, Player! What is your name?", printPouse);
            string playerName = Console.ReadLine();
            Console.Clear();
            if (playerName.Replace(" ", "") == "")
                Print.writeLn("OK, I'll call you Player :)", printPouse);
            Print.writeLn("So " + playerName + ",if you want to play the Game you should enter the size of your level (bigger than 4, but less than 8)", printPouse);
            int levelSize;
        onceMore:
            try { levelSize = int.Parse(Console.ReadLine()); }
            catch
            {
                Console.Clear();
                Print.writeLn(playerName + ", you shold try again.",printPouse);
                Print.writeLn("If you don't want to play: you just can enter 0 ",printPouse);
                goto onceMore;
            }
            if (levelSize == 0) gamePlay = false;
            else if (levelSize > 8 || levelSize < 5)
            {
                Console.Clear();
                Print.writeLn("It seems to me that I asked you to enter the num bigger than 4, but less than 8.", printPouse);
                Print.writeLn(playerName + ", you shold try again.", printPouse);
                goto onceMore;
            }
            gamePlay = true;
            player = new Player(
                playerName, 
                new Point(
                    levelSize + 2 + 3, 
                    1)
                );
            lvl = new Level(
                new Size(levelSize),
                new Point(1,1),
                player);
            Console.Clear();
        }
        public void Start()
        {
            if (!gamePlay || lvl.Size.Width == 0) goto played;
            lvl.DrawFance();
            lvl.DrawCandys();
            player.PrintInfo();
            Cursor cursor = new Cursor(lvl.Candys[0, 0].Position, lvl.Size);
            Console.SetCursorPosition(
                lvl.StartPosition.X,
                lvl.StartPosition.Y
                );
            while (cursor.Live(lvl) && Int64.Parse(player.GetScore()) < 5000);
            played: GoodBye();
        }

        protected void SetConfig()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WindowHeight = 10;
            Console.WindowWidth = 110;
            //Console.
        }
        protected void GoodBye()
        {
            Console.Clear();
            if(gamePlay)
            {
                Print.write(player.Name, 50);
                if(Int64.Parse(player.GetScore()) < 5000)
                    Print.writeLn(", you score is "+ player.GetScore(), 100);
                else Print.writeLn(",GOOD JOB! YOU WON THIS GAME" , 100);
                Print.writeLn("Thank you for playing!", 100);
            }
            Print.writeLn("Goodbye.......", 100);
            //Print.write("", 1000);
        }
    }
}
