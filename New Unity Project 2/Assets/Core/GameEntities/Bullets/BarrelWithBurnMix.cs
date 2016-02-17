
using entities.BaseObject.Enums;
using UnityEngine;

namespace entities.Bullets
{
    class BarrelWithBurnMix : BaseBullet
    {
        public BarrelWithBurnMix(float speed, int distructionPow) : base (speed, distructionPow)
        {
            Weight = WeightOfBullets.BarrelWithBurnMixWeight;
            BulletType = TypeOFBullets.BarrelBurn;
            texture = Resources.Load("ImagesForItems\\Bullets\\BarrelBurn.png") as Texture2D;
        }
   
    }
}
