using System;
using Cards;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardTrickTests
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void Equal()
        {
            Assert.AreEqual(new Card(Suit.Club, CardValue.Ace), new Card(Suit.Club, CardValue.Ace));
        }

        [TestMethod]
        public void In_equal_by_suit()
        {
            Assert.AreNotEqual(new Card(Suit.Club, CardValue.Ace), new Card(Suit.Diamond, CardValue.Ace));
        }

        [TestMethod]
        public void In_equal_by_value()
        {
            Assert.AreNotEqual(new Card(Suit.Club, CardValue.Ace), new Card(Suit.Club, CardValue.Two));
        }

        [TestMethod]
        [Ignore]
        public void Can_create_from_string()
        {
            foreach (Suit suit in Enum.GetValues(typeof (Suit)))
            {
                foreach (CardValue cardValue in Enum.GetValues(typeof (CardValue)))
                {
                    var expected = new Card(suit, cardValue);
                    var asString = expected.ToString();
                    Assert.AreEqual(expected, Card.FromString(asString));
                }
            }
        }
    }
}