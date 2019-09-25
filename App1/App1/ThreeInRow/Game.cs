using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;


namespace ThreeInRow
{
    static class Game
    { 
        private static Level level { get; set; }
        public static void Start()
        {
            Console.OutputEncoding = Encoding.UTF8;
            level = new Level();
            level.Start();
        }
        public static void Stop()
        {
            level.Stop();
        }
    }
}
