using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarsWars.Rocketsa
{
    interface Rockets
    {
        void GetRocketShop(bool tr)
        {

            Console.WriteLine($"\n█▓▒▒░░\t                               ░░▒▒▓█");
            Console.WriteLine("██▓▓▒▒▒░░░═══════────═─═────═══════░░░▒▒▒▓▓██");
            Console.WriteLine($"█▓▒▒░░    {name}    Характеристики  ░░▒▒▓█\n");
            for (int h = 0; h < masiv.GetLength(0); h++)
            {
                Console.Write("      ");
                for (int i = 0; i < masiv.GetLength(1); i++)
                {
                    Console.ForegroundColor = GetColor();
                    Console.Write(masiv[h, i]);

                }
                Console.ForegroundColor = ConsoleColor.White;
                switch (h)
                {
                    case 0: Console.Write($"\t  § Защита   {MaxXP}        "); break;
                    case 1: Console.Write($"\t  § Энергия  {MaxEnergy}     "); break;
                    case 2: Console.Write($"\t  § Сила     {Damage}       "); break;
                }
                Console.WriteLine();
            }
            Console.WriteLine($"\t\t\t  § Скорость {Speed}            ");
            Console.WriteLine($"\t\t\t  § Навык    {Ability}          ");
            Console.WriteLine($"\t\t\t  § Уровень  [{Print.printLVLforShop2(MaxXP, 10)}]\n");
            if (tr)
            {
                Console.WriteLine("\n\t\t                                ");
                Console.WriteLine($"\t\t\t  [Использовать]         ");
            }
            else
            {
                Console.WriteLine($"\n\t\t\t  {MaxXP / 2}# {Money}$       ");
                Console.WriteLine($"\t\t\t  [Купить]     ");
            }

        }
        void GetAttack(ref Map map)
        {
            for (int h = 1; h < 2; h++)
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
        void GetBlockSkill(ref Map map)
        {
            Energy -= 0.01;
            for (int g = 0; g < masiv.GetLength(1); g++)
            {
                map.masiv[Y - 1, X + g] = new Random().Next(2) == 1 ? '↕' : '↔';
            }
        }
        ConsoleColor GetColor()
        {
            return ConsoleColor.Cyan;
        }
        // LVLS

        public int Speedlvl { get; set; }
        public int Energylvl { get; set; }
        public int Damagelvl { get; set; }
        public int XPlvl { get; set; }
        public int Abilitylvl { get; set; }

        // LVLS
        public string Ability { get; set; }
        public int Money { get; set; }
        public int Speed { get; set; }
        public string name { get; set; }
        public bool Uprevleshion { get; set; }
        public double Energy { get; set; }
        public double MaxEnergy { get; set; }
        public bool BlockOff { get; set; }
        public int Damage { get; set; }
        public double MaxXP { get; set; }
        public double XP { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public char[,] masiv { get; set; }
    }
}
