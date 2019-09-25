using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    static class Print
    {
        static public void write(string str, Int32 pouse = 0)
        {
            for (Int32 i = 0; i < str.Length; i++)
            {
                Console.Write(str[i]);
                System.Threading.Thread.Sleep(pouse);
            }
        }
        static public void writeLn(string str, Int32 pouse = 0)
        {
            for (Int32 i = 0; i < str.Length; i++)
            {
                Console.Write(str[i]);
                System.Threading.Thread.Sleep(pouse);
            }
            Console.WriteLine();
        }

    }
}
