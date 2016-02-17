using entities.BaseObject.Enums;
using entities.Bullets;
using UnityEngine;
using System;

namespace entities.Weapon
{
    //базовый класс оружия
    abstract class BaseWeapon : IWeapon
    {
        protected float x;
        protected float y;
        protected float z;
        //public Texture2D texture { get; set; }
        //public float X { get; set; }
        //public float Y { get; set; }
        //public float Z { get; set; }
        public void SetX(float x)
        {
            this.x = x;
        }
        public void SetY(float y)
        {
            this.y = y;
        }
        public void SetZ(float z)
        {
            this.z = z;
        }
        public float GetX()
        {
            return x;
        }
        public float GetY()
        {
            return y;
        }
        public float GetZ()
        {
            return z;
        }
        public int MaxShootStrength { get; set; }
        public TypeOfGun GunType { get; set; }
        abstract public IBullet Fire(TypeOFBullets bulletType);
    }
}
