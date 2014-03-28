using System;
using Cards;
using Cards.Manipulations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardTrickTests
{
    [TestClass]
    public class DeckTest
    {
        private Deck _deck;

        [TestInitialize]
        public void Setup()
        {
            _deck = new Deck();
        }

        [TestMethod]
        public void Deck_has_52_cards()
        {
            Assert.AreEqual(52, _deck.Count());
        }

        [TestMethod]
        public void Taking_cards_affects_count()
        {
            _deck.TakeCard();
            Assert.AreEqual(51, _deck.Count());
        }

        [TestMethod]
        public void Deck_in_order()
        {
            foreach (Suit suit in Enum.GetValues(typeof (Suit)))
            {
                foreach (CardValue cardValue in Enum.GetValues(typeof (CardValue)))
                {
                    var c = _deck.TakeCard();
                    Assert.AreEqual(cardValue, c.CardValue);
                    Assert.AreEqual(suit, c.Suit);
                }
            }
            Assert.AreEqual(0, _deck.Count());
        }

        [TestMethod]
        public void Can_cut()
        {
            _deck.Manipulate(new Cut(10));
            Assert.AreEqual(52, _deck.Count());
            var c = _deck.TakeCard();
            Assert.AreEqual(CardValue.Jack, c.CardValue);
            Assert.AreEqual(Suit.Heart, c.Suit);
        }

        [TestMethod]
        public void Can_cut_to_other_deck()
        {
            var newEmptyDeck = Deck.NewEmptyDeck();
            _deck.Manipulate(new Cut(10, newEmptyDeck));
            Assert.AreEqual(10, _deck.Count());
            Assert.AreEqual(42, newEmptyDeck.Count());
        }

        [TestMethod]
        public void Can_Null_Manipulate()
        {
            _deck.Manipulate(new NullManipulate());
            Assert.AreEqual(52, _deck.Count());
        }

        [TestMethod]
        public void Can_shuffle()
        {
            _deck.Manipulate(new FisherYatesShuffle());
            Assert.AreEqual(52, _deck.Count());
        }

        [TestMethod]
        public void Can_empty()
        {
            _deck.Empty();
            Assert.AreEqual(0, _deck.Count());
        }

        [TestMethod]
        public void Can_create_empty()
        {
            var deck = Deck.NewEmptyDeck();
            Assert.AreEqual(0, deck.Count());
        }

        [TestMethod]
        public void Can_perfect_riffle_shuffle()
        {
            _deck.Manipulate(new RiffleShuffle());
            Assert.AreEqual(52, _deck.Count());
        }
    }
}