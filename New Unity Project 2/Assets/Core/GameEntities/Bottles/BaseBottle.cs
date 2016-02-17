using System;
//TODO : Disposible
namespace entities.Bottles
{

    abstract class BaseBottle : IBottle
    {
        //базовый класс бутылочек
       
        public TypeOfBottles BottleType { get; set; }
        public int PowegOfPotion { get; set; }
        public string ImagePath { get; set; }

        abstract public void Use();

        public bool IsPotionEffectActs()
        {
            return false;
        }

       
    }
}
