using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarsWars.Rocketsa
{
    class Rocket5 : Rockets
    {
        public void GetAttack(ref Map map)
        {
            for (int h = 1; h < 4; h++)
            {
                Energy -= 0.7;
                if (map.masiv[Y - 1, X] == '↕' || map.masiv[Y - 1, X] == '↔' && h != 2)
                {
                    map.masiv[Y - (h + 1), X + 4] = '#';
                    map.masiv[Y - (h + 1), X + 8] = '#';
                    map.masiv[Y - (h + 1), X] = '#';
                    map.masiv[Y - (h + 1), X + 12] = '#';
                }
                else if (h != 2)
                {

                    map.masiv[Y - h, X + 4] = '#';
                    map.masiv[Y - h, X + 8] = '#';
                    map.masiv[Y - h, X] = '#';
                    map.masiv[Y - h, X + 12] = '#';
                }




            }
            if (map.masiv[Y - 1, X] == '↕' || map.masiv[Y - 1, X] == '↔')
            {
                map.masiv[Y - 3, X + 1] = '#';
                map.masiv[Y - 3, X + 3] = '#';
                map.masiv[Y - 3, X + 9] = '#';
                map.masiv[Y - 3, X + 11] = '#';

            }
            else
            {

                map.masiv[Y - 2, X + 1] = '#';
                map.masiv[Y - 2, X + 3] = '#';
                map.masiv[Y - 2, X + 9] = '#';
                map.masiv[Y - 2, X + 11] = '#';


            }


        }
        public void GetBlockSkill(ref Map map)
        {
            Energy -= 0.05;
            for (int g = 0; g < masiv.GetLength(1); g++)
            {
                map.masiv[Y - 1, X + g] = new Random().Next(2) == 1 ? '↕' : '↔'; ;
            }
        }

        public ConsoleColor GetColor()
        {
            return new Random().Next(2) == 1 ? ConsoleColor.DarkYellow : ConsoleColor.Green;
        }
        public string Ability { get; set; }
        public int Money { get; set; }
        public int Speedlvl { get; set; }
        public int Energylvl { get; set; }
        public int Damagelvl { get; set; }
        public int XPlvl { get; set; }
        public int Abilitylvl { get; set; }
        public string name { get; set; }
        public bool BlockOff { get; set; }
        public int Speed { get; set; }
        public double MaxXP { get; set; }
        public bool Uprevleshion { get; set; }
        public double Energy { get; set; }
        public double MaxEnergy { get; set; }
        public int Damage { get; set; }
        public double XP { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public char[,] masiv { get; set; }
        public Rocket5()
        {


            masiv = new char[,]
            {
                {'↓',' ',' ','_','↓', ' ', '⌂', ' ', '↓','_',' ',' ','↓'},
                {'╞',' ',' ','╡','╫', '═', '╫', '═', '╫','╞',' ',' ','╡'},
                {'_',' ',' ','-','╪', '@', '@', '@', '╪','-',' ',' ','_'}
            };

            X = 0;
            Y = 20;
            Damage = 1;
            Speed = 1;
            MaxXP = 400;
            MaxEnergy = 400;
            XP = 400;
            Energy = 400;
            Abilitylvl = 1;
            Damagelvl = 1;
            Energylvl = 1;
            Speedlvl = 1;
            XPlvl = 1;
            Money = 850;
            Ability = "МистерДоллар";
            name = "Blazer V2";
        }

    }
}
