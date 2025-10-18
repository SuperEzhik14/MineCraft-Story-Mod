using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineCearira.MyFormula
{
    interface IEngine
    {
        int Strength { get; }
        int MaxSpeed { get; }
        void Start();
    }
    class EngineBergo : IEngine
    {
        public int Strength { get; } = 15;

        public int MaxSpeed { get; } = 700;

        void IEngine.Start()
        {
            Console.WriteLine($"Двигатель Запущен! {Strength} {MaxSpeed}");
        }
    }
    class EngineHap : IEngine
    {
        public int Strength { get; } = 5;

        public int MaxSpeed { get; } = 300;

        void IEngine.Start()
        {
            Console.WriteLine($"Двигатель Запущен! {Strength} {MaxSpeed}");
        }
    }
    
}
