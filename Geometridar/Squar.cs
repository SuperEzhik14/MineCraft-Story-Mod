using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometridar
{
    class Squar
    {
        public int Y, X, JumpY;
        public char[,] masiv;
        public bool UpSwitch;
        public Squar()
        {
            X = 25;
            Y = 12;
            UpSwitch = false;
            masiv = new char[,] {
                { '╔','═','═','═','╗'},
                { '║',' ',' ',' ','║'},
                { '╚','═','═','═','╝'}
            };
            
        }
    }
}
