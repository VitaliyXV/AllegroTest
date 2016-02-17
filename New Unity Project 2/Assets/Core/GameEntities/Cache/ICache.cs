using entities.Weapon;
using System.Collections.Generic;

namespace entities.Cache
{
    //интерфейс кеша все обращения к обьекту осуществляются через интерфейс
    interface ICache
    {
        List<KeyValuePair<TypeOfGun, IWeapon>> WeaponRepository { get; set; }
        void Add(TypeOfGun type, IWeapon weapon);
        IWeapon GetWeapon(TypeOfGun type);
        bool IsSetWeapon(TypeOfGun type);
    }
}
