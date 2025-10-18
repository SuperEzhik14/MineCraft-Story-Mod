using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBull
{
    class Person
    {
        public readonly string Name;
        public readonly int Age;
        private ICard card;
        public Person(string name,int age,ICard card)
        {
            this.Age = age; 
            this.Name = name;
            this.card = card;
        }
        public void Credit(int money)
        {
            
            card.Bulunce += money + (card.cashback * (money / 100));
            
            Console.WriteLine($"{Name} | Age {Age}");
            Console.WriteLine($"Успешно Пришло: {money} + {card.cashback}% Карты");
            Console.WriteLine($"Текущий Баланс: {card.Bulunce}");
        }
        public void SetShop(string name)
        {
            card.Bulunce -= 500;
            Console.WriteLine($"{Name} | Age {Age}");
            Console.WriteLine($"Успешно Куплено: {name}");
            Console.WriteLine($"Текущий Баланс: {card.Bulunce}");
        }

    }
}
