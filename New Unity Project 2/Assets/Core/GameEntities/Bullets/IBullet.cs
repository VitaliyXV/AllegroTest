
using entities.BaseObject;
using entities.BaseObject.Enums;

namespace entities.Bullets
{
    //интерфейс пуль все обращения к обьекту осуществляются через интерфейс    
    interface IBullet : EntitiesGameObject
    {
        float Speed { get; set; }
        int DistructionPower { get; set; }
        // int Impulse { get; set; }
        bool IsLive { get; set; }
        TypeOFBullets BulletType { get; set;} 

    }
}
