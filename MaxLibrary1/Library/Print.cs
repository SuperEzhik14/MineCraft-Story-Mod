using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maks.Library
{
    public static class Print
    {
        public static string PrintInImpruvingDollars(int num)
        {
            string str2 = Convert.ToString(num);
            string str = "";
            for (int i = str2.Length; i < 4; i++)
            {
                str += " ";
            }
            str += str2;
            str += "$";
            return str;
        }
        public static string PrintInImpruving(int num)
        {
            string str2 = Convert.ToString(num);
            string str = "";
            for (int i = str2.Length; i < 7; i++)
            {
                str += " ";
            }
            str += Convert.ToString(num);

            return str;
        }
        public static string printzagryska(int num)
        {
            string result = "";
            for (int i = 0; i < 10; i++)
            {
                if (i * 80 < num)
                {
                    result += "■";
                }
                else
                {
                    result += " ";
                }
            }
            return result;
        }
        public static string printLVLforShop(int num, int maxlvl)
        {

            string result = "";
            for (int i = 0; i < maxlvl; i++)
            {
                if (i < num)
                {
                    result += "█";
                }
                else
                {
                    result += "▒";
                }
            }
            return result;
        }
        public static string printLVLforShop2(double num, int maxlvl)
        {
            string result = "";
            for (int i = 0; i < maxlvl; i++)
            {
                if (i * 100 < num)
                {
                    result += "☼";
                }
                else
                {
                    result += " ";
                }

            }
            return result;
        }
    }
}
