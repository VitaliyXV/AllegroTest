

using entities.BaseObject.Enums;
using System;
namespace entities.Bullets
{   
    class Rocket : BaseBullet
    {
        public Rocket(float speed, int distructionPow) : base (speed, distructionPow)
        {
            Weight = WeightOfBullets.RocketWeight;
            BulletType = TypeOFBullets.Rocket;
        }

        public Rocket() :base()
        {
           
        }
    }
}
