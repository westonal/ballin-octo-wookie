using System.Collections.Generic;

namespace Cards
{
    public class DeckRing
    {
        private readonly List<Card> _cards = new List<Card>();

        public void Add(Deck deck)
        {
            _cards.AddRange(deck._cards);
        }

        public TrickPointer FindCard(Card card)
        {
            var idx = _cards.IndexOf(card);
            return new TrickPointer(this, idx);
        }

        public bool NextIs(int idx, Card card)
        {
            return Next(idx) == card;
        }

        public Card Next(int idx)
        {
            return _cards[(idx + 1)%_cards.Count];
        }
    }
}