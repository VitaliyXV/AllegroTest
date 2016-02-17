using entities.BaseObject.Enums;
using UnityEngine;

namespace entities.Bullets
{
    class BarrelOfRottenFish : BaseBullet
    {
        public BarrelOfRottenFish(float speed, int distructionPow ) : base(speed,distructionPow)
        {
            Weight = WeightOfBullets.BarrelOfRottenFishWeight;
            BulletType = TypeOFBullets.RottenFish;
            texture = Resources.Load("ImagesForItems\\Bullets\\RottenFish.png") as Texture2D;
        }
    }
}
