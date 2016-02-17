
using entities.Shop;
using entities.Ship;
using entities.BaseObject.Enums;
using System.Collections.Generic;
using entities.Weapon;
using entities.Player;
using System;

namespace entities.ShopController
{
    //базовые класс. Содерджит в себе магазин. Все операции покупки ништяков осуществляются через шоп контролле. Вызывающий обьет нажимает на методы купить и не парится.
    //в будуещем допилю, обьет игрока от которого будет зависить покупку. 
    
    abstract class BaseShopController : IShopController
    {
          protected BayShop shop;

        public IShop Shop
        {
            get 
            {
                return shop;
            }
        }

        public BaseShopController()
        {
            shop = new BayShop();
        }

        abstract public bool Buy(TypeOfGun gun, IShip ship, IPlayer player);
        abstract public void Buy(TypeOfBottles bottle, IShip ship, IPlayer player);
        abstract public bool Buy(TypeOFBullets bullet, IShip ship, IPlayer player);
        abstract public bool IsHaveMoneyForPurchase(string item, int money);
        abstract public int GetItemPrice(string item);
        abstract public List<IWeapon> GetWeaponList();
        abstract public void AddNewPriceItem(string name, int cost);
        abstract public void ChangePriceItem(string name, int cost);

    }
}
