using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hay_Day
{
    class Game
    {
        private Map map;
        public Game()
        {
            map = new Map();
            while (true)
            {
                if (Console.KeyAvailable == true)
                {
                    
                }
                else
                {
                    Console.SetCursorPosition(0, 0);
                    

                }

            }
        }
        private void PrintMap()
        {

        }
    }
}
