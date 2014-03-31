using System.Collections.Generic;
using System.Linq;

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
                var seenExpected = false;
                foreach (var pointer in _pointers)
                {
                    if (pointer.IsExpected(c))
                    {
                        pointer.MoveOn();
                        seenExpected = true;
                        break;
                    }
                }
                if (seenExpected) continue;
                foreach (var pointer in _pointers)
                {
                    {
                        if (pointer.IsExpected(c, 1))
                        {
                            return pointer.Expected();
                        }
                    }
                }
                CreatePointer(c);
            }
            return PointerWithNoAdvances();
        }

        private Card PointerWithNoAdvances()
        {
            return _pointers.Where(p => p.Advances() == 0).Select(p => p.Current()).Single();
        }

        private void CreatePointer(Card card)
        {
            _pointers.Add(_deckRing.FindCard(card));
        }
    }
}