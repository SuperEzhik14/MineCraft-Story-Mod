using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maks.Library
{
    public static class RandomChar
    {

        public static char RandomCharOver()
        {
            switch (new Random().Next(1, 9))
            {
                case 1: return ' ';
                case 2: return ' ';
                case 3: return '#';
                case 4: return '$';
                case 5: return ' ';
                case 6: return ' ';
                case 7: return ' ';
                default: return '+';
            }
        }
        public static char RandomCharParticle()
        {
            return new Random().Next(2) == 1 ? '♦' : '♥';
        }
    }
}
