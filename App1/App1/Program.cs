using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Element;
using ThreeInRow;

namespace App1
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreeInRow.Game.Start();
            Console.ReadKey();
            ThreeInRow.Game.Stop();
            Console.ReadKey();
           // _ = Console.ReadKey();
        }
    }
}
