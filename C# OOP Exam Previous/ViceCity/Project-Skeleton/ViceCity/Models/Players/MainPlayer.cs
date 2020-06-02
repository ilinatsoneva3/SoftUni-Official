namespace ViceCity.Models.Players
{
    using ViceCity.Models.Players.Contracts;

    public class MainPlayer : Player, IPlayer
    {
        public const int InitialLifePoints = 100;
        public const string OnlyName = "Tommy Vercetti";

        public MainPlayer() 
            : base(OnlyName, InitialLifePoints)
        {
        }
    }
}
