using entities.BaseObject.Enums;
using UnityEngine;

namespace entities.Bullets
{
    class SuperRocket : BaseBullet
    {
        public SuperRocket(float speed, int distructionPow) : base (speed, distructionPow)
        {
            Weight = WeightOfBullets.SuperRocketWeight;
            BulletType = TypeOFBullets.SuperRocket;
            texture = Resources.Load("ImagesForItems\\Bullets\\SuperRocket.png") as Texture2D;
        }
    }
}
