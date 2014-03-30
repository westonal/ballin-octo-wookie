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

        [TestMethod]
        public void Can_create_deck_from_text()
        {
            var deck = Deck.Load("2h");
            Assert.AreEqual(1, deck.Count());
            Assert.AreEqual(new Card(Suit.Heart,CardValue.Two), deck.TakeCard());
        }

        [TestMethod]
        public void Can_load_deck_with_two_cards_from_text()
        {
            var deck = Deck.Load("3D2h");
            Assert.AreEqual(2, deck.Count());
            Assert.AreEqual(new Card(Suit.Diamond, CardValue.Three), deck.TakeCard());
            Assert.AreEqual(new Card(Suit.Heart, CardValue.Two), deck.TakeCard());
        }

        [TestMethod]
        public void Can_load_deck_with_two_cards_from_text_with_a_space()
        {
            var deck = Deck.Load("3D 2h");
            Assert.AreEqual(2, deck.Count());
            Assert.AreEqual(new Card(Suit.Diamond, CardValue.Three), deck.TakeCard());
            Assert.AreEqual(new Card(Suit.Heart, CardValue.Two), deck.TakeCard());
        }

        [TestMethod]
        public void Can_load_deck_with_three_cards_from_text_with_spaces_and_commas()
        {
            var deck = Deck.Load("3D,2h, s6");
            Assert.AreEqual(3, deck.Count());
            Assert.AreEqual(new Card(Suit.Diamond, CardValue.Three), deck.TakeCard());
            Assert.AreEqual(new Card(Suit.Heart, CardValue.Two), deck.TakeCard());
            Assert.AreEqual(new Card(Suit.Spade, CardValue.Six), deck.TakeCard());
        }

        [TestMethod]
        public void Can_load_deck_with_three_cards_but_repeating_one_doesnt_affect_order()
        {
            var deck = Deck.Load("3D, 2h, s6, 3d");
            Assert.AreEqual(3, deck.Count());
            Assert.AreEqual(new Card(Suit.Diamond, CardValue.Three), deck.TakeCard());
            Assert.AreEqual(new Card(Suit.Heart, CardValue.Two), deck.TakeCard());
            Assert.AreEqual(new Card(Suit.Spade, CardValue.Six), deck.TakeCard());
        }

        [TestMethod]
        public void Can_load_deck_with_unknown_card()
        {
            var deck = Deck.Load("3D, 2h, 5x, 7c");
            Assert.AreEqual(4, deck.Count());
            Assert.AreEqual(new Card(Suit.Diamond, CardValue.Three), deck.TakeCard());
            Assert.AreEqual(new Card(Suit.Heart, CardValue.Two), deck.TakeCard());
            Assert.AreEqual(null, deck.TakeCard());
            Assert.AreEqual(new Card(Suit.Club, CardValue.Seven), deck.TakeCard());
        }

        [TestMethod]
        public void Can_load_deck_with_two_unknown_cards()
        {
            var deck = Deck.Load("3D, 2h, 5x, 7c, f7");
            Assert.AreEqual(5, deck.Count());
            Assert.AreEqual(new Card(Suit.Diamond, CardValue.Three), deck.TakeCard());
            Assert.AreEqual(new Card(Suit.Heart, CardValue.Two), deck.TakeCard());
            Assert.AreEqual(null, deck.TakeCard());
            Assert.AreEqual(new Card(Suit.Club, CardValue.Seven), deck.TakeCard());
            Assert.AreEqual(null, deck.TakeCard());
        }

        [TestMethod]
        public void Can_load_deck_with_non_complete_card()
        {
            var deck = Deck.Load("KC5");
            Assert.AreEqual(1, deck.Count());
            Assert.AreEqual(new Card(Suit.Club, CardValue.King), deck.TakeCard());
        }

        [TestMethod]
        public void Can_load_deck_with_a_tens_in_both_formats()
        {
            var deck = Deck.Load("TC10S");
            Assert.AreEqual(2, deck.Count());
            Assert.AreEqual(new Card(Suit.Club, CardValue.Ten), deck.TakeCard());
            Assert.AreEqual(new Card(Suit.Spade, CardValue.Ten), deck.TakeCard());
        }
    }
}