
using entities.Bottles;
using System.Collections.Generic;

namespace entities.DurationBottlesController
{
    class DurrationBotlController : BaseDurController
    {
        Stack<IBottle> bottleHolder;

        public DurrationBotlController()
        {
            bottleHolder = new Stack<IBottle>();
        }

        public override void Add(IBottle duration)
        {
            bottleHolder.Push(duration);
        }

        public override void Update(ref int power)
        {
            if (CurrentDurrationBottle == null && bottleHolder.Count > 0)
            {
                CurrentDurrationBottle = bottleHolder.Pop();
                power = CurrentDurrationBottle.PowegOfPotion;
            }
            else
            {
                if (CurrentDurrationBottle != null && CurrentDurrationBottle.IsPotionEffectActs() == true)
                {
                    power -= CurrentDurrationBottle.PowegOfPotion;
                    CurrentDurrationBottle = null;
                }
            }

        }
    }
}
