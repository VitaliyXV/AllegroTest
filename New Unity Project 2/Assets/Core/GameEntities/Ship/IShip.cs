using entities.BaseObject;
using entities.BaseObject.Enums;
using entities.Bullets;
using entities.Cache;
using entities.Weapon;

namespace entities.Ship
{
    //интерфейс корабля все обращения к обьекту осуществляются через интерфейс
  //  interface IShip : EntitiesGameObject
    interface IShip 
    {
        int HP { get; set; }

        int NumOfCannonballs { get; set; }
        int NumOfBombs { get; set; }

        int NumOfFishBarrels { get; set; }
        int NumOfFireBarrels { get; set; }
        int NumOfStones { get; set; }

        int NumOfRockets { get; set; }
        int NumOfSuperRockets { get; set; }
        int NumOfCrazyAlbatroses { get; set; }

        bool this[TypeOfGun gun] { get; }

        TypeOfGun GunType { get; }
        TypeOFBullets bulletForCurrentShoot { get; set; }

        int Weight { get; set; }
        // временно
        IWeapon Wweapon { get; set; }

        WeaponCache WeaponCache { get; set; }

        void ChooseWeapon(TypeOfGun gun);
        IBullet Shoot();
        void SetWeaponFromShop(TypeOfGun gun, IWeapon weapon);
        
    }
}
