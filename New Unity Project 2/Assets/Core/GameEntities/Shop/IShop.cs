
using entities.Bottles;
using entities.Weapon;
using System.Collections.Generic;

namespace entities.Shop
{
    //интерфейс магазина
    interface IShop
    {
        IWeapon GetProduct(TypeOfGun gun);
        IBottle GetProduct(TypeOfBottles bottle);
        List<IWeapon> WeaponList { get; }
        List <KeyValuePair<string, int>> Prices { get;}
        int GetPrice(string item);
        void AddPrice(string name, int cost);
        void ChangePrice(string name, int cost);
    }
}
