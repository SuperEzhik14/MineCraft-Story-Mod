using MineCearira.MyFormula;

namespace MineCearira
{
    internal class Program
    {
        class Car
        {
            public IEngine engine = new EngineHap();
        }
        static void Main(string[] args)
        {
            Car car = new Car();
            car.engine.Start();
        }
    }
}
