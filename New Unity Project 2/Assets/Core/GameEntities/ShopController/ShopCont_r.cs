
using entities.Ship;
using entities.BaseObject.Enums;
using System;
using entities.Weapon;
using System.Collections.Generic;
using entities.Player;

namespace entities.ShopController
{
    //реализация логики покупки. Пока что не учитывате деньги игрока
    [Serializable]
    class ShopCont_r : BaseShopController
    {
        public ShopCont_r() : base()
        {

        }

        public override void Buy(TypeOfBottles bottle, IShip ship, IPlayer player)
        {

        }


        public override bool Buy(TypeOFBullets bullet, IShip ship, IPlayer player)
        {
            if (bullet == TypeOFBullets.Kamikaze && ship[TypeOfGun.RocketGun] && ship.NumOfCrazyAlbatroses < 1)
            {
                ship.NumOfCrazyAlbatroses++;
                player.Money -= shop.GetPrice(TypeOFBullets.Kamikaze.ToString());
                return true;
            }
            if (bullet == TypeOFBullets.SuperRocket && ship[TypeOfGun.RocketGun] && ship.NumOfSuperRockets < 3)
            {
                ship.NumOfSuperRockets++;
                player.Money -= shop.GetPrice(TypeOFBullets.SuperRocket.ToString());
                return true;
            }
            else if (bullet == TypeOFBullets.BarrelBurn && ship[TypeOfGun.Catapult] && ship.NumOfFireBarrels < 5)
            {
                ship.NumOfFireBarrels++;
                player.Money -= shop.GetPrice(TypeOFBullets.BarrelBurn.ToString());
                return true;
            }
            else if (bullet == TypeOFBullets.RottenFish && ship[TypeOfGun.Catapult] && ship.NumOfFishBarrels < 5)
            {
                ship.NumOfFishBarrels++;
                player.Money -= shop.GetPrice(TypeOFBullets.RottenFish.ToString());
                return true;
            }
            else if (bullet == TypeOFBullets.Bomb && ship[TypeOfGun.CannonGun] && ship.NumOfBombs < 5)
            {
                ship.NumOfBombs++;
                player.Money -= shop.GetPrice(TypeOFBullets.Bomb.ToString());
                return true;
            }
            return false;
        }

        //функция проверки достаточно ли денег я не проверяю в самой функции покупки, так что делай в своем скрипте проверки перед покупкой
        public override bool IsHaveMoneyForPurchase(string item, int money)
        {
            return shop.GetPrice(item) <= money;
        }


        public override bool Buy(TypeOfGun gun, IShip ship, IPlayer player)
        {
            IWeapon weapon = shop.GetProduct(gun);
            if (weapon != null)
            {
                ship.SetWeaponFromShop(weapon.GunType, weapon);
                player.Money -= shop.GetPrice(gun.ToString());
                if (gun == TypeOfGun.Catapult)
                {
                    ship.NumOfStones = 5;
                }
                else
                {
                    ship.NumOfRockets = 5;
                }
                return true;
            }
            return false;
        }

        //цену оружия выдает 
        public override int GetItemPrice(string item)
        {
            return shop.GetPrice(item);

        }

        //если список пустой вернет null
        public override List<IWeapon> GetWeaponList()
        {
            return shop.WeaponList;
        }

        //будут допиливаться вдруг нам понадобится добавить какие-то айтымы и цены соо-но
        public override void AddNewPriceItem(string name, int cost)
        {

        }
        //поменять цену будет пилиться
        public override void ChangePriceItem(string name, int cost)
        {

        }
    }
}
