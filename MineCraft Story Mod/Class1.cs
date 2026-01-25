using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MineCraft_Story_Mod
{
    interface IBook
    {
        string name { get; }
        public void Info()
        {
            Console.WriteLine($"Это Книга: {name}");
        }
    }
    
    class EngLish : IBook
    {
        public string name { get; } = "EngLish";
    }
    class Programing : IBook
    {
        public string name { get; } = "Programing";
    }
    class GameDev : IBook
    {
        public string name { get; } = "GameDev";
        void IBook.Info()
        {
            Console.WriteLine("Эта Книга только в Интернете!");
        }

    }
    class History : IBook
    {
        public string name { get; } = "History";
    }
}
