using System;
using entities.BaseObject;
using entities.BaseObject.Enums;
using entities.Bullets;
using entities.Weapon;
using entities.Cache;

namespace entities.Ship
{
    [Serializable]
    class VikingShip : BaseShip
    {
       

        public VikingShip(): base()
        {
         
        }

        public override void ChooseWeapon(TypeOfGun gun)
        {
            if (weaponCache.IsSetWeapon(gun) == true)
            {
                weaponCache.Add(Weapon.GunType,Weapon);
                Weapon = weaponCache.GetWeapon(gun);
            }

        }

        public override void SetWeaponFromShop(TypeOfGun gun, IWeapon weapon)
        {
            weaponCache.Add(gun, weapon);
        }




        public override IBullet Shoot()
        {
            return ShootLogic();
        }


        protected IBullet ShootLogic()
        {
            IBullet bullet ;
            switch (bulletForCurrentShoot)
            {
                case TypeOFBullets.Cannonbal:
                  
                    bullet =  NumOfCannonballs != 0? Weapon.Fire(bulletForCurrentShoot): null;
                    NumOfCannonballs--;
                    break;

                case TypeOFBullets.Bomb:
                    bullet = NumOfBombs != 0 ? Weapon.Fire(bulletForCurrentShoot) : null;
                    NumOfBombs--;
                    break;

                case TypeOFBullets.Cobblestone:
                    bullet = NumOfStones != 0 ? Weapon.Fire(bulletForCurrentShoot) : null;
                    NumOfStones--;
                    break;

                case TypeOFBullets.RottenFish:
                    bullet = NumOfFishBarrels != 0 ? Weapon.Fire(bulletForCurrentShoot) : null;
                    NumOfFishBarrels--;
                    break;

                case TypeOFBullets.BarrelBurn:
                    bullet = NumOfFireBarrels != 0 ? Weapon.Fire(bulletForCurrentShoot) : null;
                    NumOfFireBarrels--;
                    break;

                case TypeOFBullets.Rocket:
                    bullet = NumOfRockets != 0 ? Weapon.Fire(bulletForCurrentShoot) : null;
                    NumOfRockets--;
                    break;

                case TypeOFBullets.SuperRocket:
                    bullet = NumOfSuperRockets != 0 ? Weapon.Fire(bulletForCurrentShoot) : null;
                    NumOfSuperRockets--;
                    break;

                case TypeOFBullets.Kamikaze:
                    bullet = NumOfCrazyAlbatroses != 0 ? Weapon.Fire(bulletForCurrentShoot) : null;
                    NumOfCrazyAlbatroses--;
                    break;

                default:
                    bullet = null;
                    break;
            }
            return bullet;
        }
    }
}
