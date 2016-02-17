using entities.Characters;
using entities.Player;
using entities.Ship;
using entities.ShopController;


namespace Assets.Core.Serializer
{
  
    interface ISerializer
    {
        string Serialize(IShopController shopController);
        string Serialize(IPlayer player);
        string Serialize(IShip ship);
        string Serialize(ICharacter character);
        void Deserialize(string json);
    }
}
