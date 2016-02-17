using System;
using entities.Weapon;
using System.Collections.Generic;

namespace entities.Cache
{
    //сам кеш. Логика в том, что они принимает обьект оружия и хранит его. После запроса выдает его кораблю принимая на хранение другой обьект оружия
    [Serializable]
    
    class WeaponCache : BaseCache
    {
       
        
        public WeaponCache()
        {
            weaponRepository = new List <KeyValuePair<TypeOfGun, IWeapon>> ();
        }

        public WeaponCache(List<KeyValuePair<TypeOfGun, IWeapon>> weapon)
        {
            weaponRepository = weapon;
        }


        public override void Add(TypeOfGun type, IWeapon weapon)
        {
            KeyValuePair<TypeOfGun, IWeapon> tmp = new KeyValuePair<TypeOfGun, IWeapon>(type, weapon);
            
            if (weaponRepository.Contains(tmp) == false)
            {
                weaponRepository.Add(tmp);
            }
        }

        public override IWeapon GetWeapon(TypeOfGun type)
        {
            bool detector = false;
            int index = 0;
            foreach (KeyValuePair<TypeOfGun, IWeapon> itm in weaponRepository)
            {
                if (itm.Key == type)
                {
                    detector = true;
                    break;
                }
                index++;
            }
            if (detector == true)
            {
                return weaponRepository[index].Value;
            }
            return null;
        }

        public override bool IsSetWeapon(TypeOfGun type)
        {
            bool detector = false;
            foreach (KeyValuePair<TypeOfGun, IWeapon> itm in weaponRepository)
            {
                if (itm.Key == type)
                {
                    detector = true;
                    break;
                }
            }
            return detector;
        }
    }
}
