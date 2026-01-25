using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarsWars.Warriorsa
{
    class WarriorsMedium1 : Warriors
    {
        public void GetAttack(ref Map map)
        {
            if (new Random().Next(map.GamePlay + 50) == 0)
            {
                map.masiv[Y + 1, X] = '%';
                map.masiv[Y + 1, X + 2] = '%';
                map.masiv[Y + 2, X + 4] = '%';
            }
            else
            {
                map.masiv[Y + 1, X    ] = '%';
                map.masiv[Y + 1, X + 2] = '%';  
                map.masiv[Y + 2, X + 4] = '%';
            }
        }
        public void GetAbility1(ref Map map)
        {

        }
        public void GetAbility2(ref Map map)
        {

        }
        public void GetAbility3(ref Map map)
        {

        }
        public ConsoleColor GetColor()
        {
            return ConsoleColor.Green;
        }
        public bool muve { get; set; }
        public int Money { get; set; }
        public int XP { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public char[,] masiv { get; set; }
        public WarriorsMedium1()
        {
            Money = 30;
            X = new Random().Next(3, 36);
            Y = 3;
            XP = 25;
            masiv = new char[,]
            {
                {'╤','»','_','«','╤'}      
            };
        }
    }
    class WarriorsMedium2 : Warriors
    {
        public void GetAttack(ref Map map)
        {
            map.masiv[Y + 1, X + 1] = '%';
            map.masiv[Y + 1, X + 3] = '%';
            map.masiv[Y + 2, X + 1] = '%';
            map.masiv[Y + 2, X + 3] = '%';
            
        }
        public void GetAbility1(ref Map map)
        {

        }
        public void GetAbility2(ref Map map)
        {

        }
        public void GetAbility3(ref Map map)
        {

        }
        public ConsoleColor GetColor()
        {
            return ConsoleColor.Green;
        }
        public bool muve { get; set; }
        public int Money { get; set; }
        public int XP { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public char[,] masiv { get; set; }
        public WarriorsMedium2()
        {
            Money = 35;
            X = new Random().Next(3, 36);
            Y = 3;
            XP = 30;
            masiv = new char[,]
            {
                {']','_','^','_','['}
            };
        }
    }
    class WarriorsMedium3 : Warriors
    {
        public void GetAttack(ref Map map)
        {
            if (new Random().Next(map.GamePlay + 50) == 0)
            {
                map.masiv[Y + 2, X + 1] = '%';
                map.masiv[Y + 2, X + 3] = '%';
                map.masiv[Y + 2, X] = '%';
                map.masiv[Y + 2, X + 4] = '%';
                map.masiv[Y + 3, X + 1] = '%';
                map.masiv[Y + 3, X + 3] = '%';

            }
            else
            {
                map.masiv[Y + 2, X + 1] = '%';
                map.masiv[Y + 2, X + 3] = '%';
                map.masiv[Y + 3, X + 1] = '%';
                map.masiv[Y + 2, X + 2] = '%';
                map.masiv[Y + 3, X + 3] = '%';
            }
        }
        public void GetAbility1(ref Map map)
        {

        }
        public void GetAbility2(ref Map map)
        {

        }
        public void GetAbility3(ref Map map)
        {

        }
        public ConsoleColor GetColor()
        {
            return ConsoleColor.Green;
        }
        public bool muve { get; set; }
        public int Money { get; set; }
        public int XP { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public char[,] masiv { get; set; }
        public WarriorsMedium3()
        {
            Money = 75;
            X = new Random().Next(3, 36);
            Y = 3;
            XP = 80;
            masiv = new char[,]
            {
                {'▒','_','⌂','_','▒'},
                {'═','_',' ','_','═'}
            };
        }
    }
}
