
//пространство имен с перечислениями
namespace entities.BaseObject.Enums
{
    enum WeightOfBullets
    {
        KamikazeSeagullWeight = 40,
        BarrelOfRottenFishWeight = 55,
        BarrelWithBurnMixWeight = 60,
        RocketWeight = 100,
        SuperRocketWeight = 300,
        CannonballWeight = 100,
        BombWeight = 250,
        CobblestoneWeight = 300,
    }


    enum MaxStrengthOfShoot
    {
        Cannon = 10,
        Catapult = 15,
        Rocket = 30
    }

    enum TypeOFBullets
    {
        Kamikaze,
        RottenFish,

        BarrelBurn,
        SuperRocket,
        Rocket,

        Cannonbal,
        Bomb,
        Cobblestone,
    }


    enum QuantityOfShoots
    {
        CannonGunShoots = 10,
        MaxCoolBulletItem = 5,
        CrazyBirdShoots = 1
    }
}

    enum TypeOfGun
    {
        CannonGun,
        Catapult,
        RocketGun,
    }



    enum TypeOfBottles
    {
        RealHealing,
        LiteHealing,
        MadBerserker
    }