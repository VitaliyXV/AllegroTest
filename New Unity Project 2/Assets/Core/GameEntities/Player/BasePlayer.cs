

namespace entities.Player
{
    class BasePlayer : IPlayer
    {
        public int Money { get; set; }
        public int Glory { get; set; }
        public int Score { get; set; }
        public string Name { get; set; }

        public BasePlayer()
        {
            Money = 500;
            Glory = 0;
            Score = 0;
            Name = "uknown";
        }
    }
}
