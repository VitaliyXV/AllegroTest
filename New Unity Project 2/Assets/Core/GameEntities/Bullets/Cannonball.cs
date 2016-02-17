using entities.BaseObject.Enums;
using System;

namespace entities.Bullets
{
    [Serializable]
    class Cannonball: BaseBullet
    {
        public Cannonball (float speed, int distructionPow ) : base (speed, distructionPow)
        {
            Weight = WeightOfBullets.CannonballWeight;
            BulletType = TypeOFBullets.Cannonbal;
         }

        public Cannonball() 
        {
        }
    }


}
