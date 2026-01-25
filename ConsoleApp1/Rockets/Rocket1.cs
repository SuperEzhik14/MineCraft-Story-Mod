using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarsWars.Rocketsa
{
    class Rocket1 : Rockets
    {
        public ConsoleColor GetColor()
        {
            return new Random().Next(2) == 1 ? ConsoleColor.DarkGray : ConsoleColor.Red;
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
        public Rocket1()
        {


            masiv = new char[,]
            {
                {'╥',' ',' ',' ','│', ' ', '▼', ' ', '│',' ',' ',' ','╥'},
                {'╞','─','─','╡','╫', '═', '╫', '═', '╫','╞','─','─','╡'},
                {'╫',' ',' ',' ','┼', '■', '│', '■', '┼',' ',' ',' ','╫'}
            };
            X = 0;
            Y = 20;
            Damage = 1;
            Speed = 1;
            MaxXP = 100;
            MaxEnergy = 100;
            XP = 100;
            Energy = 100;
            Abilitylvl = 1;
            Damagelvl = 1;
            Energylvl = 1;
            Speedlvl = 1;
            XPlvl = 1;
            Money = 0;
            Ability = "Не Имеет";
            name = "Vamer D1 ";
        }

    }
}
