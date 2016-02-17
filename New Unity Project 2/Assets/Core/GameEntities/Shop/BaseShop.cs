using entities.BaseObject.Enums;
using entities.BottleCreator;
using entities.Bottles;
using entities.Weapon;
using System;
using System.Collections.Generic;


namespace entities.Shop
{
    //базовый класс магазина. Содержит в себе списко оружия, создателя бутылок. Умеет возращать продукт
    abstract class BaseShop : IShop
    {
        
        protected List<IWeapon> weapons;
        protected List<KeyValuePair<string, int>> prices;
        protected bool isAllWeaponBought;
        protected BottleMaker bottleMaker;

        public List<IWeapon> WeaponList
        {
            get
            {
                return weapons;
            }
        }

        public List<KeyValuePair<string, int>> Prices
        {
            get
            {
                return prices;
            }
        }

        public string TypeOfBullets { get; private set; }

        public BaseShop()
        {
            weapons = new List<IWeapon>();
            weapons.Add(new Catapult());
            weapons.Add(new RrocketLauncher());
            prices = new List<KeyValuePair<string, int>>();
            //TODO: в будущем заполнять цену товаров сериализацией 
            prices.Add(new KeyValuePair<string, int>(TypeOfGun.CannonGun.ToString(), 100));
            prices.Add(new KeyValuePair<string, int>(TypeOfGun.Catapult.ToString(), 200));
            prices.Add(new KeyValuePair<string, int>(TypeOfGun.RocketGun.ToString(), 300));
            prices.Add(new KeyValuePair<string, int>(TypeOFBullets.Bomb.ToString(), 50));
            prices.Add(new KeyValuePair<string, int>(TypeOFBullets.BarrelBurn.ToString(), 100));
            prices.Add(new KeyValuePair<string, int>(TypeOFBullets.RottenFish.ToString(), 100));
            prices.Add(new KeyValuePair<string, int>(TypeOFBullets.SuperRocket.ToString(), 150));
            prices.Add(new KeyValuePair<string, int>(TypeOFBullets.Kamikaze.ToString(), 350));

        }


        abstract public IWeapon GetProduct(TypeOfGun gun);
        abstract public IBottle GetProduct(TypeOfBottles bottle);
        abstract public int GetPrice(string item);
        abstract public void AddPrice(string name, int cost);
        abstract public void ChangePrice(string name, int cost);
    }

}



