using entities.Bottles;

namespace entities.Characters
{
    interface ICharacter
    {
        string Name { get; }
        int HP { get; set; }
        int Strength { get; }
        void Attack();
        void Jump();
        void AddBottle(IBottle bottle);
        void UseBottle(TypeOfBottles bottle, int index);
        void Updaite();
        bool IsLive();
    }
}
