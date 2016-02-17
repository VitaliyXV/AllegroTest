using entities.BaseObject.Enums;
using entities.Bullets;
using entities.Cache;
using entities.Weapon;
using UnityEngine;

namespace entities.Ship
{
    //базовый класс корабля. Корабль хранит в себе указатель на конкретное оружие. Типа кеш оружий. Количество патронов каждого оружия. Умеет стрелять, менять оружие.
   abstract class BaseShip : IShip
    {
        protected WeaponCache weaponCache;

        protected IWeapon Weapon;

        // временно
        public IWeapon Wweapon
        {
            get
            {
                return Weapon;
            }
            set
            {
                Weapon = value;
            }
        }

        public int HP { get; set; }

        public Texture2D texture { get; set; }

        public int NumOfCannonballs { get; set; }
        public int NumOfBombs { get; set; }
         
        public int NumOfFishBarrels { get; set; }
        public int NumOfFireBarrels { get; set; }
        public int NumOfStones { get; set; }

        public TypeOfGun GunType
        {
            get
            {
                return Weapon.GunType;
            }
        }
        public TypeOFBullets bulletForCurrentShoot { get; set; }

        public bool this[TypeOfGun gun]
        {
            get
            {
                return weaponCache.IsSetWeapon(gun);
            }
        }

        public int NumOfRockets { get; set; }
        public int NumOfSuperRockets { get; set; }
        public int NumOfCrazyAlbatroses { get; set; }

        //public float X { get; set; }
        //public float Y { get; set; }
        //public float Z { get; set; }

        public int Weight { get; set; }

        // для серриализации
        public WeaponCache WeaponCache
        {
            get
            {
                return weaponCache;
            }
            set
            {
                weaponCache = value;
            }
        }



        //TODO : загрузку и инициализацию консрукторов из файла
        public BaseShip()
        {
            Weapon = new Cannon();
            weaponCache = new WeaponCache();
            weaponCache.Add(Weapon.GunType, Weapon);
            bulletForCurrentShoot = TypeOFBullets.Cannonbal;
            NumOfCannonballs = 10;
            // TODO kill magic number
            int Weight = 1000;
        }


        public BaseShip(IWeapon weapon, WeaponCache cache )
        {
            Weapon = weapon;
            weaponCache = cache;
            //weaponCache.Add(Weapon.GunType, Weapon);
            bulletForCurrentShoot = TypeOFBullets.Cannonbal;
            NumOfCannonballs = 10;
            // TODO kill magic number
            int Weight = 1000;
        }


        abstract public void ChooseWeapon(TypeOfGun gun);
        abstract public IBullet Shoot();
        abstract public void SetWeaponFromShop(TypeOfGun gun, IWeapon weapon);

    }
}
