//TODO : Disposible

using System;

namespace entities.Bottles
{
    class LiteHealingBottle : BaseBottle
    {
        public LiteHealingBottle() 
        {
            BottleType = TypeOfBottles.LiteHealing;
            PowegOfPotion = 50;
        }

        public override void Use()
        {
           
        }

        ~LiteHealingBottle()
        {
            Console.WriteLine("Литл хел ботл");
        }
    }
}
