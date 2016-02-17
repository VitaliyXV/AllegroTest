

using System;
using entities.Bottles;

namespace entities.DurationBottlesController
{
    abstract class BaseDurController : IDurController
    {
        public IBottle CurrentDurrationBottle { get; set; }

        abstract public void Add(IBottle duration);

        abstract public void Update(ref int power);
     
    }
}
