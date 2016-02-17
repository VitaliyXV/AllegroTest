//TODO : Disposible

using System;

namespace entities.Bottles
{
    class RealHealingBottle : LiteHealingBottle
    {

        public RealHealingBottle() : base()
        {
            BottleType = TypeOfBottles.RealHealing;
            PowegOfPotion = 100;
        }

        ~RealHealingBottle()
        {
            Console.WriteLine("Литл хел ботл");
        }
    }
}
