using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometridar
{
    class Map
    {
        public char[,] masiv;
        public Map()
        {
            masiv = new char[15,95];
            for (int i = 0; i < masiv.GetLength(0); i++)
            {
                for (int d = 0; d < masiv.GetLength(1); d++)
                {
                    masiv[i, d] = ' ';
                }
            }
        }
    }
}
