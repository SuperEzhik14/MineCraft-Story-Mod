using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarsWars.Warriorsa
{
    
    class WarriorsMiniBoss1 : Warriors
    {
        public void GetAttack(ref Map map)
        {
            if (new Random().Next(map.GamePlay + 50) == 0)
            {
                map.masiv[Y + 2, X] = '§';
                map.masiv[Y + 2, X + 2] = '§';
                map.masiv[Y + 2, X + 4] = '§';
                map.masiv[Y + 2, X + 6] = '§';

                map.masiv[Y + 3, X + 1] = '%';
                map.masiv[Y + 3, X + 5] = '%';
                map.masiv[Y + 4, X + 1] = '%';
                map.masiv[Y + 4, X + 5] = '%';

            }
            else
            {
                map.masiv[Y + 2, X] = '%';
                map.masiv[Y + 2, X + 2] = '%';
                map.masiv[Y + 2, X + 4] = '%';
                map.masiv[Y + 2, X + 6] = '%';

                map.masiv[Y + 3, X + 1] = '%';
                map.masiv[Y + 3, X + 5] = '%';
            }

        }
        public void GetAbility1(ref Map map)
        {
            for (int i = 0; i < new Random().Next(10,25); i++)
            {
                map.masiv[Y + new Random().Next(3, 7), X + new Random().Next(0, 7)] = new Random().Next(20) == 0 ? '§' : '%';
            }   
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
        public WarriorsMiniBoss1()
        {
            Money = 650;
            X = new Random().Next(3, 36);
            Y = 5;
            XP = 750;
            masiv = new char[,]
            {
                {'▒','_','╨','⌂','╨','_','▒'},
                {'═','_','╫',' ','╫','_','═'}
            };
        }
    }
    class WarriorsMiniBoss2 : Warriors
    {
        public void GetAttack(ref Map map)
        {
            if (new Random().Next(map.GamePlay + 50) == 0)
            {
                map.masiv[Y + 2, X + 1] = '§';
                map.masiv[Y + 2, X + 3] = '§';
                map.masiv[Y + 2, X + 5] = '§';


                map.masiv[Y + 3, X] = '§';
                map.masiv[Y + 3, X + 2] = '§';
                map.masiv[Y + 3, X + 4] = '§';
                map.masiv[Y + 3, X + 6] = '§';

            }
            else
            {
                map.masiv[Y + 2, X + 1] = '%';
                map.masiv[Y + 2, X + 3] = '%';
                map.masiv[Y + 2, X + 5] = '%';


                map.masiv[Y + 3, X    ] = '%';
                map.masiv[Y + 3, X + 2] = '%';
                map.masiv[Y + 3, X + 4] = '%';
                map.masiv[Y + 3, X + 6] = '%';
            }

        }
        public void GetAbility1(ref Map map)
        {
            for (int i = 0; i < 3; i++)
            {
                map.masiv[Y + (2 + i), X + 2] = '§';
                map.masiv[Y + (2 + i), X + 2] = '§';
                map.masiv[Y + (2 + i), X + 4] = '§';
            }
        }
        public void GetAbility2(ref Map map)
        {
            XP += 100;
        }
        public void GetAbility3(ref Map map)
        {
            if (new Random().Next(10) == 0)
            {
                masiv = new char[,]
            {
                {'╪',' ','_','v','_',' ','╪'},
                {'■',' ','╪',' ','╪',' ','■'}
            };
            }
            else
            {
                masiv = new char[,]
            {
                {'╪','_','v','_','╪'},
                {'■','╪',' ','╪','■'}
            };
            }
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
        public WarriorsMiniBoss2()
        {
            Money = 900;
            X = new Random().Next(3, 36);
            Y = 5;
            XP = 1250;
            masiv = new char[,]
            {
                {'╪',' ','_','v','_',' ','╪'},
                {'■',' ','╪',' ','╪',' ','■'}
            };
        }
    }
}
