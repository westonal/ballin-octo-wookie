using System;
using System.Linq;
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
        public void Can_create_from_string()
        {
            var expected = new Card(Suit.Club, CardValue.Ace);
            Assert.AreEqual(expected, Card.FromString("AC"));
        }

        [TestMethod]
        public void Can_create_from_string_reversed()
        {
            var expected = new Card(Suit.Club, CardValue.Ace);
            Assert.AreEqual(expected, Card.FromString("CA"));
        }

        [TestMethod]
        public void Can_create_two_from_string()
        {
            var expected = new Card(Suit.Club, CardValue.Two);
            Assert.AreEqual(expected, Card.FromString("2C"));
        }

        [TestMethod]
        public void Can_create_two_from_string_reversed()
        {
            var expected = new Card(Suit.Club, CardValue.Two);
            Assert.AreEqual(expected, Card.FromString("2C"));
        }

        [TestMethod]
        public void To_string()
        {
            Assert.AreEqual("2C", new Card(Suit.Club, CardValue.Two).ToString());
        }

        [TestMethod]
        public void Can_create_all_clubs_from_string()
        {
            const Suit suit = Suit.Club;
            foreach (CardValue cardValue in Enum.GetValues(typeof (CardValue)))
            {
                var expected = new Card(suit, cardValue);
                var asString = expected.ToString();
                Assert.AreEqual(expected, Card.FromString(asString));
            }
        }

        [TestMethod]
        public void Can_create_all_from_string()
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