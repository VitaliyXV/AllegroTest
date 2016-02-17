

using entities.Bottles;

namespace entities.DurationBottlesController
{
    interface IDurController
    {
        void Add(IBottle duration);
        IBottle CurrentDurrationBottle { get; set; }
        void Update(ref int power);
    }
}
