using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Element;
using Control;

namespace ThreeInRow
{
    class Level
    {
        private Table table { get; set; }
        Size size = new Size(4);
        protected bool isPlay = false;
        protected bool isPoused = false;
        protected Position textPosition { get; set; }

        public Level()
        {
            table = new Table(size);
        }
        public void Start()
        {
            isPlay = true;
            Draw();
            LevelControl levelControl = new LevelControl(table);
            while (isPlay)
            {
                levelControl.Do();
            }
        }
        public bool levelUp(Int32 step = 1)
        {
            if (isPlay)
            {
                table = new Table(new Size(table.Size.Height + step, table.Size.Height + step));
            }
            else return false;
            return true;
        }
        public bool Pouse()
        {
            if(isPlay) return isPoused = true;
            return false;
        }
        public bool Resume()
        {
            if(isPoused && isPlay) return !(isPoused = false);
            return false;
        }
        public void Stop()
        {
            isPlay = false;
            Console.Clear();
        }
        protected void Draw()
        {
            Console.Clear();
            Element.Draw.DrawFance(table.Size.Width + 2, table.Size.Height + 2);
            table.draw(new Position(1, 1));
            Console.SetCursorPosition(1,1);
        }
    }
}
