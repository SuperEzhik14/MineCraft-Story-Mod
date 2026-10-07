using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarsWars
{
    class Map
    {
        public bool Ability;
        public int GamePlay;
        public char[,] masiv = new char[25, 40];
        public Map()
        {
            for (int i = 0; i < masiv.GetLength(0); i++)
            {
                for (int f = 0; f < masiv.GetLength(1); f++)
                {
                    masiv[i, f] = ' ';
                }
            }

            //начало stars wars

            char randomChar()
            {

                switch (new Random().Next(29))
                {
                    case 0: return '#';
                    case 1: return '!';
                    case 2: return '@';
                    case 3: return '%';
                    case 4: return '+';
                    case 5: return '$';
                    case 6: return '*';
                    case 7: return 'q';
                    case 8: return 'w';
                    case 9: return 'e';
                    case 10: return 'r';
                    case 11: return 't';
                    case 12: return 'y';
                    case 13: return '*';
                    case 14: return 's';
                    case 15: return 'a';
                    case 16: return 'd';
                    case 17: return 'f';
                    case 18: return 'g';
                    case 19: return 'h';
                    case 20: return 'k';
                    case 21: return 'z';
                    case 22: return 'x';
                    case 23: return 'l';
                    case 24: return 'b';
                    case 25: return 'n';
                    case 26: return 'i';
                    case 27: return 'n';
                    default: return '-';

                }
            }
            string obj = "..........%%%%...%%%%%%...%%%%...%%%%%....%%%%...........%%...%%...%%%%...%%%%%....%%%%..................";
            string jpn = "..........%%%%...%%%%%%...%%%%...%%%%%....%%%%...........%%...%%...%%%%...%%%%%....%%%%...........................%%........%%....%%..%%..%%..%%..%%..............%%...%%..%%..%%..%%..%%..%%...............................%%%%.....%%....%%%%%%..%%%%%....%%%%...........%%.%.%%..%%%%%%..%%%%%....%%%%...............................%%....%%....%%..%%..%%..%%......%%..........%%%%%%%..%%..%%..%%..%%......%%...........................%%%%.....%%....%%..%%..%%..%%...%%%%............%%.%%...%%..%%..%%..%%...%%%%...........................................................................................................................";
            int num = 0;
            int X2 = -40;
            int speed = 1;
            int X = 0;
            int num2 = 0;
            bool remt = true;
            char[,] masiv2 = new char[6, obj.Length];
            for (int i = 0; i < 6; i++)
            {
                for (int v = 0; v < obj.Length; v++, num++)
                {
                    masiv2[i, v] = jpn[num];
                }
            }
            while (true)
            {
                if (num2 == 200)
                    break;
                num2++;
                Console.ForegroundColor = ConsoleColor.Gray;
                //Вырисовка Stars Wars   
                if (remt)
                {
                    if (X >= obj.Length + 70)
                    {
                        remt = false;
                        speed++;
                        continue;
                    }
                    X += speed;
                    X2 += speed;
                }
                else
                {
                    if (X <= -15)
                    {
                        remt = true;
                        speed++;
                        continue;
                    }
                    X2 -= speed;
                    X -= speed;
                }
                num = 0;
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < 9; i++)
                {
                    Console.WriteLine(".........................................................................................................");
                }
                for (int i = 0; i < masiv2.GetLength(0); i++)
                {
                    for (int v = 0; v < masiv2.GetLength(1); v++)
                    {
                        if (v < X - num && v > X2 - num && masiv2[i, v] == '%')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("#");
                        }
                        else if (masiv2[i, v] == '%')
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(masiv2[i, v]);
                        }
                        else
                        {
                            Console.Write(masiv2[i, v]);
                        }
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    num += 3;
                    Console.WriteLine();
                }
                

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(".........................................................................................................");
                }
                
                //Вырисовка Stars Wars
            }

            //начало stars wars
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine("\n\t\t\t      10 ULTRA HARD   20 HARD   35 MEDIUM   50 EASY");
            Console.WriteLine("\n\n\t\t\t\t\t   Выбирите Сложность");
            Console.Write("\t\t\t\t\t\t   ");
            ConsoleKey k = Console.ReadKey().Key;
            if (k == ConsoleKey.Spacebar)
            {
                GamePlay = 115;
            }
            else
            {
                Console.WriteLine();
                Console.Write("\t\t\t\t\t\t   ");
                GamePlay = int.Parse(Console.ReadLine());
            }
        }

    }
}
