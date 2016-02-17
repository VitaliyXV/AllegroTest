
using UnityEngine;
using entities.ShopController;
using LitJson;
using System.IO;
using System.Collections.Generic;
using entities.Weapon;
using entities.Bullets;
using entities.Player;
using entities.Ship;
using entities.Characters;

namespace Assets.Core.Serializer
{
  

    class BaseSerializer : ISerializer
    {
        protected JsonData data;

        public BaseSerializer()
        {
           // data = new JsonData();
        }

        public void Deserialize(string json)
        {
            data = JsonMapper.ToObject(json);
            IShip ww = JsonMapper.ToObject<VikingShip>(data.ToJson());
           
        
        }

        public string Serialize(IShopController shopController)
        {
            string json = JsonMapper.ToJson(shopController);
            return json;
        }

        public string Serialize(IPlayer player)
        {
            string json = JsonMapper.ToJson(player);
            return json;
        }

        public string Serialize(IShip ship)
        {
            string json = JsonMapper.ToJson(ship);
            return json;
        }
        public string Serialize(ICharacter character)
        {
            string json = JsonMapper.ToJson(character);
            return json;
        }
    }
}
