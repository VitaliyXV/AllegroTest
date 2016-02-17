
using entities.Bottles;

namespace entities.BottleCreator
{
    //базовый класс ботл мейкера
   abstract class BaseBottleCreator : IBottleCreat
    {
        abstract public IBottle GetBottle (TypeOfBottles type);
    }
}
