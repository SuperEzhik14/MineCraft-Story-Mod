using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarsWars
{
    class Map
    {
        
        public int GamePlay;
        public char[,] masiv = new char[25, 40];
        public Map()
        {
            for (int i = 0; i < masiv.GetLength(0); i++)
            {
                for (int f = 0; f < masiv.GetLength(1); f++)
                {
                    masiv[i, f] = ' ';
                }
            }
            Console.WriteLine("\n\t\t\t      10 ULTRA HARD   20 HARD   35 MEDIUM   50 EASY");
            Console.WriteLine("\n\n\t\t\t\t\t   Выбирите Сложность");
            Console.Write("\t\t\t\t\t\t   ");
            GamePlay = int.Parse(Console.ReadLine());
        }

    }
}
