using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_practos_zmeuka
{
    internal class strelki
    {
        public int Show(int MinPosition, int MaxPosition)
        {
            Console.CursorVisible = false;
            int pos = 3;
            ConsoleKeyInfo key;

            do
            {
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("=>");

                key = Console.ReadKey();

                Console.SetCursorPosition(0, pos);
                Console.WriteLine("  ");

                if (key.Key == ConsoleKey.UpArrow && pos != MinPosition)
                    pos--;

                else if (key.Key == ConsoleKey.DownArrow && pos != MaxPosition)
                    pos++;
                else if (key.Key == ConsoleKey.Escape)
                    return -1;

            } while (key.Key != ConsoleKey.Enter);

            return pos;
        }
    }
}