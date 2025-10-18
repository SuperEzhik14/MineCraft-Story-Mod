using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hay_Day
{
    class Map
    {
        public char[,] masiv;
        public Map()
        {
            masiv = new char[15, 30];
            for(int i = 0; i < masiv.GetLength(0); i++)
            {
                for (int j = 0; j < masiv.GetLength(1); j++)
                {
                    masiv[i, j] = ' ';
                }
            }
        }
    }
}
