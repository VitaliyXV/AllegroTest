
namespace entities.Bottles
{
    //интерфейс бутылочек все обращения к обьекту осуществляются через интерфейс    
    interface IBottle
    {
        TypeOfBottles BottleType { get; set; }
        int PowegOfPotion { get; set; }
        string ImagePath { get; set; }
        void Use();
        bool IsPotionEffectActs();

    }
}
