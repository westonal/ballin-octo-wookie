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

        public Trick(string deckString)
        {
            var deck = Deck.Load(deckString);
            _deckRing = new DeckRing();
            _deckRing.Add(deck);
        }

        public Card FindCard(Deck deck)
        {
            var tempDeck = Deck.NewFromDeck(deck);
            while (!tempDeck.IsEmpty())
            {
                var c = tempDeck.TakeCard();
                foreach (var pointer in _pointers)
                {
                    if (pointer.IsExpected(c))
                    {
                        pointer.MoveOn();
                    }
                    else
                    {
                        if (pointer.IsExpected(c, 1))
                        {
                            return pointer.Expected();
                        }
                    }
                }
                CreatePointer(c);
                continue;
            }
            return FirstPointerWithNoAdvances();
        }

        private Card FirstPointerWithNoAdvances()
        {
            foreach (var pointer in _pointers)
                if (pointer.Advances() == 0)
                    return pointer.Current();
            return null;
        }

        private void CreatePointer(Card card)
        {
            _pointers.Add(_deckRing.FindCard(card));
        }
    }
}