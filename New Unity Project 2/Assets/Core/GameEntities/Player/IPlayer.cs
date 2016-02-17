

namespace entities.Player
{
    interface IPlayer
    {
        int Money { get; set; }
        int Glory { get; set; }
        int Score { get; set; }
        string Name { get; set; }
    }
}
