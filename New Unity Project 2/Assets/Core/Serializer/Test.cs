
using UnityEngine;
using Assets.Scripts;
using entities.ShopController;
using entities.Player;
using entities.Ship;

namespace Assets.Core.Serializer
{

   
    public class Test : MonoBehaviour
    {
       

        void Start()
        {
            ISerializer saver = new BaseSerializer();
            IShopController shop = new ShopCont_r();
            IPlayer player = new GamePlayer();
            IShip ship = new VikingShip();
            Assets.Scripts.ILogger log = GameLogger.GetInstance();
            saver.Serialize(shop);
            string playr = saver.Serialize(player);
           
            string shp = saver.Serialize(ship);
            saver.Deserialize(shp);

        }


        void Update()
        {


        }
    }

}