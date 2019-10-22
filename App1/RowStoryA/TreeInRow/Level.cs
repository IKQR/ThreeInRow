using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TreeInRow
{
    public class Table
    {
        protected Size size;
        public Size Size
        {
            get
            {
                return size;
            }
            set
            {

            }
        }
        protected Point startPosition;
        public Point StartPosition
        {
            get
            {
                return startPosition;
            }
            set
            {
                if (value.X > 0 && value.Y > 0)
                    startPosition = value;
            }
        }
        public Table(Size size, Point startPosition)
        {
            this.size = size;
            this.startPosition = startPosition;
        }
        
    }
    public class Level : Table
    {
        public Candy[,] Candys { get; set; }
        protected Player player { get; set; }
        public Level(Size size, Point startPosition, Player player): base(size,startPosition)
        {
            this.player = player;
            Console.SetCursorPosition(
                startPosition.X,
                startPosition.Y
                );
            Fill();
            DeleteRightRows();
        }
        private void Fill()
        {
            Rnd rand = new Rnd();
            Symbols s;
            Colors c = new Colors();
            Candys = new Candy[Size.Width, Size.Height];
            for(int i = 0; i < Size.Width; i++)
            {
                for(int j = 0; j < Size.Height; j++)
                {
                    s = rand.RSymbol();
                    switch(s)
                    {
                        case Symbols.Square: c = Colors.Blue; break;
                        case Symbols.Triangle: c = Colors.Yellow; break;
                        case Symbols.Hearth: c = Colors.Red; break;
                        case Symbols.Сircle: c = Colors.Green; break;
                    }
                    Candys[i, j] = new Candy(
                        new Point(
                            StartPosition.X + i,
                            StartPosition.Y + j
                            ),
                        c,
                        s
                        );
                }
            }
        }
        private void ReFill(bool all)
        {
            Rnd rand = new Rnd();
            Symbols s = new Symbols();
            Colors c = new Colors();
            for (int i = Size.Width - 1; i >= 0; i--)
            {
                for (int j = Size.Height - 1; j >= 0; j--)
                    if (Candys[i, j].View == Symbols.Empty || all)
                    {
                        s = rand.RSymbol();
                        switch (s)
                        {
                            case Symbols.Square: c = Colors.Blue; break;
                            case Symbols.Triangle: c = Colors.Yellow; break;
                            case Symbols.Hearth: c = Colors.Red; break;
                            case Symbols.Сircle: c = Colors.Green; break;
                        }
                        Candys[i, j] = new Candy(
                            new Point(
                                StartPosition.X + i,
                                StartPosition.Y + j
                                ),
                            c,
                            s
                            );
                        Candys[i, j].Draw(100);
                        
                    }
            }
        }
        private bool DrawFirstLine()
        {
            bool flag = false;
            Rnd rand = new Rnd();
            Symbols s = new Symbols();
            Colors c = new Colors();
            for (int x = Size.Width - 1; x >= 0; x--)
                if (Candys[x, 0].View == Symbols.Empty)
                {
                    flag = true;
                    s = rand.RSymbol();
                    switch (s)
                    {
                        case Symbols.Square: c = Colors.Blue; break;
                        case Symbols.Triangle: c = Colors.Yellow; break;
                        case Symbols.Hearth: c = Colors.Red; break;
                        case Symbols.Сircle: c = Colors.Green; break;
                    }
                    Candys[x, 0] = new Candy(
                        new Point(
                            StartPosition.X + x,
                            StartPosition.Y
                            ),
                        c,
                        s
                        );
                    Candys[x , 0].Draw(0);
                }
            return flag;
        }
        private bool FillFirstLine()
        {
            bool flag = false;
            Rnd rand = new Rnd();
            Symbols s = new Symbols();
            Colors c = new Colors();
            for (int x = Size.Width - 1; x >= 0; x--)
                if (Candys[x, 0].View == Symbols.Empty)
                {
                    flag = true;
                    s = rand.RSymbol();
                    switch (s)
                    {
                        case Symbols.Square: c = Colors.Blue; break;
                        case Symbols.Triangle: c = Colors.Yellow; break;
                        case Symbols.Hearth: c = Colors.Red; break;
                        case Symbols.Сircle: c = Colors.Green; break;
                    }
                    Candys[x, 0] = new Candy(
                        new Point(
                            StartPosition.X + x,
                            StartPosition.Y
                            ),
                        c,
                        s
                        );
                    //Candys[x, 0].Draw(0);
                }
            return flag;
        }
        /* отрисовка элементов игры */
        public void DrawCandys()
        {
            DrawCandys(StartPosition.Y,StartPosition.Y+Size.Height);
        }
        public void DrawCandys(int start)
        {
            DrawCandys(start, start);
        }
        public void DrawCandys(int start, int finish)
        {
            Point CurorPosition = new Point(
                Console.CursorLeft,
                Console.CursorTop
                );
            finish = finish < start ? start : finish;
            finish = finish > Size.Height ? Size.Height : finish;
            for (int i = start-1; i < finish; i++)
            {
                for (int j = 0; j < Size.Width; j++)
                {
                    if (!Candys[i, j].IsActive)
                        Console.ForegroundColor = (ConsoleColor)Candys[i, j].Color;
                    else Console.ForegroundColor = (ConsoleColor)Colors.Active;
                    Console.SetCursorPosition(
                        Candys[i, j].Position.X,
                        Candys[i, j].Position.Y
                        );
                    Candys[i, j].Draw();
                    Console.ResetColor();
                }
            }
            Console.SetCursorPosition(
                CurorPosition.X,
                CurorPosition.Y
                );
        }
        public void DrawFance()
        {
            Point CurorPosition = new Point(
                Console.CursorLeft,
                Console.CursorTop
                );

            Console.SetCursorPosition(StartPosition.X-1, StartPosition.Y-1);
            Print.write((char)Symbols.Block);
            Console.SetCursorPosition(Size.Width+StartPosition.X, StartPosition.Y-1);
            Print.write((char)Symbols.Block);
            Console.SetCursorPosition(StartPosition.X - 1, Size.Height+StartPosition.Y);
            Print.write((char)Symbols.Block);
            Console.SetCursorPosition(Size.Width+StartPosition.X, Size.Height+StartPosition.Y);
            Print.write((char)Symbols.Block);

            for(int i = 0; i < Size.Width; i++)
            {
                Console.SetCursorPosition(
                    StartPosition.X + i,
                    StartPosition.Y - 1
                    );
                Print.write((char)Symbols.FanceUp);
                Console.SetCursorPosition(
                    StartPosition.X + i,
                    StartPosition.Y + Size.Height
                    );
                Print.write((char)Symbols.FanceDown);
                Console.SetCursorPosition(
                    StartPosition.X - 1,
                    StartPosition.Y + i
                    );
                Print.write((char)Symbols.FanceLeft);
                Console.SetCursorPosition(
                    StartPosition.X + Size.Width,
                    StartPosition.Y + i
                    );
                Print.write((char)Symbols.FanceRight);
            }
            
            Console.SetCursorPosition(
                CurorPosition.X,
                CurorPosition.Y
                );
            //System.Threading.Thread.Sleep(100);
        }
        /* Работа с элементами во время нажатия Enter */
        public void Activate(Point pos)
        {
            int x = pos.X - StartPosition.X;
            int y = pos.Y - StartPosition.Y;
            if(!Candys[x, y].IsActive) Candys[x, y].ChangeAct();
        }
        public void DisActivate(Point pos)
        {
            int x = pos.X - StartPosition.X;
            int y = pos.Y - StartPosition.Y;
            if(Candys[x, y].IsActive) Candys[x, y].ChangeAct();
        }
        public void Exchange(Point one, Point two, bool isDraw = true)
        {
            Colors tempColor = Candys[
            one.X - StartPosition.X,
            one.Y - StartPosition.Y].Color;
            Candys[
            one.X - StartPosition.X,
            one.Y - StartPosition.Y].Color = Candys[
            two.X - StartPosition.X,
            two.Y - StartPosition.Y].Color;
            Candys[
            two.X - StartPosition.X,
            two.Y - StartPosition.Y].Color = tempColor;

            Symbols tempView = Candys[
            one.X - StartPosition.X,
            one.Y - StartPosition.Y].View;
            Candys[
            one.X - StartPosition.X,
            one.Y - StartPosition.Y].View = Candys[
            two.X - StartPosition.X,
            two.Y - StartPosition.Y].View;
            Candys[
            two.X - StartPosition.X,
            two.Y - StartPosition.Y].View = tempView;
            DisActivate(one);
            DisActivate(two);
            if (isDraw)
            {
                Candys[
                one.X - StartPosition.X,
                one.Y - StartPosition.Y].Draw();
                Candys[
                two.X - StartPosition.X,
                two.Y - StartPosition.Y].Draw();
            }
            
        }
        public void Down(int pouse, bool isDraw = true)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int x = 0; x < this.Size.Width; x++)
                {
                    for (int y = 0; y < this.Size.Height - 1; y++)
                    {
                        if (this.Candys[x, y + 1].View == Symbols.Empty && this.Candys[x, y].View != Symbols.Empty)
                        {
                            //Console.SetCursorPosition(this.Candys[x, y + 1].Position.X, this.Candys[x, y + 1].Position.Y);
                            this.Exchange(this.Candys[x, y + 1].Position, this.Candys[x, y].Position, isDraw);
                            flag = true;
                        }
                    }
                    System.Threading.Thread.Sleep(pouse);
                }
            }
        }
        public void Check(Point pos)
        {
            
            Candy[,] temp = (Candy[,])Candys.Clone();
            Cursor cursor = new Cursor(Candys[0,0].Position, Size);
            Activate(pos);
            cursor.Move(this, pos);
            DrawCandys();
        }
        /* Проверка и удаление подходящих элементов массива*/
        public bool LookForRows()
        {
            bool flag = false;
        onceMore:
            for (var y = 0; y < Size.Height; y++)
            {
                var k = 0;
                for (var x = 0; x < Size.Width - 2; x++)
                {
                    if (Candys[x, y].View == Symbols.Empty) continue;
                    while (x + k + 1 < Size.Width)
                    {
                        if (Candys[x + k, y].View != Candys[x + k + 1, y].View) break;
                        k++;
                        //x++;
                    }

                    if (k > 1)
                    {
                        for (var i = 0; i <= k; i++)
                        {
                            Candys[x + i, y].Color = Colors.Warning;
                            Candys[x + i, y].Draw();
                        }

                        System.Threading.Thread.Sleep(500);
                        for (var i = 0; i <= k; i++)
                        {
                            Candys[x + i, y].View = Symbols.Empty;
                            if (i > 1) player.UpScore(1);
                        }

                        x += k + 1;
                        flag = true;
                    }
                    //player.UpScore(k-2);
                    k = 0;
                }
            }
            for (var x = 0; x < Size.Width; x++)
            {
                var k = 0;
                for (var y = 0; y < Size.Height - 2; y++)
                {
                    if (Candys[x, y].View == Symbols.Empty) continue;
                    while (y + k + 1 < Size.Height)
                    {
                        if (Candys[x, y+k].View != Candys[x, y + k + 1].View) break;
                        k++;
                        //x++;
                    }

                    if (k > 1)
                    {
                        for (var i = 0; i <= k; i++)
                        {
                            Candys[x, y + i].Color = Colors.Warning;
                            Candys[x, y + i].Draw();
                        }

                        System.Threading.Thread.Sleep(500);
                        for (var i = 0; i <= k; i++)
                        {
                            Candys[x, y + i].View = Symbols.Empty;
                            if(i > 1) player.UpScore(1);
                        }

                        y += k + 1;
                        flag = true;
                    }
                    k = 0;
                }
            }
            //DrawCandys();
            Down(30);
            if (DrawFirstLine())
            {
                Down(30);
                goto onceMore;
            }
            //DrawCandys();
            //Console.ReadKey();
            return flag;
        }
        protected void DeleteRightRows()
        {
        onceMore:
            for (var y = 0; y < Size.Height; y++)
            {
                var k = 0;
                for (var x = 0; x < Size.Width - 2; x++)
                {
                    if (Candys[x, y].View == Symbols.Empty) continue;
                    while (x + k + 1 < Size.Width)
                    {
                        if (Candys[x + k, y].View != Candys[x + k + 1, y].View) break;
                        k++;
                        //x++;
                    }

                    if (k > 1)
                    {
                        for (var i = 0; i <= k; i++)
                        {
                            Candys[x + i, y].Color = Colors.Warning;
                            //Candys[x + i, y].Draw();
                        }

                        //System.Threading.Thread.Sleep(500);
                        for (var i = 0; i <= k; i++)
                        {
                            Candys[x + i, y].View = Symbols.Empty;
                        }

                        x += k + 1;
                    }

                    k = 0;
                }
            }
            for (var x = 0; x < Size.Width; x++)
            {
                var k = 0;
                for (var y = 0; y < Size.Height - 2; y++)
                {
                    if (Candys[x, y].View == Symbols.Empty) continue;
                    while (y + k + 1 < Size.Height)
                    {
                        if (Candys[x, y + k].View != Candys[x, y + k + 1].View) break;
                        k++;
                        //x++;
                    }

                    if (k > 1)
                    {
                        for (var i = 0; i <= k; i++)
                        {
                            Candys[x, y + i].Color = Colors.Warning;
                            //Candys[x, y + i].Draw();
                        }

                        //System.Threading.Thread.Sleep(500);
                        for (var i = 0; i <= k; i++)
                        {
                            Candys[x, y + i].View = Symbols.Empty;
                        }

                        y += k + 1;
                    }

                    k = 0;
                }
            }
            //DrawCandys();
            Down(0, false);
            if (FillFirstLine())
            {
                Down(0, false);
                goto onceMore;
            }
            //DrawCandys();
            //Console.ReadKey();
        }
    }
}
