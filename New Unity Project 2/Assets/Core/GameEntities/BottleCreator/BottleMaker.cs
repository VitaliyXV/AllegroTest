using entities.Bottles;
using System;

namespace entities.BottleCreator
{
    class BottleMaker : BaseBottleCreator
    {
        public override IBottle GetBottle(TypeOfBottles type)
        {
            IBottle bottle = null;
          
                if (type == TypeOfBottles.LiteHealing)
                {
                    bottle = new LiteHealingBottle();
                }
                else if (type == TypeOfBottles.RealHealing)
                {
                    bottle = new RealHealingBottle();
                }
                else
                {
                    bottle = new BerserkBottle();
                }

          return bottle; 
        }
    }
}
