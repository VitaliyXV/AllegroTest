

using System;
using entities.Weapon;
using System.Collections.Generic;

namespace entities.Cache
{
    //базовый класс интерфейса
    abstract class BaseCache : ICache
    {

        protected List<KeyValuePair<TypeOfGun, IWeapon>> weaponRepository;

        public List<KeyValuePair<TypeOfGun, IWeapon>> WeaponRepository
        {
            get
            {
                return weaponRepository;
            }
            set
            {
                weaponRepository = value;
            }
        }

        abstract public void Add(TypeOfGun type, IWeapon weapon);
        abstract public IWeapon GetWeapon(TypeOfGun type);
        abstract public bool IsSetWeapon(TypeOfGun type);
    }
}
