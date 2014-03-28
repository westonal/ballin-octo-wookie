using System.Collections.Generic;
using System.Linq;

namespace Cards.Manipulations
{
    public sealed class Cut : IDeckManipulator
    {
        private readonly int _position;
        private readonly Deck _otherDeck;

        public Cut(int position, Deck otherDeck = null)
        {
            _position = position;
            _otherDeck = otherDeck;
        }

        public List<Card> Manipulate(List<Card> cards)
        {
            var newCards = new List<Card>();
            if (_otherDeck == null)
                newCards.AddRange(cards.Skip(_position));
            else
                _otherDeck.Manipulate(new AddCards(cards.Skip(_position).ToList()));
            newCards.AddRange(cards.Take(_position));
            return newCards;
        }
    }
}