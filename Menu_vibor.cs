using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace _9_practos_zmeuka
{
    internal class Menu_vibor
    {
        public static void menu()
        {
            Console.WriteLine(" Игра змейка");
            Console.WriteLine(" Выберите дейтствие:");
            Console.WriteLine("-------------------");
            Console.WriteLine("  Играть");
            Console.WriteLine("  Выйти");

            strelki mun = new strelki();
            int MinPosition = 3;
            int MaxPosition = 4;
            mun.Show(MinPosition, MaxPosition);

            int pos = mun.Show(MinPosition, MaxPosition);


            if (pos == 3)
            {
                Zmeuka zm = new Zmeuka();
                zm.Zmeuki();               
            }
            else if (pos == 4)
            {
                Environment.Exit(0);
            }
        }
    }
}
