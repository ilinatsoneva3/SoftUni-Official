namespace PlayersAndMonsters.Repositories
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CardRepository : ICardRepository
    {
        private readonly Dictionary<string, ICard> cards;

        public CardRepository()
        {
            this.cards = new Dictionary<string, ICard>();
        }

        public int Count => this.cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.cards.Values.ToList().AsReadOnly();

        public void Add(ICard card)
        {
            Validator.ThrowIfObjectIsNull(card, "Card cannot be null!");

            if (this.cards.ContainsKey(card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            this.cards.Add(card.Name, card);
        }

        public ICard Find(string name)
        {
            ICard card = null;

            if (this.cards.ContainsKey(name))
            {
                card = this.cards[name];
            }

            return card;
        }

        public bool Remove(ICard card)
        {
            Validator.ThrowIfObjectIsNull(card, "Card cannot be null!");

            return this.cards.Remove(card.Name);
        }
    }
}
