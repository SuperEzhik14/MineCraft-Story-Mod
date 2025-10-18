using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBull
{
    interface ICard
    {
        int Bulunce { get; set; }
        int cashback { get;}
    }
    class TinCoffeCard : ICard
    {
        int ICard.cashback { get; } = 15;
        int ICard.Bulunce { get ; set; }
    }
    class GallmartCard : ICard
    {
        int ICard.cashback { get; } = 30;
        int ICard.Bulunce { get; set; }
    }
    class RanderEngryBeCard : ICard
    {
        int ICard.cashback { get; } = 0;
        int ICard.Bulunce { get; set; }
    }
}