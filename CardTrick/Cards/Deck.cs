using System;
using System.Collections.Generic;
using System.Linq;
using Cards.Manipulations;

namespace Cards
{
    public class Deck
    {
        internal readonly List<Card> _cards = new List<Card>();

        public Deck()
        {
            foreach (Suit suit in Enum.GetValues(typeof (Suit)))
            {
                foreach (CardValue cardValue in Enum.GetValues(typeof (CardValue)))
                {
                    _cards.Add(new Card(suit, cardValue));
                }
            }
        }

        public int Count()
        {
            return _cards.Count;
        }

        public Card TakeCard(int idx = 0)
        {
            var takeCard = _cards[idx];
            _cards.RemoveAt(idx);
            return takeCard;
        }

        public void InsertCard(Card card, int idx)
        {
            _cards.Insert(idx, card);
        }

        public void Manipulate(IDeckManipulator deckManipulator)
        {
            var cards = deckManipulator.Manipulate(_cards);
            if (cards == _cards) return;
            _cards.Clear();
            _cards.AddRange(cards);
        }

        public void Empty()
        {
            _cards.Clear();
        }

        public static Deck NewEmptyDeck()
        {
            var newEmptyDeck = new Deck();
            newEmptyDeck.Empty();
            return newEmptyDeck;
        }

        public static Deck NewFromDeck(Deck deck)
        {
            var newDeck = NewEmptyDeck();
            newDeck._cards.AddRange(deck._cards);
            return newDeck;
        }

        public bool IsEmpty()
        {
            return !_cards.Any();
        }
    }
}