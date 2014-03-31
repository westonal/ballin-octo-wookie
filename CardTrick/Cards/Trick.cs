using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

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
            //Debug.Assert(deck.Count() == 52);
            Debug.Assert(!deck._cards.Any(c => c == null));
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
            return _pointers.Where(p => p.Advances() == 0).Select(p => p.Current()).FirstOrDefault();
        }

        private void CreatePointer(Card card)
        {
            _pointers.Add(_deckRing.FindCard(card));
        }

        public static TrickResult Perform(string deckKnowledge, string halfAfterTrick)
        {
            var trick = new Trick(deckKnowledge);
            var halfOfDeck = Deck.Load(halfAfterTrick);
            var card = trick.FindCard(halfOfDeck);
            var result = new TrickResult { Card = card };
            if (halfOfDeck.Contains(card))
            {
                result.NewKnowledge = halfAfterTrick + deckKnowledge;
            }
            else
            {
                result.NewKnowledge = deckKnowledge;
            }
            return result;
        }
    }
}