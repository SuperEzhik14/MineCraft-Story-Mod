using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarsWars.Rocketsa
{
    class Rocket2 : Rockets
    {
        public void GetAttack(ref Map map)
        {
            for (int h = 1; h < 3; h++)
            {
                Energy -= 0.2;
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

        }


        public ConsoleColor GetColor()
        {
            return new Random().Next(2) == 1 ? ConsoleColor.DarkGreen : ConsoleColor.DarkMagenta;
        }
        public int Money { get; set; }
        public string Ability { get; set; }
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
        public Rocket2()
        {


            masiv = new char[,]
            {
                {'╥',' ','*',' ','│', ' ', '▼', ' ', '│',' ','*',' ','╥'},
                {'╞','─','─','╡','╫', '═', '╫', '═', '╫','╞','─','─','╡'},
                {'╫',' ','*',' ','┼', '■', '│', '■', '┼',' ','*',' ','╫'}
            };
            X = 0;
            Y = 20;
            Damage = 1;
            Speed = 1;
            MaxXP = 150;
            MaxEnergy = 150;
            XP = 150;
            Energy = 150;
            Abilitylvl = 1;
            Damagelvl = 1;
            Energylvl = 1;
            Speedlvl = 1;
            XPlvl = 1;
            Money = 250;
            Ability = "Не Имеет";
            name = "Vamer D2 ";

        }

    }
}
