using entities.BaseObject.Enums;
namespace entities.Bullets
{
    class Cobblestone : BaseBullet
    {
        public Cobblestone(float speed, int distructionPow) : base (speed,distructionPow)
        {
            Weight = WeightOfBullets.CobblestoneWeight;
            BulletType = TypeOFBullets.Cobblestone;
        }
    }
}
