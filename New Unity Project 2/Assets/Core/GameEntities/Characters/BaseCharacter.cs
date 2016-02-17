
using entities.Bottles;
using entities.DurationBottlesController;
using System.Collections.Generic;

namespace entities.Characters
{
   abstract class BaseCharacter : ICharacter
    {
        protected List<IBottle> bottles;
        protected DurrationBotlController durBottleController;

        protected readonly int maxHPCount;
        protected int strenght;
        protected string name;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int HP { get; set; }
     
        public int Strength
        {
            get
            {
                return strenght;
            } 
        }
        public abstract void Attack();
        public abstract void Jump();

        public BaseCharacter()
        {
            bottles = new List<IBottle>();
            durBottleController = new DurrationBotlController();
            HP = maxHPCount = 100;
        }

       public  void AddBottle(IBottle bottle)
        {
            bottles.Add(bottle);

        }


      public   void UseBottle(TypeOfBottles bottle, int index)
        {
           if ( bottle == TypeOfBottles.LiteHealing || bottle == TypeOfBottles.RealHealing )
            {
                HP += bottles[index].PowegOfPotion;
                if (HP > maxHPCount)
                {
                    HP = maxHPCount;
                }
                if (bottles[index].BottleType == TypeOfBottles.LiteHealing || bottles[index].BottleType == TypeOfBottles.RealHealing)
                {
                    bottles.RemoveAt(index);
                }
            }
            else if (bottle == TypeOfBottles.MadBerserker)
            {
                durBottleController.Add(bottles[index]);
                if (bottles[index].BottleType == TypeOfBottles.MadBerserker)
                {
                    bottles.RemoveAt(index);
                }
            }
           
        }

        public void Updaite()
        {
            durBottleController.Update(ref strenght);
        }



        public  bool IsLive()
        {
            return HP != 0;
        }
    }
}
