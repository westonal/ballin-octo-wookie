using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cards;

namespace CardTrickTests
{
    [TestClass]
    public sealed class FullTrickTest
    {
        private readonly string deck1 = "3h5d6cjs6d5c8s9h5s10s7hahac2ctd9sth9c3c8hkcks2h4dtcjcqc6h4h2dkh7skd7cjd7das8cjh4c6s3d1h2s3sqsqd4s5h8d9dad";
        private readonly string deck1Half1 = "th9c3sqsqd3c8hkcks2h4d4stcjcqc6h7h4h2dkh5h8d9dad3h5d";
        private readonly string deck1Half2 = "6cjs6d5c7skd7cjd7d8s9h5stsas8cjh4c6s3dqh2sahac2ctd9s";

        [TestMethod]
        public void Real_trick_data_1()
        {
            var result = Trick.Perform(deck1, deck1Half1);
            Assert.AreEqual(Card.FromString("7h"), result.Card);
        }

        [TestMethod]
        public void Real_trick_data_1_other_half()
        {
            var result = Trick.Perform(deck1, deck1Half2);
            Assert.AreEqual(Card.FromString("7h"), result.Card);
        }

        [TestMethod]
        public void Real_trick_data_1_continued()
        {
            var result1 = Trick.Perform(deck1, deck1Half1);
            var result = Trick.Perform(result1.NewKnowledge, "th9c3sqsqd3c8hjs6d5c7skdkcks2h7cjd7d8s9h4stcqc");
            Assert.AreEqual(Card.FromString("4d"), result.Card);
        }

        [TestMethod]
        public void Real_trick_data_1_continued_other_half()
        {
            var result1 = Trick.Perform(deck1, deck1Half1);
            var result = Trick.Perform(result1.NewKnowledge, "6h5stsas8cjh4c6s3d7h4d4h2dkh5h8d9dadqh2sahac2ctd9s3h5d6c");
            Assert.AreEqual(Card.FromString("4d"), result.Card);
        }

        [TestMethod]
        public void Real_trick_data_1_other_half_continued()
        {
            var result1 = Trick.Perform(deck1, deck1Half2);
            var result = Trick.Perform(result1.NewKnowledge, "th9c3sqsqd3c8hjs6d5c7skdkcks2h7cjd7d8s9h4stcqc");
            Assert.AreEqual(Card.FromString("4d"), result.Card);
        }

        [TestMethod]
        public void Real_trick_data_1_other_half_continued_other_half()
        {
            var result1 = Trick.Perform(deck1, deck1Half2);
            var result = Trick.Perform(result1.NewKnowledge, "6h5stsas8cjh4c6s3d7h4d4h2dkh5h8d9dadqh2sahac2ctd9s3h5d6c");
            Assert.AreEqual(Card.FromString("4d"), result.Card);
        }

        [TestMethod]
        public void Real_trick_data_1_other_half_continued_other_half_no_learn()
        {
            var result1 = Trick.Perform(deck1, deck1Half2);
            var result = Trick.Perform(deck1, "6h5stsas8cjh4c6s3d7h4d4h2dkh5h8d9dadqh2sahac2ctd9s3h5d6c");
            Assert.AreEqual(Card.FromString("4d"), result.Card);
        }
    }
}
