
using entities.Bottles;
    //реализация паттерна фабричный метод. Ботл креатор создаст разный продукт бутылочек
namespace entities.BottleCreator
{
    //интерфейс ботл креатора все обращения к обьекту осуществляются через интерфейс
    interface IBottleCreat
    {
        IBottle GetBottle (TypeOfBottles type);
    }
}
