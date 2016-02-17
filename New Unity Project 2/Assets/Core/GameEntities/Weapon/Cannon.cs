using entities.BaseObject.Enums;
using entities.Bullets;
using System;
using UnityEngine;

namespace entities.Weapon
{
    class Cannon : BaseWeapon
    {

        public Cannon()
        {
            GunType = TypeOfGun.CannonGun;
            MaxShootStrength = (int)MaxStrengthOfShoot.Cannon;
           // texture = Resources.Load("ImagesForItems\\Weapons\\Weapon.png") as Texture2D; 
        }

        public override IBullet Fire(TypeOFBullets bulletType)
        {
            IBullet bullet = null;
         
                if (bulletType == TypeOFBullets.Cannonbal)
                {
                    bullet = new Cannonball(100, 100);
                }
                else
                {
                    bullet = new Bomb(100, 100);
                }
            return bullet;
        }
    }

}

