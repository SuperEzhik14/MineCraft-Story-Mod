using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace StarsWars
{
    
    interface Rockets
    {
        void GetAttack(ref Map map)
        {
            for (int h = 1; h < 2; h++)
            {
                Energy -= 0.2;
                if (map.masiv[Y - 1, X] == '^')
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
        void GetBlockSkill(ref Map map)
        {
            Energy -= 0.01;
            for (int g = 0; g < masiv.GetLength(1); g++)
            {
                map.masiv[Y - 1, X + g] = '^';
            }
        }
        ConsoleColor GetColor()
        {
            return ConsoleColor.Cyan;
        }
        public int Speed { get; set; }
        public bool Uprevleshion { get; set; }
        public double Energy { get; set; }
        public double MaxEnergy { get; set; }
        public bool BlockOff {  get; set; }
        public int Damage { get; set; }
        public double MaxXP { get; set; }
        public double XP { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public char[,] masiv { get; set; }
    }
    class RocketGen : Rockets
    {
        public void GetAttack(ref Map map)
        {
            for (int h = 1; h < 3; h++)
            {
                Energy -= 0.2;
                if (map.masiv[Y - 1, X] == '^')
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
        public RocketGen()
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
        }

    }
    class RocketStrong : Rockets
    {
        public void GetAttack(ref Map map)
        {
            int ghh = 2;
            for (int h = 1; h < ghh; h++)
            {
                Energy -= 0.4;
                if (map.masiv[Y - 1, X] == '^')
                {
                    map.masiv[Y - (h + 1), X + 4] = '#';
                    map.masiv[Y - (h + 1), X + 8] = '#';
                    map.masiv[Y - (h + 1), X] = '#';
                    map.masiv[Y - (h + 1), X + 12] = '#';
                }
                else
                {
                    
                    map.masiv[Y - h, X + 4] = '#';
                    map.masiv[Y - h, X + 8] = '#';
                    map.masiv[Y - h, X] = '#';
                    map.masiv[Y - h, X + 12] = '#';
                }
                if (new Random().Next(7) == 1)
                    ghh++;
               

            }

        }


        public ConsoleColor GetColor()
        {
            return new Random().Next(2) == 1 ? ConsoleColor.DarkGreen : ConsoleColor.Red;
        }
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
        public RocketStrong()
        {


            masiv = new char[,]
            {
                {'╘',' ',' ',' ','╘', ' ', '▼', ' ', '╛',' ',' ',' ','╛'},
                {'╞','─','─','╡','╫', '═', '╫', '═', '╫','╞','─','─','╡'},
                {'╫',' ',' ',' ','╪', '■', '│', '■', '╪',' ',' ',' ','╫'}
            };
            X = 0;
            Y = 20;
            Damage = 1;
            Speed = 2;
            MaxXP = 200;
            MaxEnergy = 200;
            XP = 200;
            Energy = 200;
        }

    }
    class Rocket : Rockets
    {
        public ConsoleColor GetColor()
        {
            return new Random().Next(2) == 1 ? ConsoleColor.DarkGray : ConsoleColor.Red;
        }
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
        public Rocket()
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

        }

    }
}
