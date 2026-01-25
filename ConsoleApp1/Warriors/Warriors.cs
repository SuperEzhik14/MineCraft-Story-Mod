using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarsWars.Warriorsa
{
    
    class Warriors1 : Warriors
    {
        public void GetAttack(ref Map map)
        {
            map.masiv[Y + 1, X + 1] = '%';
            map.masiv[Y + 3, X + 1] = '%';
            
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
        public Warriors1()
        {
            Money = 10;
            X = new Random().Next(3, 36);
            Y = 1;
            XP = 8;
            masiv = new char[,]
            {
                {'╤','_','╤' }
            };

        }
    }
    class Warriors2 : Warriors
    {
        public void GetAttack(ref Map map)
        {
            map.masiv[Y + 1, X + 1] = '%';
            

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
        public Warriors2()
        {
            Money = 10;
            X = new Random().Next(3, 36);
            Y = 1;
            XP = 8;
            masiv = new char[,]
            {
                {'_','⌂','_'}
            };

        }
    }
}
