
using entities.BaseObject.Enums;
using entities.Player;
using entities.Ship;
using entities.Shop;
using entities.Weapon;
using System.Collections.Generic;

namespace entities.ShopController
{
    //интерфейс шоп контроллера
    interface IShopController
    {
       
        bool Buy(TypeOfGun gun, IShip ship, IPlayer player);
        void Buy(TypeOfBottles bottle, IShip ship, IPlayer player);
        bool Buy(TypeOFBullets bullet, IShip ship, IPlayer player);
        bool IsHaveMoneyForPurchase(string item, int money);
        int GetItemPrice(string item);
        IShop Shop { get; }
        List<IWeapon> GetWeaponList();
        void AddNewPriceItem(string name, int cost);
        void ChangePriceItem(string name, int cost);
    }
}
