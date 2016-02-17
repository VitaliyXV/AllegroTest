
//реализация паттерна фабричный метод каждый тип оружия порождает то или иной продукт в форме пули

using entities.BaseObject;
using entities.BaseObject.Enums;
using entities.Bullets;

namespace entities.Weapon
{
    //итерфейс оружия все обращения к обьекту осуществляются через интерфейс    
    //interface IWeapon : EntitiesGameObject
    interface IWeapon 
    {
        int MaxShootStrength { get; set; }
        TypeOfGun GunType { get; set; }
        IBullet Fire(TypeOFBullets bulletType);
        void SetX(float x);
        void SetY(float y);
        void SetZ(float z);
        float GetX();
        float GetY();
        float GetZ();
    }
}
