using entities.BaseObject.Enums;
using System;
using UnityEngine;

//базовый абстрактный класс пуль
namespace entities.Bullets
{
    [Serializable]
    abstract class BaseBullet : IBullet
    {
        public Texture2D texture { get; set; }
        public WeightOfBullets Weight { get; set; }
        public TypeOFBullets BulletType { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float Speed { get; set; }
        public int DistructionPower { get; set; }
        //public int Impulse { get; set; }
        public bool IsLive { get; set; }

        public BaseBullet(float speed, int distructionPow)
        {
            Speed = speed;
            DistructionPower = distructionPow;
            X = Y = 0;
            Z = -1;
        }


        

        public BaseBullet()
        {
            Speed = 100;
            DistructionPower = 10;
            X = Y = 0;
            Z = -1;
        }
    }
}
