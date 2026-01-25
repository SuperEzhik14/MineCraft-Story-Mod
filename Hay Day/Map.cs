using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hay_Day
{
    class Map
    {
        public char[,] masiv;
        public Map()
        {
            int num, num2;
            //Заполнение Размера Карты
            while (true)
            {
                Console.WriteLine("Создайте Размер Карты");
                Console.Write("Y = ");
                num = int.Parse(Console.ReadLine());
                Console.Write("X = ");
                num2 = int.Parse(Console.ReadLine());
                if (num >= 9 && num2 >= 9)
                {
                    Console.WriteLine("Карта Успешно Создана!");
                    masiv = new char[num, num2];
                    Thread.Sleep(500);
                    Console.Clear();
                    break;
                    
                }
                else
                {
                    Console.WriteLine("Карта Не Создана(");
                    Console.WriteLine("X,Y Должны быть хотябы = 6");
                    Console.WriteLine("Попробуйте Заново...");
                    Thread.Sleep(2000);
                }
                Console.Clear();
            }
            //Заполнение Размера Карты
            for (int i = 0; i < masiv.GetLength(0); i++)
            {
                for (int j = 0; j < masiv.GetLength(1); j++)
                {
                    masiv[i, j] = ' ';
                }
            }
        }
    }
}
