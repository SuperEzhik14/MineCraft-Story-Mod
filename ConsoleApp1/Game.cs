global using Maks.Library;
using StarsWars.Rocketsa;
using StarsWars.Warriorsa;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace StarsWars
{

    class Game
    {
        private void Restart()
        {
            game = true;
            map = new Map();
            warrior.Clear();
            // ДОБАВЛЕНИЕ САМОЛЕТОВ
            rocket = new List<Rockets>() { new Rocket1(), new Rocket2(), new Rocket3(), new Rocket4(), new Rocket5() };

            // ДОБАВЛЕНИЕ САМОЛЕТОВ
            Metiors = 0;
            StrongMetiors = 0;
            SuperMetiors = 0;
            Potrons = 0;

            money = 100000;
            experience = 2000;
            rocketshop = new bool[rocket.Count];
            rocketshop[0] = true;
            index = 0;

        }

        private bool[] rocketshop;
        private int Metiors;
        private int StrongMetiors;
        private int SuperMetiors;
        private int Potrons;

        private List<Rockets> rocket = new List<Rockets>();
        private List<Warriors> warrior = new List<Warriors>();
        private int index;
        private int money;
        private int experience;
        private Map map; 
        private Random r = new Random();
        private bool game;
        public Game()
        {

            while (true)
            { 
                Restart();

                while (game)
                {
                    if (Console.KeyAvailable == true)
                    {
                        PlayerGameSwitch();
                    }
                    else
                    {

                        Console.SetCursorPosition(0, 0);
                        RenderingMap();
                        PrintGame();
                        if (rocket[index].Energy <= 0 || rocket[index].XP <= 0)
                        {
                            GetOver();
                        }
                    }

                }
            }
        }
        private void GetOver()
        {
            if (r.Next(120) == 1)
            {
                game = false;
                Console.Clear();
                while (true)
                {
                    if (Console.KeyAvailable == true)
                    {
                        Console.ReadLine();
                        break;
                    }
                    else
                    {

                        Console.SetCursorPosition(0, 0);
                        Console.ForegroundColor = RandomColor.RandomColorOrange();
                        Console.WriteLine($"\n\t* Собрано Metiors: {Metiors}");

                        Console.WriteLine($"\t☼ Собрано StrongMetiors: {StrongMetiors}");

                        Console.WriteLine($"\t? Собрано SuperMetiors: {SuperMetiors}");

                        Console.WriteLine($"\t# Применялись: {Potrons} Потронов");

                        Console.WriteLine("\n\n\t\t\t\t   Миссия завершилась огненным фиаско");
                        Console.WriteLine("\n\n\t\t\t\t        Нажмите для Возрождение");

                    }

                }
                Console.ResetColor();

            }

            else
            {
                rocket[index].masiv[r.Next(rocket[index].masiv.GetLength(0)), r.Next(rocket[index].masiv.GetLength(1))] = RandomChar.RandomCharOver();
            }
        }
        private void GetImpruveRocket()
        {
            int IndexShop = 0; bool muve = false;
            bool Shop = true;
            Console.Clear();
            while (Shop)
            {
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Gray;

                //Вырисовка  Вырисовка
                Console.WriteLine("  :: ::   :: ::   ::|::                                                           ::|::   :: ::   :: ::");
                Console.Write($"  :: ::   :: ::   ::|::                ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Галактический Апгрейд-Центр                ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("::|::   :: ::   :: ::");
                Console.WriteLine();
                Console.WriteLine("  :: ::   :: ::   ::|::                                                           ::|::   :: ::   :: ::");

                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("  :: ::   :: ::   ::|::   ::|::   ::┼::   ::╪::   ::╫::   ::╪::   ::┼::   ::|::   ::|::   :: ::   :: ::");
                }
                Console.Write($"  :: ::   :: ::   ::|::       ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{rocket[index].name}                         {Print.PrintInImpruving(experience)}#{Print.PrintInImpruving(money)}$  ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("::|::   :: ::   :: ::");
                Console.WriteLine();
                Console.WriteLine($"  :: ::   :: ::   ::|::                                                           ::|::   :: ::   :: ::");
                Console.ForegroundColor = ConsoleColor.Red;
                for (int h = 0; h < rocket[index].masiv.GetLength(0); h++)
                {
                    Console.Write("                            ");
                    for (int i = 0; i < rocket[index].masiv.GetLength(1); i++)
                    {
                        Console.ForegroundColor = rocket[index].GetColor();
                        Console.Write(rocket[index].masiv[h, i]);

                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    switch (h)
                    {
                        case 0: Console.Write($"\t§ Защита    [{Print.printLVLforShop(rocket[index].XPlvl, 10)}]  {rocket[index].MaxXP}"); break;
                        case 1: Console.Write($"\t§ Энергия   [{Print.printLVLforShop(rocket[index].Energylvl, 10)}]  {rocket[index].MaxEnergy}"); break;
                        case 2: Console.Write($"\t§ Сила      [{Print.printLVLforShop(rocket[index].Damagelvl, 10)}]  {rocket[index].Damage}"); break;
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"                            \t\t\t§ Скорость  [{Print.printLVLforShop(rocket[index].Speedlvl, 10)}]  {rocket[index].Speed}");
                if (rocket[index].Ability != "Не Имеет")
                {
                    Console.WriteLine($"                            \t\t\t§ Навык     [{Print.printLVLforShop(rocket[index].Abilitylvl, 10)}]  {rocket[index].Ability}");
                }
                else
                {
                    Console.WriteLine($"                            \t\t\t§ Навык     {rocket[index].Ability}                    ");
                }
                Console.WriteLine($"                          \t\t\t§ Уровень   [{Print.printLVLforShop2(rocket[index].MaxXP, 10)}]\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"  :: ::   :: ::   ::|::                                                           ::|::   :: ::   :: ::");
                Console.WriteLine($"  :: ::   :: ::   ::|::                                                           ::|::   :: ::   :: ::");
                Console.WriteLine($"  :: ::   :: ::   ::|::   ::|::   ::┼::   ::╪::   ::╫::   ::╪::   ::┼::   ::|::   ::|::   :: ::   :: ::");
                Console.WriteLine($"  :: ::   :: ::   ::|::   ::|::   ::┼::   ::╪::   ::╫::   ::╪::   ::┼::   ::|::   ::|::   :: ::   :: ::");
                string line1 = "  :: ::   :: ::   ::|"; string line2 = "  :: ::   :: ::   ::|"; string line3 = "  :: ::   :: ::   ::|";
                for (int i = 0; i < 8; i++)
                {
                    switch (i)
                    {
                        case 0:
                            {
                                if (IndexShop == 0)
                                {
                                    if (muve)
                                    {
                                        line1 += "▌Броня▐|";
                                        line2 += "█ (*) █|";
                                        line3 += $"▌{Print.PrintInImpruvingDollars((int)rocket[index].MaxXP / 2)}▐|";
                                    }
                                    else
                                    {
                                        line1 += "▌Броня▐|";
                                        line2 += "▒ (*) ▒|";
                                        line3 += $"▌{Print.PrintInImpruvingDollars((int)rocket[index].MaxXP / 2)}▐|";
                                    }
                                }
                                else if (rocket[index].XPlvl == 10)
                                {
                                    line1 += "░Броня░|";
                                    line2 += "▒ (*) ▒|";
                                    line3 += "░ *☼* ░|";
                                }
                                else
                                {
                                    line1 += "░Броня░|";
                                    line2 += "▒ (*) ▒|";
                                    line3 += $"░{Print.PrintInImpruvingDollars((int)rocket[index].MaxXP / 2)}░|";
                                }
                            } break;
                        case 1:
                            {
                                if (IndexShop == 1)
                                {
                                    if (muve)
                                    {
                                        line1 += "▌Энерг▐┼";
                                        line2 += "█ ::: █┼";
                                        line3 += $"▌{Print.PrintInImpruvingDollars((int)rocket[index].MaxEnergy / 2)}▐┼";
                                    }
                                    else
                                    {
                                        line1 += "▌Энерг▐┼";
                                        line2 += "▒ ::: ▒┼";
                                        line3 += $"▌{Print.PrintInImpruvingDollars((int)rocket[index].MaxEnergy / 2)}▐┼";
                                    }
                                }
                                else if (rocket[index].Energylvl == 10)
                                {
                                    line1 += "░Энерг░┼";
                                    line2 += "▒ ::: ▒┼";
                                    line3 += "░ *☼* ░┼";
                                }
                                else
                                {
                                    line1 += "░Энерг░┼";
                                    line2 += "▒ ::: ▒┼";
                                    line3 += $"░{Print.PrintInImpruvingDollars((int)rocket[index].MaxEnergy / 2)}░┼";
                                }
                            }
                            break;
                        case 2:
                            {
                                if (IndexShop == 2)
                                {
                                    if (muve)
                                    {
                                        line1 += "▌Огонь▐╪";
                                        line2 += "█ |#| █╪";
                                        line3 += $"▌{Print.PrintInImpruvingDollars((int)rocket[index].Damage * 100)}▐╪";
                                    }
                                    else
                                    {
                                        line1 += "▌Огонь▐╪";
                                        line2 += "▒ |#| ▒╪";
                                        line3 += $"▌{Print.PrintInImpruvingDollars((int)rocket[index].Damage * 100)}▐╪";
                                    }
                                }
                                else if (rocket[index].Damagelvl == 10)
                                {
                                    line1 += "░Огонь░╪";
                                    line2 += "▒ |#| ▒╪";
                                    line3 += "░ *☼* ░╪";
                                }
                                else
                                {
                                    line1 += "░Огонь░╪";
                                    line2 += "▒ |#| ▒╪";
                                    line3 += $"░{Print.PrintInImpruvingDollars(rocket[index].Damage * 100)}░╪";
                                }
                            }
                            break;
                        case 3:
                            {
                                if (IndexShop == 3)
                                {
                                    if (muve)
                                    {
                                        line1 += "▌Ускор▐╫";
                                        line2 += "█ ─═─ █╫";
                                        line3 += $"▌{Print.PrintInImpruvingDollars(rocket[index].Speed * 50)}▐╫";
                                    }
                                    else
                                    {
                                        line1 += "▌Ускор▐╫";
                                        line2 += "▒ ─═─ ▒╫";
                                        line3 += $"▌{Print.PrintInImpruvingDollars(rocket[index].Speed * 50)}▐╫";
                                    }
                                }
                                else if (rocket[index].Speedlvl == 10)
                                {
                                    line1 += "░Ускор░╫";
                                    line2 += "▒ ─═─ ▒╫";
                                    line3 += "░ *☼* ░╫";
                                }
                                else
                                {
                                    line1 += "░Ускор░╫";
                                    line2 += "▒ ─═─ ▒╫";
                                    line3 += $"░{Print.PrintInImpruvingDollars(rocket[index].Speed * 50)}░╫";
                                }
                            }
                            break;
                        case 4:
                            {
                                if (experience >= 150)
                                {
                                    if (IndexShop == 4)
                                    {
                                        if (muve)
                                        {
                                            line1 += "▌ДпЗащ▐╪";
                                            line2 += "█ (+) █╪";
                                            line3 += $"▌{Print.PrintInImpruvingDollars((int)rocket[index].MaxXP / 2)}▐╪";
                                        }
                                        else
                                        {
                                            line1 += "▌ДпЗащ▐╪";
                                            line2 += "▒ (+) ▒╪";
                                            line3 += $"▌{Print.PrintInImpruvingDollars((int)rocket[index].MaxXP / 2)}▐╪";
                                        }
                                    }
                                    else
                                    {
                                        line1 += "░ДпЗащ░╪";
                                        line2 += "▒ (+) ▒╪";
                                        line3 += $"░{Print.PrintInImpruvingDollars((int)rocket[index].MaxXP / 2)}░╪";
                                    }
                                }
                                else
                                {
                                    if (IndexShop == 4)
                                    {
                                        if (muve)
                                        {
                                            line1 += "▌  _  ▐|";
                                            line2 += "█  ?  █|";
                                            line3 += "▌     ▐|";
                                        }
                                        else
                                        {
                                            line1 += "▌  _  ▐|";
                                            line2 += "▒  ?  ▒|";
                                            line3 += "▌     ▐|";
                                        }
                                    }
                                    else
                                    {
                                        line1 += "░  _  ░╪";
                                        line2 += "▒  ?  ▒╪";
                                        line3 += "░     ░╪";
                                    }
                                }
                            }
                            break;
                        case 5:
                            {
                                if (experience >= 150)
                                {
                                    if (IndexShop == 5)
                                    {
                                        if (muve)
                                        {
                                            line1 += "▌ДпЭнр▐┼";
                                            line2 += "█ ^^^ █┼";
                                            line3 += $"▌{Print.PrintInImpruvingDollars((int)rocket[index].MaxEnergy / 2)}▐┼";
                                        }
                                        else
                                        {
                                            line1 += "▌ДпЭнр▐┼";
                                            line2 += "▒ ^^^ ▒┼";
                                            line3 += $"▌{Print.PrintInImpruvingDollars((int)rocket[index].MaxEnergy / 2)}▐┼";
                                        }
                                    }
                                    else
                                    {
                                        line1 += "░ДпЭнр░┼";
                                        line2 += "▒ ^^^ ▒┼";
                                        line3 += $"░{Print.PrintInImpruvingDollars((int)rocket[index].MaxEnergy / 2)}░┼";
                                    }
                                }
                                else
                                {
                                    if (IndexShop == 5)
                                    {
                                        if (muve)
                                        {
                                            line1 += "▌  _  ▐|";
                                            line2 += "█  ?  █|";
                                            line3 += "▌     ▐|";
                                        }
                                        else
                                        {
                                            line1 += "▌  _  ▐|";
                                            line2 += "▒  ?  ▒|";
                                            line3 += "▌     ▐|";
                                        }
                                    }
                                    else
                                    {
                                        line1 += "░  _  ░┼";
                                        line2 += "▒  ?  ▒┼";
                                        line3 += "░     ░┼";
                                    }
                                }
                            }
                            break;
                        case 6:
                            {
                                if (experience >= 350)
                                {
                                    if (IndexShop == 6)
                                    {
                                        if (muve)
                                        {
                                            line1 += "▌Навык▐|";
                                            line2 += "█ ╡♀╞ █|";
                                            line3 += $"▌{Print.PrintInImpruvingDollars(rocket[index].Abilitylvl * 100)}▐|";
                                        }
                                        else
                                        {
                                            line1 += "▌Навык▐|";
                                            line2 += "▒ ╡♀╞ ▒|";
                                            line3 += $"▌{Print.PrintInImpruvingDollars(rocket[index].Abilitylvl * 100)}▐|";
                                        }
                                    }
                                    else if (rocket[index].Abilitylvl == 10)
                                    {
                                        line1 += "░Навык░|";
                                        line2 += "▒ ╡♀╞ ▒|";
                                        line3 += "░ *☼* ░|";
                                    }
                                    else
                                    {
                                        line1 += "░Навык░|";
                                        line2 += "▒ ╡♀╞ ▒|";
                                        line3 += $"░{Print.PrintInImpruvingDollars(rocket[index].Abilitylvl * 100)}░|";
                                    }
                                }
                                else
                                {
                                    if (IndexShop == 6)
                                    {
                                        if (muve)
                                        {
                                            line1 += "▌  _  ▐|";
                                            line2 += "█  ?  █|";
                                            line3 += "▌     ▐|";
                                        }
                                        else
                                        {
                                            line1 += "▌  _  ▐|";
                                            line2 += "▒  ?  ▒|";
                                            line3 += "▌     ▐|";
                                        }
                                    }
                                    else
                                    {
                                        line1 += "░  _  ░|";
                                        line2 += "▒  ?  ▒|";
                                        line3 += "░     ░|";
                                    }
                                }
                            }
                            break;
                        case 7:
                            {
                                if (experience >= 650)
                                {
                                    if (IndexShop == 6)
                                    {
                                        if (muve)
                                        {
                                            line1 += "▌Зачар▐|";
                                            line2 += "█ ╡♀╞ █|";
                                            line3 += $"▌{Print.PrintInImpruvingDollars(rocket[index].Abilitylvl * 100)}▐|";
                                        }
                                        else
                                        {
                                            line1 += "▌Зачар▐|";
                                            line2 += "▒ ╡♀╞ ▒|";
                                            line3 += $"▌{Print.PrintInImpruvingDollars(rocket[index].Abilitylvl * 100)}▐|";
                                        }
                                    }
                                    else if (rocket[index].Abilitylvl == 10)
                                    {
                                        line1 += "░Зачар░|";
                                        line2 += "▒ ╡♀╞ ▒|";
                                        line3 += "░ *☼* ░|";
                                    }
                                    else
                                    {
                                        line1 += "░Зачар░|";
                                        line2 += "▒ ╡♀╞ ▒|";
                                        line3 += $"░{Print.PrintInImpruvingDollars(rocket[index].Abilitylvl * 100)}░|";
                                    }
                                }
                                else
                                {
                                    if (IndexShop == 7)
                                    {
                                        if (muve)
                                        {
                                            line1 += "▌  _  ▐|";
                                            line2 += "█  ?  █|";
                                            line3 += "▌     ▐|";
                                        }
                                        else
                                        {
                                            line1 += "▌  _  ▐|";
                                            line2 += "▒  ?  ▒|";
                                            line3 += "▌     ▐|";
                                        }
                                    }
                                    else
                                    {
                                        line1 += "░  _  ░|";
                                        line2 += "▒  ?  ▒|";
                                        line3 += "░     ░|";
                                    }
                                }
                            }
                            break;
                        default: break;
                    }
                }
                line1 += "::   :: ::   :: ::";
                line2 += "::   :: ::   :: ::";
                line3 += "::   :: ::   :: ::";
                Console.WriteLine(line1);
                Console.WriteLine(line2);
                Console.WriteLine(line3);
                Console.WriteLine($"  :: ::   :: ::   ::|::   ::|::   ::┼::   ::╪::   ::╫::   ::╪::   ::┼::   ::|::   ::|::   :: ::   :: ::");
                Console.WriteLine($"  :: ::   :: ::   ::|::                                                           ::|::   :: ::   :: ::");
                Console.WriteLine($"  :: ::   :: ::   ::|::                                                           ::|::   :: ::   :: ::");

                //Вырисовка  Вырисовка

                if (muve)
                {
                    Thread.Sleep(150);
                    muve = false;
                    continue;
                }
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.D:
                        {
                            if (IndexShop < 8)
                            {
                                IndexShop++;
                            }
                            else
                            {
                                IndexShop = 0;
                            }

                        }
                        break;
                    case ConsoleKey.S:
                        {
                            if (IndexShop == 0 && money >= rocket[index].MaxXP / 2 && rocket[index].XPlvl < 10)
                            {

                                money -= (int)rocket[index].MaxXP / 2;
                                rocket[index].MaxXP += 50;
                                rocket[index].XPlvl++;
                                experience += 10;
                            }
                            else if (IndexShop == 1 && money >= rocket[index].MaxEnergy / 2 && rocket[index].Energylvl < 10)
                            {
                                money -= (int)rocket[index].MaxEnergy / 2;
                                rocket[index].MaxEnergy += 50;
                                rocket[index].Energylvl++;
                                experience += 10;
                            }
                            else if (IndexShop == 2 && money >= rocket[index].Damage * 100 && rocket[index].Damagelvl < 10)
                            {
                                money -= rocket[index].Damage * 100;
                                rocket[index].Damage += 1;
                                rocket[index].Damagelvl++;
                                experience += 10;
                            }
                            else if (IndexShop == 3 && money >= rocket[index].Speed * 50 && rocket[index].Speedlvl < 10)
                            {
                                money -= rocket[index].Speed * 50;
                                if (rocket[index].Speedlvl >= 7)
                                {
                                    rocket[index].Speed = 3;
                                }
                                else if (rocket[index].Speedlvl >= 4)
                                {
                                    rocket[index].Speed = 2;
                                }
                                experience += 10;
                                rocket[index].Speedlvl++;
                            }
                            else if (IndexShop == 4 && money >= rocket[index].MaxXP / 2 && experience >= 150)
                            {
                                money -= (int)rocket[index].MaxXP / 2;
                                experience += 20;
                                rocket[index].XP = rocket[index].MaxXP;
                            }
                            else if (IndexShop == 5 && money >= rocket[index].MaxEnergy / 2 && experience >= 150)
                            {
                                money -= (int)rocket[index].MaxEnergy / 2;
                                experience += 20;
                                rocket[index].Energy = rocket[index].MaxEnergy;
                            }
                            else if (IndexShop == 6 && money >= rocket[index].Abilitylvl * 100 && rocket[index].Abilitylvl < 10 && experience >= 350 && rocket[index].Ability != "Не Имеет")
                            {
                                money -= rocket[index].Abilitylvl * 100;
                                rocket[index].Abilitylvl++;
                                experience += 20;
                            }
                            else if (IndexShop == 7 && money >= 1500 && experience >= 650)
                            {
                                money -= 1500;
                                rocket[index].Abilitylvl++;
                                experience += 20;
                            }
                            muve = true;
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        {
                            Shop = false;
                        }
                        break;
                }
            }
            rocket[index].X = 0;
            rocket[index].Y = 20;
            Console.ResetColor();
            Console.Clear();

        }
        private void GetShop()
        {
            int IndexShop = index;
            bool Shop = true;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            while (Shop)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"[Пробел ,Выйти]\t[S, Купить]\t[D , Переключаться]\t\t[Опыт] {experience} #\t[Баланс] {money} $\n");
                // Вырисовка Корабля на котором играют
                Console.WriteLine($"█▓▒▒░░            Активный             ░░▒▒▓█");
                Console.WriteLine($"██▓▓▒▒▒░░░═══════────═─═────═══════░░░▒▒▒▓▓██");
                Console.WriteLine($"█▓▒▒░░            {rocket[index].name}            ░░▒▒▓█\n");
                for (int h = 0; h < rocket[index].masiv.GetLength(0); h++)
                {
                    Console.Write("      ");
                    for (int i = 0; i < rocket[index].masiv.GetLength(1); i++)
                    {
                        Console.ForegroundColor = rocket[index].GetColor();
                        Console.Write(rocket[index].masiv[h, i]);

                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    switch (h)
                    {
                        case 0: Console.Write($"\t  § Защита    [{Print.printLVLforShop(rocket[index].XPlvl, 10)}]  {rocket[index].MaxXP}"); break;
                        case 1: Console.Write($"\t  § Энергия   [{Print.printLVLforShop(rocket[index].Energylvl, 10)}]  {rocket[index].MaxEnergy}"); break;
                        case 2: Console.Write($"\t  § Сила      [{Print.printLVLforShop(rocket[index].Damagelvl, 10)}]  {rocket[index].Damage}"); break;
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"\t\t\t  § Скорость  [{Print.printLVLforShop(rocket[index].Speedlvl, 10)}]  {rocket[index].Speed}");
                if (rocket[index].Ability != "Не Имеет")
                {
                    Console.WriteLine($"\t\t\t  § Навык     [{Print.printLVLforShop(rocket[index].Abilitylvl, 10)}]  {rocket[index].Ability}");
                }
                else
                {
                    Console.WriteLine($"\t\t\t  § Навык     {rocket[index].Ability}                    ");
                }
                Console.WriteLine($"\t\t\t  § Уровень   [{Print.printLVLforShop2(rocket[index].MaxXP, 10)}]\n");

                if (IndexShop == 0)
                {

                    Console.WriteLine("\t──═─ + ─═┤ ═─ * ─═ ├═─ + ─═──");

                }
                else
                {
                    Console.WriteLine("\t                                ");
                }
                // Вырисовка Корабля на котором играют
                for (int i = 0; i < rocket.Count; i++)
                {
                    if (i != index)
                    {
                        rocket[i].GetRocketShop(rocketshop[i]);
                        if (IndexShop == i)
                        {

                            Console.WriteLine("\t──═─ + ─═┤ ═─ * ─═ ├═─ + ─═──");

                        }
                        else
                        {
                            Console.WriteLine("\t                                ");
                        }
                    }

                }


                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.D:
                        {
                            if (IndexShop + 1 < rocket.Count)
                            {
                                IndexShop++;
                            }
                            else
                            {
                                IndexShop = 0;
                            }

                        }
                        break;
                    case ConsoleKey.S:
                        {
                            if (rocketshop[IndexShop])
                            {
                                index = IndexShop;
                                rocket[index].X = 0;
                                rocket[index].Y = 20;

                            }
                            else if (money >= rocket[IndexShop].Money && experience >= (int)rocket[IndexShop].MaxXP / 2)
                            {
                                rocketshop[IndexShop] = true;
                                money -= rocket[IndexShop].Money;
                            }

                        }
                        break;

                    case ConsoleKey.Spacebar:
                        {
                            Shop = false;
                        }
                        break;
                }
            }

            Console.ResetColor();
            Console.Clear();
        }
        private void PlayerGameSwitch()
        {
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {


                case ConsoleKey.W:
                    if (rocket[index].Y > 8)
                    {
                        rocket[index].Y -= 2;
                    }
                    break;
                case ConsoleKey.A:
                    rocket[index].Uprevleshion = false;
                    break;
                case ConsoleKey.S:
                    if (rocket[index].Y < map.masiv.GetLength(0) - 3)
                    {
                        rocket[index].Y += 2;
                    }
                    break;
                case ConsoleKey.D:
                    rocket[index].Uprevleshion = true;
                    break;
                case ConsoleKey.Q:
                    GetShop();
                    break;
                case ConsoleKey.E: GetImpruveRocket(); break;
                case ConsoleKey.F:
                    if (!rocket[index].BlockOff)
                    {
                        rocket[index].GetBlockSkill(ref map);
                        rocket[index].BlockOff = true;
                    }
                    else
                    {
                        rocket[index].BlockOff = false;
                    }
                    break;
                case ConsoleKey.Spacebar:
                    Potrons++;
                    rocket[index].GetAttack(ref map);

                    break;

            }
        }
        private void PrintGame()
        {
            bool Wars;
            for (int i = 0; i < map.masiv.GetLength(0); i++)
            {
                // Вырисовка Защиты Прочности
                if (i < 10 && i > 1)
                {
                    Console.Write("  ");
                    for (int g = 0; g < 5; g++)
                    {
                        if (rocket[index].XP > i * rocket[index].MaxXP / 10)
                        {
                            Console.Write("░▐▒▌");
                        }
                        else
                        {
                            Console.Write("░ ▓ ");
                        }
                    }
                    Console.Write("░ ║       ");


                }
                else if (i == 0)
                {
                    Console.Write("   Барьерная прочность  ║");
                    if (map.Ability == true)
                    {
                        if (rocket[index].Ability == "Закаление")
                        {
                            Console.Write($"  [");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write($"{RandomChar.RandomCharParticle()}");
                            Console.ResetColor();
                            Console.Write($"]  ");
                        }
                        else if (rocket[index].Ability == "Трекшанс")
                        {
                            Console.Write($"  [");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write($"☼");
                            Console.ResetColor();
                            Console.Write($"]  ");
                        }
                        else if (rocket[index].Ability == "МистерДоллар")
                        {
                            Console.Write($"  [");
                            Console.ForegroundColor = new Random().Next(2) == 1 ? ConsoleColor.DarkMagenta : ConsoleColor.DarkCyan;
                            Console.Write(new Random().Next(2) == 1 ? '$' : '%');
                            Console.ResetColor();
                            Console.Write($"]  ");
                        }
                    }
                    else
                    {
                        Console.Write("       ");
                    }
                }
                else if (i == 12)
                {
                    Console.Write("   Уровень повреждений  ║       ");
                }
                else if (i == 15)
                {
                    Console.Write("     ╔   ╗   ╔   ╗      ║       ");
                }
                else if (i == 16)
                {
                    Console.Write("     ▓ Q ▓   ▓ E ▓      ║       ");
                }
                else if (i == 17)
                {
                    Console.Write("     ╚   ╝   ╚   ╝      ║       ");
                }
                else if (i == 18)
                {
                    Console.Write("     SHOP   IMPRUVE     ║       ");
                }
                else if (i == 13)
                {
                    double result = (double)(1 - (rocket[index].XP / rocket[index].MaxXP)) * 100;
                    result = (int)result;
                    if (result < 10)
                    {
                        Console.Write($"          {result}%            ║       ");
                    }
                    else if (result < 100)
                    {
                        if (result >= 70)
                        {
                            Console.ForegroundColor = new Random().Next(2) == 1 ? ConsoleColor.DarkYellow : ConsoleColor.DarkRed;
                            Console.Write($"          {result}%           ");
                            Console.ResetColor();
                            Console.Write("║       ");
                        }
                        else
                        {
                            Console.Write($"          {result}%           ║       ");
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = new Random().Next(2) == 1 ? ConsoleColor.DarkYellow : ConsoleColor.DarkRed;
                        Console.Write($"          {result}%");
                        Console.ResetColor();
                        Console.Write("          ║       ");
                    }

                }
                else
                {
                    Console.Write("                        ║       ");
                }
                // Вырисовка Защиты Прочности

                // Вырисовка Карты ,Самолетов
                for (int f = 0; f < map.masiv.GetLength(1); f++)
                {

                    //Тут Наноситься Урон По Нашему Кораблю
                    if (f >= rocket[index].X && f < rocket[index].X + rocket[index].masiv.GetLength(1) && i >= rocket[index].Y && i < rocket[index].Y + rocket[index].masiv.GetLength(0))
                    {
                        Console.ForegroundColor = rocket[index].GetColor();

                        if (map.masiv[i, f] == '*')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Metiors++;
                            map.masiv[i - 1, f] = '¤';
                            map.masiv[i, f] = r.Next(2) == 1 ? '╫' : '║';
                            rocket[index].XP -= 0.3;
                        }
                        else if (map.masiv[i, f] == '%')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            StrongMetiors++;
                            map.masiv[i - 1, f] = '¤';
                            map.masiv[i, f] = r.Next(2) == 1 ? '╫' : '║';
                            
                            //Стадии Урона 1 = 1 урона 2 = 2 урона
                            if (map.GamePlay >= 85)
                            {
                                rocket[index].XP -= 1;
                            }
                            else if (map.GamePlay >= 45)
                            {
                                rocket[index].XP -= 2;
                            }
                            else if (map.GamePlay >= 5)
                            {
                                rocket[index].XP -= 3;
                            }
                            else if (map.GamePlay >= 0)
                            {
                                rocket[index].XP -= 5;
                            }
                        }
                        else if (map.masiv[i, f] == '☼')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            map.masiv[i - 1, f] = '¤';
                            rocket[index].XP -= 1;
                        }
                        else if (map.masiv[i, f] == '×')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            SuperMetiors++;
                            map.masiv[i - 1, f] = '¤';
                            map.masiv[i, f] = r.Next(2) == 1 ? '╫' : '║';
                            rocket[index].XP -= 4;
                        }


                        Console.Write(rocket[index].masiv[i - rocket[index].Y, f - rocket[index].X]);
                        Console.ResetColor();
                    } //тут рисуяться враги и тут наноситься им урон!!!
                    else if (map.masiv[i, f] == '%')
                    {
                        if (map.GamePlay >= 85)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                        }
                        else if (map.GamePlay >= 45)
                        {
                            Console.ForegroundColor = new Random().Next(12) == 1 ? ConsoleColor.Red : ConsoleColor.DarkMagenta;
                        }
                        else if (map.GamePlay >= 5)
                        {
                            Console.ForegroundColor = new Random().Next(12) == 1 ? ConsoleColor.Red: ConsoleColor.Green;
                        }
                        else if (map.GamePlay >= 0)
                        {
                            Console.ForegroundColor = new Random().Next(6) == 1 ? ConsoleColor.DarkRed : ConsoleColor.Cyan;
                        }
                        Console.Write(map.masiv[i, f]);
                        Console.ResetColor();
                    }
                    else if (map.masiv[i, f] == '$' || map.masiv[i, f] == '§')
                    {
                        Console.ForegroundColor = new Random().Next(3) == 1 ? ConsoleColor.Red : ConsoleColor.Yellow;
                        Console.Write(map.masiv[i, f]);
                        Console.ResetColor();
                    }
                    else if (map.masiv[i, f] == '☼')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(map.masiv[i, f]);
                        Console.ResetColor();
                    }
                    else if (map.masiv[i, f] == '¤')
                    {
                        Console.ForegroundColor = new Random().Next(2) == 1 ? ConsoleColor.Green : ConsoleColor.DarkRed;
                        Console.Write(map.masiv[i, f]);
                        Console.ResetColor();
                    }
                    else if (map.masiv[i, f] == '×')
                    {
                        Console.ForegroundColor = RandomColor.RandomColor1();
                        Console.Write(map.masiv[i, f]);
                        Console.ResetColor();
                    }
                    else if (map.masiv[i, f] == '↕' || map.masiv[i, f] == '↔')
                    {
                        Console.Write(r.Next(2) == 1 ? '↕' : '↔');
                    }
                    else if (map.masiv[i, f] == '♀' || map.masiv[i, f] == '#')
                    {
                        if (rocket[index].Damage <= 2)
                        {
                            Console.ForegroundColor = RandomColor.RandomColorBlue();
                            Console.Write(map.masiv[i, f]);
                        }
                        else if (rocket[index].Damage <= 4)
                        {
                            Console.ForegroundColor = RandomColor.RandomColorGray_White();
                            Console.Write(map.masiv[i, f]);
                        }
                        else if (rocket[index].Damage <= 6)
                        {
                            Console.ForegroundColor = RandomColor.RandomColorOrange_Red();
                            Console.Write(map.masiv[i, f]);
                        }
                        else if (rocket[index].Damage <= 8)
                        {
                            Console.ForegroundColor = RandomColor.RandomColorYellow_Red();
                            Console.Write(map.masiv[i, f]);
                        }
                        else if (rocket[index].Damage < 10)
                        {
                            Console.ForegroundColor = RandomColor.RandomColorYellow_Red_Orange();
                            Console.Write(map.masiv[i, f]);
                        }
                        else if (rocket[index].Damage >= 10)
                        {
                            Console.ForegroundColor = RandomColor.RandomColorPurple_Gray();
                            Console.Write(map.masiv[i, f]);
                        }
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(map.masiv[i, f]);

                    }

                }

                // Вырисовка Энегрии Вырисовка Энегрии 

                if (i < 10 && i > 1)
                {
                    Console.Write("        ║ ");
                    for (int g = 0; g < 5; g++)
                    {
                        if (rocket[index].Energy > (i * rocket[index].MaxEnergy) / 10)
                        {
                            Console.Write("░▐▒▌");
                        }
                        else
                        {
                            Console.Write("░ ▓ ");
                        }
                    }
                    Console.Write("░");


                }
                else if (i == 0)
                {
                    Console.Write("        ║        Энергия   ");
                }
                else if (i == 12)
                {
                    Console.Write("        ║    Остаток энергии   ");
                }
                else if (i == 13)
                {
                    double result = (double)(rocket[index].Energy / rocket[index].MaxEnergy) * 100;
                    result = (int)result;
                    Console.Write("        ║");
                    if (result <= 30)
                    {
                        Console.ForegroundColor = new Random().Next(2) == 1 ? ConsoleColor.DarkYellow : ConsoleColor.DarkRed;
                        Console.Write($"         {result}%             ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write($"         {result}%             ");
                    }

                }
                else if (i == 15)
                {
                    Console.Write("        ║         Стадия");
                }
                else if (i == 16)
                {
                    if (map.GamePlay <= 4)
                    {
                        Console.Write("        ║");
                        Console.ForegroundColor = RandomColor.RandomColor1();
                        Console.Write($"       Свет победы        ");
                        Console.ResetColor();
                    }
                    else if (map.GamePlay < 10)
                    {
                        Console.Write("        ║");
                        Console.ForegroundColor = new Random().Next(2) == 1 ? ConsoleColor.DarkYellow : ConsoleColor.DarkRed;
                        Console.Write($"     Гнев пробуждён        ");
                        Console.ResetColor();
                    }
                    else if (map.GamePlay < 15)
                    {
                        Console.Write("        ║");
                        Console.ForegroundColor = new Random().Next(2) == 1 ? ConsoleColor.DarkCyan : ConsoleColor.Red;
                        Console.Write($"     Эра нового света       ");
                        Console.ResetColor();
                    }
                    else if (map.GamePlay < 20)
                    {
                        Console.Write("        ║");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($"      Предел Космоса      ");
                        Console.ResetColor();
                    }
                    else if (map.GamePlay < 25)
                    {
                        Console.Write("        ║");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write($"      Начало Конца!           ");
                        Console.ResetColor();
                    }
                    else if (map.GamePlay < 30)
                    {
                        Console.Write("        ║");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write($"      Глава Титанов       ");
                        Console.ResetColor();
                    }
                    else if (map.GamePlay < 35)
                    {
                        Console.Write("        ║");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write($"     Первая Опасность    ");
                        Console.ResetColor();
                    }
                    else if (map.GamePlay < 40)
                    {
                        Console.Write("        ║");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"      Элитные Стражи     ");
                        Console.ResetColor();
                    }
                    else if (map.GamePlay < 50)
                    {
                        Console.Write("        ║");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($"      Первые Враги      ");
                        Console.ResetColor();
                    }
                    else if (map.GamePlay < 60)
                    {
                        Console.Write("        ║");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"      Рассвет Силы      ");
                        Console.ResetColor();
                    }
                    else if (map.GamePlay < 70)
                    {
                        Console.Write("        ║");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write($"      Звёздная Эра     ");
                        Console.ResetColor();
                    }
                    else if (map.GamePlay <= 80)
                    {
                        Console.Write("        ║");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"     Вот и Проблемы..   ");
                        Console.ResetColor();
                    }
                    else if (map.GamePlay <= 90)
                    {
                        Console.Write("        ║");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write($"         Фарминг       ");
                        Console.ResetColor();
                    }
                    else if (map.GamePlay <= 100)
                    {
                        Console.Write("        ║");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"       Подготовка     ");
                        Console.ResetColor();
                    }
                    else if (map.GamePlay >= 100)
                    {
                        Console.Write("        ║");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write($"       Тренировка    ");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.Write("        ║                       ");
                }
                // Вырисовка Энегрии Вырисовка Энегрии 

                Console.WriteLine();
                // Вырисовка Карты, Самолетов
            }
        }
        private void RenderingMap()
        {

            // Spawn Metiors
            if (r.Next(map.GamePlay + 80) <= 1)
            {
                map.masiv[0, r.Next(0, map.masiv.GetLength(1))] = '!';
            }
            if (r.Next(1200) == 1 && map.GamePlay > 2)
            {
                map.GamePlay--;
            }
            for (int i = 0; i < map.masiv.GetLength(1); i++)
            {
                if (map.masiv[0, i] == '!' || map.masiv[0, i] == '?')
                {
                    if (r.Next(30) == 1)
                    {
                        map.masiv[0, i] = ' ';
                        map.masiv[1, i] = '*';
                        if (r.Next(1, map.GamePlay) == 1)
                        {
                            map.masiv[1, i] = '☼';
                            if (r.Next(0, map.GamePlay) == 0)
                            {
                                map.masiv[1, i] = '×';
                            }
                        }
                    }
                    else
                    {
                        map.masiv[0, i] = r.Next(2) == 1 ? '!' : '?';
                    }
                }
            }
            // Spawn Metiors



            // Rocket 

            if (rocket[index].Uprevleshion)
            {
                if (rocket[index].X < (map.masiv.GetLength(1) - rocket[index].masiv.GetLength(1)) + (rocket[index].Speed - 3))
                {
                    rocket[index].X += rocket[index].Speed;

                }
            }
            else
            {

                if (rocket[index].X > rocket[index].Speed - 1)
                {
                    rocket[index].X -= rocket[index].Speed;
                }
            }
            // Rocket 

            //Abilites Abilites Rockets
            if (rocket[index].Ability == "Закаление")
            {
                if (map.Ability == true)
                {
                    rocket[index].XP += 0.4;
                    if (r.Next(100) == 1 || rocket[index].XP >= rocket[index].MaxXP)
                    {
                        map.Ability = false;
                    }
                }
                if (r.Next(150 - rocket[index].Abilitylvl * 10) == 0 && rocket[index].XP < rocket[index].MaxXP)
                {
                    map.Ability = true;
                }
            }
            else if (rocket[index].Ability == "Трекшанс")
            {
                if (r.Next(10) == 1)
                {
                    map.Ability = false;
                }
            }
            else if (rocket[index].Ability == "МистерДоллар")
            {
                if (r.Next(30) == 0)
                {
                    map.Ability = false;
                }
            }

            //Abilites Abilites Rockets

            //Rendering Map 
            for (int i = 0; i < map.masiv.GetLength(0); i++)
            {

                for (int f = 0; f < map.masiv.GetLength(1); f++)
                {
                    int num = 0;
                    //Rendering Mettiors
                    //Rendering Mettiors
                    if (map.masiv[map.masiv.GetLength(0) - 1, f] == '*' || map.masiv[map.masiv.GetLength(0) - 1, f] == '☼' || map.masiv[map.masiv.GetLength(0) - 1, f] == '×' || map.masiv[map.masiv.GetLength(0) - 1, f] == '%' || map.masiv[map.masiv.GetLength(0) - 1, f] == '§' || map.masiv[map.masiv.GetLength(0) - 1, f] == '$')
                    {
                        if (map.masiv[map.masiv.GetLength(0) - 1, f] == '×')
                        {
                            map.masiv[map.masiv.GetLength(0) - 1, f] = '.';
                            if (r.Next(2) == 1)
                                map.masiv[r.Next(1, map.masiv.GetLength(0) - 9), f] = '×';
                            for (int j = 0; j < 6; j++)
                            {
                                map.masiv[r.Next(1, map.masiv.GetLength(0) - 9), f] = '☼';
                            }
                        }
                        if (r.Next(20) == 1)
                        {
                            map.masiv[map.masiv.GetLength(0) - 1, f] = '.';
                        }
                    }
                    else if (map.masiv[map.masiv.GetLength(0) - 1, f] == '.')
                    {
                        if (r.Next(20) == 1)
                        {
                            map.masiv[map.masiv.GetLength(0) - 1, f] = ' ';
                        }
                    }


                    if ((map.masiv[i, f] == '*' || map.masiv[i, f] == '☼' || map.masiv[i, f] == '×' || map.masiv[i, f] == '%' || map.masiv[i, f] == '$' || map.masiv[i, f] == '§') && i < map.masiv.GetLength(0) - 1)
                    {
                        if (map.masiv[i + 1, f] == '↕' || map.masiv[i + 1, f] == '↔')
                        {
                            if ((map.masiv[i, f] == '$' || map.masiv[i, f] == '§') && r.Next(5) == 0)
                            {
                                continue;
                            }
                            else
                            {
                                map.masiv[i, f] = '♀';
                            }
                        }

                        if (map.masiv[i, f] == '%' && (map.masiv[i + 1, f] == ' ' || rocket[index].Damage < 6))
                        {

                            if (r.Next(3) == 0)
                            {
                                map.masiv[i, f] = ' ';
                                map.masiv[i + 1, f] = '%';
                            }

                        }
                        if ((map.masiv[i, f] == '$' || map.masiv[i, f] == '§') && (map.masiv[i + 1, f] != '$' || map.masiv[i + 1, f] != '§'))
                        {
                            if (r.Next(2) == 0)
                            {
                                map.masiv[i, f] = ' ';
                                map.masiv[i + 1, f] = r.Next(3) == 1 ? '$' : '§';
                            }
                            
                        }
                        if (map.masiv[i + 1, f] != '#')
                        {
                            //Проверка на Вражеских Самолетов Если Будет Вражеский Самолет чтобы метеорит пролетал его
                            if (map.masiv[i + 1, f] != ' ')
                            {
                                num = r.Next(map.masiv.GetLength(0) - i);
                            }
                            else
                            {
                                num = 1;
                            }
                            //Проверка на Вражеских Самолетов Если Будет Вражеский Самолет чтобы метеорит пролетал его
                            if (r.Next(3) == 1 && map.masiv[i, f] == '*')
                            {
                                map.masiv[i, f] = r.Next(3) == 1 ? '╫' : '║';
                                map.masiv[i + num, f] = '*';
                            }
                            else if (r.Next(2) == 1 && map.masiv[i, f] == '☼')
                            {
                                map.masiv[i, f] = r.Next(2) == 1 ? '╫' : '║';
                                map.masiv[i + num, f] = '☼';
                            }
                            else if (r.Next(3) == 1 && map.masiv[i, f] == '×')
                            {
                                map.masiv[i, f] = r.Next(2) == 1 ? '╫' : '║';
                                map.masiv[i + num, f] = '×';
                            }
                        }
                        else if (r.Next(3) == 1 && map.masiv[i, f] == '×')
                        {
                            map.masiv[i, f] = r.Next(2) == 1 ? '╫' : '║';
                            map.masiv[i + num, f] = '×';
                        }


                        continue;
                    }
                    else if (map.masiv[i, f] == '╫' || map.masiv[i, f] == '║')
                    {
                        if (r.Next(3) == 1)
                        {
                            map.masiv[i, f] = '│';
                        }
                        continue;
                    }
                    else if (map.masiv[i, f] == '│')
                    {
                        if (r.Next(3) == 1)
                        {
                            map.masiv[i, f] = ' ';
                        }
                        continue;
                    }
                    else if (map.masiv[i, f] == '¤')
                    {
                        if (r.Next(40) == 1)
                        {
                            map.masiv[i, f] = ' ';
                        }
                        continue;
                    }
                    else if (map.masiv[i, f] == '?' || map.masiv[i, f] == '!')
                    {

                        continue;
                    }
                    else if (map.masiv[i, f] == '.')
                    {
                        if (r.Next(20) == 1)
                        {
                            map.masiv[i, f] = ' ';
                        }
                        continue;
                    }
                    else if (map.masiv[i, f] == '♀')
                    {
                        if (map.masiv[1, f] == '♀')
                        {
                            map.masiv[1, f] = ' ';
                        }
                        else
                        {
                            map.masiv[i - 1, f] = '♀';
                            map.masiv[i, f] = r.Next(2) == 1 ? '╫' : '║';
                        }
                        continue;

                    }
                    else if (map.masiv[i, f] == '↕' || map.masiv[i, f] == '↔')
                    {
                        // HFH HFHF HFHHF HFH
                        map.masiv[i, f] = ' ';
                        if (rocket[index].BlockOff)
                        {
                            rocket[index].GetBlockSkill(ref map);
                        }
                        continue;

                        // HFHH HFHH HHFHH HHFH
                    }
                    else if (map.masiv[i, f] == '#')
                    {
                        if (i == 1)
                        {
                            map.masiv[i, f] = ' ';
                        }
                        else
                        {
                            if (map.masiv[i - 1, f] == '$' || map.masiv[i - 1, f] == '§')
                            {
                                
                            }
                            else
                            {
                                map.masiv[i, f] = ' ';
                                map.masiv[i - 1, f] = '#';
                            }
                        }
                        continue;
                    }

                    //Помогает Доделать Анимацию Врагов
                    map.masiv[i, f] = ' ';
                }



            }
            //Rendering Map



            //Spawn Warriors
            if ((warrior.Count < 5 && map.GamePlay >= 100) || (warrior.Count < 10 && map.GamePlay >= 80) || (warrior.Count < 20 && map.GamePlay >= 60) || (warrior.Count < 30 && map.GamePlay >= 40) || (warrior.Count < 50 && map.GamePlay >= 0))
            {
                switch (r.Next(3))
                {
                    case 0:
                        {
                            if (r.Next(map.GamePlay + 5) == 0)
                            {
                                warrior.Add(r.Next(2) == 1 ? new Warriors2() : new Warriors1());
                            }
                        } break;
                    case 1:
                        {
                            if (r.Next(map.GamePlay + 15) == 0)
                            {
                                if (r.Next(5) == 0)
                                {
                                    warrior.Add(new WarriorsMedium3());
                                    break;
                                }
                                warrior.Add(r.Next(2) == 1 ? new WarriorsMedium1() : new WarriorsMedium2());
                            }
                        } break;
                    case 2:
                        {
                            if ((r.Next(1000) == 0 && experience >= 250) || (r.Next(500) == 0 && experience >= 650) || (r.Next(200) == 0 && experience >= 1000) || (r.Next(100) == 0 && experience >= 1500 || (r.Next(50) == 0 && experience >= 2000)))
                            {

                                switch (r.Next(2))
                                {
                                    case 0:
                                        {
                                            warrior.Add(new WarriorsMiniBoss1());
                                        }
                                        break;
                                    case 1:
                                        {
                                            if (r.Next(2) == 0)
                                            {
                                                warrior.Add(new WarriorsMiniBoss2());
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    default: break;
                }

            }
            //Spawn Warriors

            //Warriors Playing


            //  Этот Масив Нужен Для Обработки Смерти Вражеского Корабля
            int[] masiv = new int[warrior.Count];
            int ind = 0;
            //  Этот Масив Нужен Для Обработки Смерти Вражеского Корабля

            foreach (Warriors wr in warrior)
            {
                if (r.Next(20) == 0 && wr.Y > 1)
                {
                    wr.Y--;
                }
                else if (r.Next(15) == 0 && wr.Y < 10)
                {
                    wr.Y++;
                }
                if (r.Next(map.GamePlay + 100) == 0)
                {
                    wr.GetAttack(ref map);
                }

                for (int h = 0; h < wr.masiv.GetLength(0); h++)
                {
                    for (int g = 0; g < wr.masiv.GetLength(1); g++)
                    {
                        if (map.masiv[wr.Y + h, wr.X + g] == '#' || map.masiv[wr.Y + h, wr.X + g] == '♀')
                        {
                            map.masiv[wr.Y + h, wr.X + g] = '¤';
                            wr.XP -= rocket[index].Damage;
                            continue;
                        }

                        map.masiv[wr.Y + h, wr.X + g] = wr.masiv[h, g];

                    }
                }

                if (wr.XP <= 0)
                {
                    //Если В Массиве будет число 1 то значет корабл погиб
                    masiv[ind] = 1;
                    // Это Для Анимации Зрыва Вражеских Самолет
                    for (int h = 0; h < wr.masiv.GetLength(0); h++)
                    {
                        for (int g = 0; g < wr.masiv.GetLength(1); g++)
                        {

                            map.masiv[wr.Y + h, wr.X + g] = '¤';

                        }
                    }
                    // Это Для Анимации Зрыва Вражеских Самолет
                }

                if (wr is WarriorsMiniBoss1 || wr is WarriorsMiniBoss2)
                {
                    // Супер Силы и Атака Мини Боссов!
                    if (r.Next(30) == 0)
                    {
                        wr.GetAttack(ref map);
                    }
                    else if (r.Next(120) == 0)
                    {
                        wr.GetAbility1(ref map);
                    }
                    else if (r.Next(80) == 0)
                    {
                        wr.GetAbility2(ref map);
                    }
                    else if (r.Next(250) == 0)
                    {
                        wr.GetAbility3(ref map);
                    }
                    // Супер Силы и Атака Мини Боссов!


                    if (wr is WarriorsMiniBoss1)
                    {
                        if (wr.XP <= 350)
                        {
                            wr.masiv = new char[,]
                {
                {'▒','_','╨','⌂','╨','_','▒'},
                {'═','_','╫',' ','╫','_','═'}
                };

                            if (r.Next(100) == 0)
                            {
                                wr.masiv = new char[,]
                {
                {'▒','_','╨','⌂','╨','_','▒'},
                {'═','×','╫',' ','╫','×','═'}
                };
                            }
                        }

                        if (wr.XP <= 15)
                        {
                            wr.XP--;
                            wr.masiv = new char[,]
            {
                {'▒','_','╨','⌂','╨','_','▒'},
                {'═','×','╫',' ','╫','×','═'}
            };
                        }
                    }
                    else if (wr is WarriorsMiniBoss2)
                    {
                        wr.masiv = new char[,]
            {
                {'╪',' ','_','v','_',' ','╪'},
                {'■',' ','╪',' ','╪',' ','■'}
            };
                        if (wr.XP <= 600 && r.Next(2) == 0)
                        {
                            wr.GetAbility3(ref map);
                        }

                        if (wr.XP <= 100)
                        {
                            wr.XP--;
                            wr.masiv = new char[,]
            {
                {'╪',' ','_','v','_',' ','╪'},
                {'×',' ','╪',' ','╪',' ','×'}
            };
                        }
                    }




                    // Рендеринг Мини Боссов, Передвижение
                    if (!wr.muve && wr.X < ((map.masiv.GetLength(1) - 5) - wr.masiv.GetLength(1)))
                    {
                        if (r.Next(25) == 1)
                            wr.muve = true;
                        wr.X++;
                        if ((wr.XP <= 100 && wr is WarriorsMiniBoss1) || (wr.XP <= 400 && wr is WarriorsMiniBoss2))
                        {
                            wr.X++;

                        }
                    }
                    else if (wr.muve && wr.X > 2)
                    {
                        wr.X--;
                        if ((wr.XP <= 100 && wr is WarriorsMiniBoss1) || (wr.XP <= 400 && wr is WarriorsMiniBoss2))
                        {
                            wr.X--;
                        }
                    }
                    else
                    {
                        wr.muve = r.Next(2) == 0 ? true : false;
                    }
                    // Рендеринг Мини Боссов, Передвижение
                }
                else if (wr is WarriorsMedium1 || wr is WarriorsMedium2 || wr is WarriorsMedium3)
                {
                    if ((wr.XP <= 12) || (wr is WarriorsMedium3 && wr.XP <= 35))
                    {
                        wr.masiv = new char[,]
                        {
                           {'╪','»','+','«','╪'}
                        };
                        if (wr is WarriorsMedium3)
                        {
                            wr.masiv = new char[,]
                            {
                          {'▒','_','⌂','_','▒'},
                          {'═','(',' ',')','═'}
                            };
                            if (r.Next(15) == 0)
                            {
                                wr.masiv = new char[,]
                            {
                          {'▒','_','⌂','_','▒'},
                          {'═','(','☼',')','═'}
                            };
                            }
                        }
                        
                    }

                    if (!wr.muve && wr.X < ((map.masiv.GetLength(1) - 5) - wr.masiv.GetLength(1)))
                    {
                        if (r.Next(25) == 1)
                            wr.muve = true;
                        wr.X++;
                        if (wr.XP <= 12)
                        {
                            if ((r.Next(10) == 0) && wr is WarriorsMedium2 || wr is WarriorsMedium1)
                            {
                                wr.X++;
                            }
                            
                        }
                    }
                    else if (wr.muve && wr.X > 2)
                    {
                        wr.X--;
                        if (wr.XP <= 12)
                        {
                            if ((r.Next(10) == 0) && wr is WarriorsMedium2 || wr is WarriorsMedium1)
                            {
                                wr.X--;
                            }
                            
                        }
                    }
                    else
                    {
                        wr.muve = r.Next(2) == 0 ? true : false;
                    }
                }
                else if (wr is Warriors1 || wr is Warriors2)
                {


                    if (!wr.muve && wr.X < ((map.masiv.GetLength(1) - 4) - wr.masiv.GetLength(1)))
                    {
                        if (r.Next(25) == 1)
                            wr.muve = true;
                        wr.X++;
                    }
                    else if (wr.muve && wr.X > 1)
                    {
                        wr.X--;
                    }
                    else
                    {
                        wr.muve = r.Next(2) == 0 ? true : false;
                    }
                }

               

                ind++;
            }




            for (int i = 0; i < warrior.Count; i++)
            {
                if (masiv[i] == 1)
                {



                    // Это Сколько мы получим после Зрыва Самолета
                    int mony = 0;
                    mony += warrior[i].Money;
                    // Это Для Увелечение Денег
                    if (rocket[index].Ability == "МистерДоллар")
                    {
                        map.Ability = true;
                        mony += mony * (int)(rocket[index].Abilitylvl / 2);
                    }

                    money += mony;
                    // Это Сколько мы получим после Зрыва Самолета


                    warrior.RemoveAt(i);
                }
            }
            //Warriors Playing
        }

    }

    
}
    


