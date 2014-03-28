using Cards;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardTrickTests
{
    [TestClass]
    public class CardRingTests
    {
        private DeckRing _deckRing;

        [TestInitialize]
        public void Setup()
        {
            _deckRing = new DeckRing();
        }

        [TestMethod]
        public void Can_add_deck()
        {
            _deckRing.Add(new Deck());
        }

        [TestMethod]
        public void Can_find_card()
        {
            var deck = new Deck();
            _deckRing.Add(deck);
            var pointer = _deckRing.FindCard(deck.TakeCard(10));
        }
    }
}