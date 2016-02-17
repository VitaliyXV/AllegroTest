using System;

namespace entities.Bottles
{
    class BerserkBottle : BaseBottle
    {
        protected double duration;
        protected bool isUsedBottle;

        public BerserkBottle() 
        {
            duration = 30.0d;
            BottleType = TypeOfBottles.MadBerserker;
            isUsedBottle = false;
        }

        public override void Use()
        {
          
        }
        ~BerserkBottle()
        {
            //TODO: destructor  
            Console.WriteLine("Берсерк ботл");
        }
    }
}
