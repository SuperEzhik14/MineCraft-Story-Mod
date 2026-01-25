using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarsWars.Rocketsa
{
    class Rocket4 : Rockets
    {
        public void GetAttack(ref Map map)
        {

            for (int h = 1; h < 4; h++)
            {
                Energy -= 0.5;
                if (map.masiv[Y - 1, X] == '↕' || map.masiv[Y - 1, X] == '↔')
                {
                    map.masiv[Y - (h + 1), X + 4] = '#';
                    map.masiv[Y - (h + 1), X + 8] = '#';

                }
                else
                {

                    map.masiv[Y - h, X + 4] = '#';
                    map.masiv[Y - h, X + 8] = '#';

                }
            }

            if (map.masiv[Y - 1, X] == '↕' || map.masiv[Y - 1, X] == '↔')
            {
                map.masiv[Y - 3, X + 1] = '#';
                map.masiv[Y - 3, X + 2] = '#';
                map.masiv[Y - 3, X + 10] = '#';
                map.masiv[Y - 3, X + 11] = '#';
            }
            else
            {

                map.masiv[Y - 2, X + 1] = '#';
                map.masiv[Y - 2, X + 2] = '#';
                map.masiv[Y - 2, X + 10] = '#';
                map.masiv[Y - 2, X + 11] = '#';

            }
        }
        public void GetBlockSkill(ref Map map)
        {
            Energy -= 0.04;
            for (int g = 0; g < masiv.GetLength(1); g++)
            {
                map.masiv[Y - 1, X + g] = new Random().Next(2) == 1 ? '↕' : '↔'; ;
            }
        }

        public ConsoleColor GetColor()
        {
            return new Random().Next(2) == 1 ? ConsoleColor.Gray : ConsoleColor.Red;
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
        public Rocket4()
        {


            masiv = new char[,]
            {
                {'-',' ',' ','_','╜', ' ', '⌂', ' ', '╙','_',' ',' ','-'},
                {'╞',' ',' ','╡','╫', '═', '╫', '═', '╫','╞',' ',' ','╡'},
                {'─',' ',' ','═','│', '▄', '■', '▄', '│','═',' ',' ','─'}
            };

            X = 0;
            Y = 20;
            Damage = 1;
            Speed = 1;
            MaxXP = 300;
            MaxEnergy = 300;
            XP = 300;
            Energy = 300;
            Abilitylvl = 1;
            Damagelvl = 1;
            Energylvl = 1;
            Speedlvl = 1;
            XPlvl = 1;
            Money = 650;
            Ability = "Закаление";
            name = " InDarex ";
        }

    }
}
