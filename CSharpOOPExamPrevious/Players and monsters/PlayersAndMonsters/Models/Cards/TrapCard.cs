namespace PlayersAndMonsters.Models.Cards
{
    using PlayersAndMonsters.Models.Cards.Contracts;

    public class TrapCard : Card, ICard
    {
        public const int InitialDamagePoints = 120;
        public const int InitialHealthPoints = 5;

        public TrapCard(string name) 
            : base(name, InitialDamagePoints, InitialHealthPoints)
        {
        }
    }
}
