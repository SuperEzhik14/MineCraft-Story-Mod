using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarsWars.Warriorsa
{
    interface Warriors
    {
        void GetAttack(ref Map map);
        void GetAbility1(ref Map map);
        void GetAbility2(ref Map map);
        void GetAbility3(ref Map map);
        ConsoleColor GetColor();
        bool muve {  get; set; }
        
        public int Money { get; set; }
        public int XP { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        char[,] masiv { get; set; }
    }
}
