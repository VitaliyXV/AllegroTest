using entities.BaseObject.Enums;
using entities.Bullets;
using System;
using UnityEngine;

namespace entities.Weapon
{
    class Catapult : BaseWeapon
    {
        public Catapult()
        {
            GunType = TypeOfGun.Catapult;
            MaxShootStrength = (int)MaxStrengthOfShoot.Catapult;
           // texture = Resources.Load("ImagesForItems\\Weapons\\Weapon.png") as Texture2D;
        }

        public override IBullet Fire(TypeOFBullets bulletType)
        {
            IBullet bullet = null;
                if (bulletType == TypeOFBullets.Cobblestone)
                {
                    bullet = new Cobblestone(100, 100);
                }
                else if (bulletType == TypeOFBullets.BarrelBurn)
                {
                    bullet = new BarrelWithBurnMix(100, 100);
                }
                else
                {
                    bullet = new BarrelOfRottenFish(100, 100);
                }
            return bullet;
        }
    }
}
