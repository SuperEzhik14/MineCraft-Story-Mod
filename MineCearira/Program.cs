

using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace MineCearira
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            foreach (ConsoleColor color in Enum.GetValues(typeof(ConsoleColor)))
            {
                Console.ForegroundColor = color;
                Console.WriteLine(color);
            }

            


            
        }

    }
}
