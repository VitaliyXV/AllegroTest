

using entities.BaseObject.Enums;
using UnityEngine;

namespace entities.Bullets
{
    class KamikazeSeagull : BaseBullet
    {
        public KamikazeSeagull(float speed, int distructionPow) : base (speed,distructionPow)
        {
            Weight = WeightOfBullets.KamikazeSeagullWeight;
            BulletType = TypeOFBullets.Kamikaze;
            texture = Resources.Load("ImagesForItems\\Bullets\\Kamikadze.png") as Texture2D;

        }
    }
}
