
using entities.Bottles;
using entities.Weapon;
using System;
using System.Collections.Generic;

namespace entities.Shop
{
    [Serializable]
    class BayShop : BaseShop
    {
        IWeapon bought = null;

        public BayShop() : base()
        {


        }

        override public IWeapon GetProduct(TypeOfGun gun)
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                if (weapons[i].GunType == gun)
                {
                    bought = weapons[i];
                    weapons.RemoveAt(i);
                    break;
                }
            }
            return bought;
        }

        override public IBottle GetProduct(TypeOfBottles bottle)
        {
            return bottleMaker.GetBottle(bottle);
        }

        override public int GetPrice(string item)
        {

            foreach (KeyValuePair<string, int> itm in prices)
            {
                if (itm.Key == item)
                {
                    return itm.Value;
                }
            }
            return -1;
        }

        override public void AddPrice(string name, int cost)
        {
            KeyValuePair<string, int> tmp = new KeyValuePair<string, int>(name, cost);
            if (prices.Contains(tmp) == false)
            {
                prices.Add(tmp);
            }
        }

        override public void ChangePrice(string name, int cost)
        {
            int index = 0;
            foreach (KeyValuePair<string, int> itm in prices)
            {
                if (itm.Key == name)
                {
                    break;
                }
                index++;
            }
            prices.RemoveAt(index);
            prices.Add(new KeyValuePair<string, int>(name, cost));
        }

    }
}
