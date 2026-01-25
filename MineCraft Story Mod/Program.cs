
using System.Runtime.InteropServices;

namespace MineCraft_Story_Mod
{

    enum Color
    {
        Red,
        Yellow,
        Blue
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(printLVLforShop2(800,10));
        }
        public static string printLVLforShop2(double num, int maxlvl)
        {
            string result = "";
            for (int i = 0; i < maxlvl;i++)
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
