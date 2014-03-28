using Cards;
using Cards.Manipulations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardTrickTests
{
    [TestClass]
    public sealed class CardTrickTest
    {
        [TestMethod]
        public void Can_perform_trick()
        {
            //setup
            var deck = new Deck();
            var deckRing = new DeckRing();
            deckRing.Add(deck);

            //trick steps
            deck.Manipulate(new Cut(20));
            deck.Manipulate(new RiffleShuffle());
            var deck2 = Deck.NewEmptyDeck();

            deck.Manipulate(new Cut(26, deck2));

            Assert.AreEqual(26, deck.Count());
            Assert.AreEqual(26, deck2.Count());

            var card = deck.TakeCard(10);
            deck2.InsertCard(card, 15);

            Assert.AreEqual(25, deck.Count());
            Assert.AreEqual(27, deck2.Count());

            var trick = new Trick(deckRing);
            Assert.AreSame(card, trick.FindCard(deck2));
        }

        [TestMethod]
        public void Can_perform_trick_with_half_of_deck_not_containing_card()
        {
            //setup
            var deck = new Deck();
            var deckRing = new DeckRing();
            deckRing.Add(deck);

            //trick steps
            deck.Manipulate(new Cut(20));
            deck.Manipulate(new RiffleShuffle());
            var deck2 = Deck.NewEmptyDeck();

            deck.Manipulate(new Cut(26, deck2));

            Assert.AreEqual(26, deck.Count());
            Assert.AreEqual(26, deck2.Count());

            var card = deck.TakeCard(10);
            deck2.InsertCard(card, 15);

            Assert.AreEqual(25, deck.Count());
            Assert.AreEqual(27, deck2.Count());

            var trick = new Trick(deckRing);
            Assert.AreSame(card, trick.FindCard(deck));
        }
    }
}