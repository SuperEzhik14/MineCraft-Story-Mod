using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hay_Day
{
    class Person
    {
        public int Y;
        public int X;
        public int CountCarrots;
        public Person(Map map)
        {
            CountCarrots = 0;
            Y = (int)(map.masiv.GetLength(0) - 1) / 2;
            X = (int)(map.masiv.GetLength(1) - 1) / 2;
        }
    }
}
