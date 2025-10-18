using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarsWars
{
    
    class Game
    {
        private void Restart()
        {
            game = true;
            map = new Map();
            rocket = new RocketStrong();
            Metiors = 0;
            StrongMetiors = 0;
            SuperMetiors = 0;
            Potrons = 0;
          

        }
        
        private int Metiors;
        private int StrongMetiors;
        private int SuperMetiors;
        private int Potrons;

        private Rockets rocket;
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
                        if (rocket.Energy <= 0 || rocket.XP <= 0)
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
                rocket.masiv[r.Next(rocket.masiv.GetLength(0)), r.Next(rocket.masiv.GetLength(1))] = RandomChar.RandomCharOver();
            }
        }
        private void GetShop()
        {

        }
        private void PlayerGameSwitch()
        {
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                
                
                case ConsoleKey.W:
                    if (rocket.Y > 8)
                    {
                        rocket.Y -= 2;
                    }
                    break;
                case ConsoleKey.A:
                    rocket.Uprevleshion = false;
                    break;
                case ConsoleKey.S:
                    if (rocket.Y < map.masiv.GetLength(0) - 3)
                    {
                        rocket.Y += 2;
                    }
                    break;
                case ConsoleKey.D:
                    rocket.Uprevleshion = true;
                    break;
                case ConsoleKey.Q:
                    GetShop();
                    break;
                case ConsoleKey.F:
                    if (!rocket.BlockOff)
                    {
                        rocket.GetBlockSkill(ref map);
                        rocket.BlockOff = true;
                    }
                    else
                    {
                        rocket.BlockOff = false;
                    }
                        break;
                case ConsoleKey.Spacebar:
                    Potrons++;
                    rocket.GetAttack(ref map);
                    
                    break;

            }
        } 
        private void PrintGame()
        {
            for (int i = 0; i < map.masiv.GetLength(0); i++)
            {
                // Вырисовка Защиты Прочности
                if (i < 10 && i > 1)
                {
                    Console.Write("  ");
                    for (int g = 0; g < 5; g++)
                    {
                        if (rocket.XP > i * rocket.MaxXP / 10)
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
                    Console.Write("   Барьерная прочность  ║       ");
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
                    double result = (double)(1 - (rocket.XP / rocket.MaxXP)) * 100;
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
                    //Тут Наноситься Урон По Кораблю
                    if (f >= rocket.X && f < rocket.X + rocket.masiv.GetLength(1) && i >= rocket.Y && i < rocket.Y + rocket.masiv.GetLength(0))
                    {
                       
                        Console.ForegroundColor = rocket.GetColor();
                        if (map.masiv[i, f] == '*')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Metiors++;
                            map.masiv[i - 1, f] = '¤';
                            map.masiv[i, f] = r.Next(2) == 1 ? '╫' : '║';
                            rocket.XP -= 0.3;
                        }
                        else if (map.masiv[i, f] == '☼')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            StrongMetiors++;
                            map.masiv[i - 1, f] = '¤';
                            map.masiv[i, f] = r.Next(2) == 1 ? '╫' : '║';
                            rocket.XP -= 1;
                        }
                        else if (map.masiv[i, f] == '×')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            SuperMetiors++;
                            map.masiv[i - 1, f] = '¤';
                            map.masiv[i, f] = r.Next(2) == 1 ? '╫' : '║';
                            rocket.XP -= 4;
                        }

                       
                        Console.Write(rocket.masiv[i - rocket.Y, f - rocket.X]);
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
                    else if (map.masiv[i, f] == '♀' || map.masiv[i, f] == '#' || map.masiv[i, f] == '^')
                    {
                        Console.ForegroundColor = RandomColor.RandomColorBlue();
                        Console.Write(map.masiv[i, f]);
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
                        if (rocket.Energy > (i * rocket.MaxEnergy) / 10)
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
                    double result = (double)(rocket.Energy / rocket.MaxEnergy) * 100;
                    result = (int)result;
                    Console.Write("        ║");
                    if (result <= 30)
                    {
                        Console.ForegroundColor =new Random().Next(2) == 1 ? ConsoleColor.DarkYellow : ConsoleColor.DarkRed;
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
                    Console.Write("        ║       Сложность");
                }
                else if (i == 16)
                {
                    if (map.GamePlay <= 3)
                    {
                        Console.Write("        ║");
                        Console.ForegroundColor = new Random().Next(2) == 1 ? ConsoleColor.DarkYellow : ConsoleColor.DarkRed;
                        Console.Write($"      Адский режим");
                        Console.ResetColor();
                    }
                    else if (map.GamePlay < 10)
                    {
                        Console.Write("        ║");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"     Экстремальная   ");
                        Console.ResetColor();
                    }
                    else if (map.GamePlay < 20)
                    {
                        Console.Write("        ║");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write($"        Опасная    ");
                        Console.ResetColor();
                    }
                    else if (map.GamePlay < 30)
                    {
                        Console.Write("        ║");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write($"      Нормальная    ");
                        Console.ResetColor();
                    }
                    else if (map.GamePlay >= 30)
                    {
                        Console.Write("        ║");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write($"      Безопасная   ");
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
            if (r.Next(map.GamePlay) <= 1)
            {
                map.masiv[0, r.Next(0, map.masiv.GetLength(1))] = '!';
            }
            if (r.Next(75) == 1 && map.GamePlay > 1)
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
                        if (r.Next(1,map.GamePlay) == 1)
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

            if (rocket.Uprevleshion)
            {
                if (rocket.X < (map.masiv.GetLength(1) - rocket.masiv.GetLength(1)) + (rocket.Speed - 3))
                {
                    rocket.X += rocket.Speed;

                }
            }
            else
            {
                
                if (rocket.X > rocket.Speed - 1)
                {
                    rocket.X -= rocket.Speed;
                }
            }
            // Rocket 



            //Rendering Map 
            for (int i = 0; i < map.masiv.GetLength(0); i++)
            {
                for (int f = 0; f < map.masiv.GetLength(1); f++)
                {                   


                    if (map.masiv[map.masiv.GetLength(0) - 1, f] == '*' || map.masiv[map.masiv.GetLength(0) - 1, f] == '☼' || map.masiv[map.masiv.GetLength(0) - 1, f] == '×')
                    {
                        if (map.masiv[map.masiv.GetLength(0) - 1, f] == '×')
                        {
                            map.masiv[map.masiv.GetLength(0) - 1, f] = '.';
                            if (r.Next(3) == 1)
                                map.masiv[r.Next(1, map.masiv.GetLength(0) - 9), f] = '×';
                            for (int j = 0; j < 3; j++)
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

                    
                    if ((map.masiv[i, f] == '*' || map.masiv[i, f] == '☼' || map.masiv[i, f] == '×') && i < map.masiv.GetLength(0) - 1)
                    {
                        if (map.masiv[i + 1, f] == '^')
                        {
                            map.masiv[i, f] = '♀';
                        }
                        if (map.masiv[i + 1, f] != '#')
                        {
                            if (r.Next(3) == 1 && map.masiv[i, f] == '*')
                            {
                                map.masiv[i, f] = r.Next(3) == 1 ? '╫' : '║';
                                map.masiv[i + 1, f] = '*';
                            }
                            else if (r.Next(2) == 1 && map.masiv[i, f] == '☼')
                            {
                                map.masiv[i, f] = r.Next(2) == 1 ? '╫' : '║';
                                map.masiv[i + 1, f] = '☼';
                            }
                            else if (r.Next(2) == 1 && map.masiv[i, f] == '×' )
                            {
                                map.masiv[i, f] = r.Next(2) == 1 ? '╫' : '║';
                                map.masiv[i + 1, f] = '×';
                            }
                        }
                        

                    }
                    else if (map.masiv[i, f] == '╫' || map.masiv[i, f] == '║')
                    {
                        if (r.Next(3) == 1)
                        {
                            map.masiv[i, f] = '│';
                        }
                    }
                    else if (map.masiv[i, f] == '│')
                    {
                        if (r.Next(3) == 1)
                        {
                            map.masiv[i, f] = ' ';
                        }

                    }
                    else if (map.masiv[i, f] == '¤')
                    {
                        if (r.Next(40) == 1)
                        {
                            map.masiv[i, f] = ' ';
                        }
                    }
                    else if (map.masiv[i, f] == '♀')
                    {
                        if (map.masiv[0, f] == '♀')
                        {
                            map.masiv[0, f] = ' ';
                        }
                        else
                        {
                            map.masiv[i - 1, f] = '♀';
                            map.masiv[i, f] = r.Next(2) == 1 ? '╫' : '║';
                        }                            
                    }
                    else if (map.masiv[i, f] == '^')
                    {
                        // HFH HFHF HFHHF HFH
                        map.masiv[i, f] = ' ';
                        if (rocket.BlockOff)
                        {
                            rocket.GetBlockSkill(ref map);
                        }


                        // HFHH HFHH HHFHH HHFH
                    }
                    else if (map.masiv[i, f] == '#')
                    {
                        if (i > 0)
                        {
                            map.masiv[i, f] = ' ';
                            map.masiv[i - 1, f] = '#';
                            
                        }
                        else
                        {
                            map.masiv[i, f] = ' ';
                        }
                    }

                }
            }
            //Rendering Map

        }
    }
    

}
