using entities.BaseObject.Enums;
using UnityEngine;

namespace entities.Bullets
{
    class Bomb : BaseBullet
    {
        public Bomb (float speed, int distructionPow) : base (speed,distructionPow)
        {
            Weight = WeightOfBullets.BombWeight;
            BulletType = TypeOFBullets.Bomb;
            texture = Resources.Load("ImagesForItems\\Bullets\\Bomb.png") as Texture2D;
        }
    }
}
