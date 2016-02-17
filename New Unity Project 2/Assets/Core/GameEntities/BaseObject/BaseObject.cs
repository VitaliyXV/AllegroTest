
using UnityEngine;

namespace entities.BaseObject
{
    // основной обьект от которого будет наследоваться все
   interface EntitiesGameObject
    {
        Texture2D texture { get; set;}
        float X { get; set; }
        float Y { get; set; }
        float Z { get; set; }
    }
}
