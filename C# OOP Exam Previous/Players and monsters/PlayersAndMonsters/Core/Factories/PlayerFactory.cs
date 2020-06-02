namespace PlayersAndMonsters.Core.Factories
{
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            IPlayer player = null;
            CardRepository cardRepository = new CardRepository();

            switch (type)
            {
                case "Beginner":
                    player = new Beginner(cardRepository, username);
                    break;
                case "Advanced":
                    player = new Advanced(cardRepository, username);
                    break;
            }

            return player;
        }
    }
}
