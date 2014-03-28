using System.Collections.Generic;

namespace Cards
{
    public class Trick
    {
        private readonly DeckRing _deckRing;
        private readonly List<TrickPointer> _pointers = new List<TrickPointer>();

        public Trick(DeckRing deckRing)
        {
            _deckRing = deckRing;
        }

        public Card FindCard(Deck deck)
        {
            var tempDeck = Deck.NewFromDeck(deck);
            while (!tempDeck.IsEmpty())
            {
                var c = tempDeck.TakeCard();
                var asExpected = false;
                foreach (var pointer in _pointers)
                {
                    if (pointer.IsExpected(c))
                    {
                        pointer.MoveOn();
                        asExpected = true;
                    }
                }
                if (asExpected) continue;
                foreach (var pointer in _pointers)
                {
                    if (pointer.IsExpected(c, 1))
                    {
                        return pointer.Expected();
                    }
                }
                if (_pointers.Count < 2)
                {
                    CreatePointer(c);
                    continue;
                }
                return c;
            }
            return null;
        }

        private void CreatePointer(Card card)
        {
            _pointers.Add(_deckRing.FindCard(card));
        }
    }
}