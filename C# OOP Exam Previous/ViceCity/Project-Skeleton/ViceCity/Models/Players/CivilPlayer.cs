namespace ViceCity.Models.Players
{
    using ViceCity.Models.Players.Contracts;

    public class CivilPlayer : Player, IPlayer
    {
        public const int InitialLifePoints = 50;

        public CivilPlayer(string name) 
            : base(name, InitialLifePoints)
        {
        }
    }
}
