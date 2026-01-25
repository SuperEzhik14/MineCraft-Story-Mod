using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Hay_Day
{
    class Game
    {
        private Person person;
        private Map map;
        private Random r = new Random();
        
        public Game()
        {
            map = new Map();
            person = new Person(map);
            while (true)
            {
                if (Console.KeyAvailable == true)
                {
                    
                }
                else
                {
                    Console.SetCursorPosition(0, 0);
                    Rendering();
                    PrintMap();

                }

            }
        }
        private void Rendering()
        {
            int y, x;
            


            for (int i = 0; i < map.masiv.GetLength(0); i++)
            {
                for (int f = 0; f < map.masiv.GetLength(1); f++)
                {
                    

                    if (person.X < f)
                    {
                        
                    }
                    else
                    {
                        if (r.Next(15) == 1)
                        {
                            map.masiv[i,f] = '#';
                        }
                    }
                }
            }
        }
        private void PrintMap()
        {
            Console.WriteLine("\n\n\n");
            for (int i = 0; i < map.masiv.GetLength(0);i++)
            {
                
                Console.Write("\t\t");
                for (int d = 0; d < map.masiv.GetLength(1); d++)
                {
                    if (i == person.Y && d == person.X)
                    {
                        Console.Write("@");
                    }
                    else 
                    {
                        Console.Write(map.masiv[i,d]);
                    }
                }
                if (i == 0)
                {
                    Console.Write($"\t\t# Дед Сожрал: {person.CountCarrots}");
                }
                Console.WriteLine();
            }
        }
    }
}
