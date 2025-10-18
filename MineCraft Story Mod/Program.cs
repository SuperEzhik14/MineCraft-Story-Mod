using System.ComponentModel.Design;
using System.Runtime.InteropServices;

namespace MineCraft_Story_Mod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (ConsoleColor color in Enum.GetValues(typeof(ConsoleColor)))
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"Это цвет: {color}");
            }

            // Возвращаем стандартный цвет
            int[] gg = new int[17];
            Console.WriteLine(gg.Length);
            Console.ResetColor();
            Console.WriteLine("^♀");


        }
       
        
    }
}
