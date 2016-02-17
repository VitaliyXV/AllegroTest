using entities.BaseObject.Enums;
using entities.Bullets;
using System;
using UnityEngine;

namespace entities.Weapon
{
    class RrocketLauncher : BaseWeapon
    {
        public RrocketLauncher()
        {
            GunType = TypeOfGun.RocketGun;
            MaxShootStrength = (int)MaxStrengthOfShoot.Rocket;
          //  texture = Resources.Load("ImagesForItems\\Weapons\\Weapon.png") as Texture2D;
        }

        public override IBullet Fire(TypeOFBullets bulletType)
        {
            IBullet bullet = null;
                if (bulletType == TypeOFBullets.Rocket)
                {
                    bullet = new Rocket(100, 100);
                }
                else if (bulletType == TypeOFBullets.SuperRocket)
                {
                    bullet = new SuperRocket(100, 100);
                }
                else
                {
                    bullet = new KamikazeSeagull(100, 100);
                }
            return bullet;
        }
    }
}
