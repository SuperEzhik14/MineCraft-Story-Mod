using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Geometridar
{
    class Game
    {
        private Squar sqr;
        private Map map;
        private Random r = new Random();
        public Game()
        {
            sqr = new Squar();
            map = new Map();
            while (true)
            {
                if (Console.KeyAvailable == true)
                {
                    PlayerSwitch();
                }
                else
                {
                    Console.SetCursorPosition(0, 0);
                    Rendering();
                    PrintMap();
                    
                }

            }
        }
        private void PlayerSwitch()
        {
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.Spacebar:
                    if (sqr.UpSwitch == false && sqr.Y == 12 || sqr.UpSwitch == false && map.masiv[12, sqr.X] == '#' && map.masiv[12, sqr.X + 2] == '#')
                    {
                        sqr.JumpY = sqr.Y - 6;
                        sqr.UpSwitch = true;
                    }
                    ; break;
            }

        }
        private void PrintMap()
        {
            for (int i = 0; i < map.masiv.GetLength(0); i++)
            {
                for (int d = 0; d < map.masiv.GetLength(1); d++)
                {

                    if (i >= sqr.Y && i < sqr.Y + sqr.masiv.GetLength(0) && d >= sqr.X && d < sqr.X + sqr.masiv.GetLength(1))
                    {
                        Console.Write(sqr.masiv[i - sqr.Y, d - sqr.X]);
                    }
                    else
                    {
                        Console.Write(map.masiv[i, d]);
                    }
                }
                Console.WriteLine();
            }
        }
        private void Rendering()
        {
            //Person Playing Person Playing
            if (sqr.UpSwitch)
            {
                
                if (sqr.Y > sqr.JumpY)
                {
                    sqr.Y--;
                }
                else
                {
                    sqr.UpSwitch = false;
                }
                
            }
            else
            {
                if (sqr.Y < 12 && map.masiv[12,sqr.X] == ' ' && map.masiv[12, sqr.X + 2] == ' ' && map.masiv[12, sqr.X + 1] == ' ')
                {
                    sqr.Y++;
                }

            }
            //Person Playing Person Playing
            


            // Spawn Object Spawn Object
            if (r.Next(10) == 0 && map.masiv[12, map.masiv.GetLength(1) - 5] == ' ' && map.masiv[12, map.masiv.GetLength(1) - 10] == ' ')
            {
                
                for (int i = 0; i < 3; i++)
                {
                    for (int g = 1; g < 6; g++)
                    {
                        map.masiv[12 + i, map.masiv.GetLength(1) - g] = '#';
                    }
                }
            }
            // Spawn Object Spawn Object
            


            //Rendering Map Rendering Map
            for (int i = 0; i < map.masiv.GetLength(0); i++)
            {
                for (int g = 0; g < map.masiv.GetLength(1); g++)
                {
                    if (map.masiv[i, g] == '#' && g > 0)
                    {
                        map.masiv[i, g] = ' ';
                        map.masiv[i, g - 1] = '#';

                    }
                    else if (map.masiv[i, g] == '#' && g == 0)
                    {
                        map.masiv[i, g] = ' ';
                    }
                }
            }
            //Rendering Map Rendering Map
        }
    }
}
