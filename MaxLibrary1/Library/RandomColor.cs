using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maks.Library
{
    public static class RandomColor
    {
        public static ConsoleColor RandomColorYellow_Red_Orange()
        {
            switch (new Random().Next(6))
            {
                case 0: return ConsoleColor.DarkRed;
                case 1: return ConsoleColor.DarkYellow;
                case 2: return ConsoleColor.Green;
                case 3: return ConsoleColor.DarkRed;
                case 4: return ConsoleColor.DarkYellow;
                case 5: return ConsoleColor.Green;
                default: return ConsoleColor.Red;
            }
        }
        public static ConsoleColor RandomColorYellow_Red()
        {
            return new Random().Next(2) == 1 ? ConsoleColor.DarkRed : ConsoleColor.Green;
        }
        public static ConsoleColor RandomColorOrange_Red()
        {
            return new Random().Next(2) == 1 ? ConsoleColor.Green : ConsoleColor.DarkYellow;
        }
        public static ConsoleColor RandomColorGray_White()
        {
            return new Random().Next(2) == 1 ? ConsoleColor.Cyan : ConsoleColor.Gray;
        }
        public static ConsoleColor RandomColorBlue()
        {
            return new Random().Next(2) == 1 ? ConsoleColor.Blue : ConsoleColor.DarkBlue;
        }
        public static ConsoleColor RandomColorRed()
        {
            return new Random().Next(2) == 1 ? ConsoleColor.DarkRed : ConsoleColor.DarkYellow;
        }
        public static ConsoleColor RandomColorPurple_Gray()
        {
            return new Random().Next(10) == 1 ? ConsoleColor.Red : ConsoleColor.White;
        }
        public static ConsoleColor RandomColor2()
        {
            return new Random().Next(2) == 1 ? ConsoleColor.Blue : ConsoleColor.Red;
        }
        public static ConsoleColor RandomColor1()
        {
            switch (new Random().Next(16))
            {
                case 0: return ConsoleColor.Magenta;
                case 1: return ConsoleColor.Yellow;
                case 2: return ConsoleColor.Green;
                case 3: return ConsoleColor.Cyan;
                case 4: return ConsoleColor.Red;
                case 5: return ConsoleColor.White;
                case 6: return ConsoleColor.Black;
                case 7: return ConsoleColor.Gray;
                case 8: return ConsoleColor.DarkGray;
                case 9: return ConsoleColor.Blue;
                case 10: return ConsoleColor.DarkBlue;
                case 11: return ConsoleColor.DarkRed;
                case 12: return ConsoleColor.DarkGreen;
                case 13: return ConsoleColor.DarkCyan;
                case 14: return ConsoleColor.DarkMagenta;
                case 15: return ConsoleColor.DarkYellow;
                default: return ConsoleColor.Red;
            }
        }
        public static ConsoleColor RandomColorOrange()
        {
            switch (new Random().Next(3))
            {
                case 0: return ConsoleColor.DarkRed;
                case 1: return ConsoleColor.DarkMagenta;
                case 2: return ConsoleColor.Green;

                default: return ConsoleColor.Red;
            }
        }
    }
}
