namespace PlayersAndMonsters.Repositories
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayerRepository : IPlayerRepository
    {
        private readonly Dictionary<string, IPlayer> players;

        public PlayerRepository()
        {
            this.players = new Dictionary<string, IPlayer>();
        }

        public int Count => this.players.Count;

        public IReadOnlyCollection<IPlayer> Players => this.players.Values.ToList().AsReadOnly();

        public void Add(IPlayer player)
        {
            Validator.ThrowIfObjectIsNull(player, "Player cannot be null");

            if (this.players.ContainsKey(player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            this.players.Add(player.Username, player);
        }

        public IPlayer Find(string username)
        {
            IPlayer player = null;
            if (this.players.ContainsKey(username))
            {
                player = this.players[username];
            }

            return player;
        }

        public bool Remove(IPlayer player)
        {
            Validator.ThrowIfObjectIsNull(player, "Player cannot be null");

            return this.players.Remove(player.Username);
        }
    }
}
