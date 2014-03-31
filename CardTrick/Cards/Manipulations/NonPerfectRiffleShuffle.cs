using System;
using System.Collections.Generic;

namespace Cards.Manipulations
{
    public sealed class NonPerfectRiffleShuffle : IDeckManipulator
    {
        private Random random;

        public NonPerfectRiffleShuffle(Random random)
        {
            this.random = random;
        }
        public List<Card> Manipulate(List<Card> cards)
        {
            var size = cards.Count/2;
            var newCards1 = new List<Card>();
            var newCards2 = new List<Card>();
            foreach (var card in cards)
            {
                var target = random.Next(0, 2) == 0 ? newCards1 : newCards2;
                target.Add(card);
            }
            var newCards = new List<Card>();
            newCards.AddRange(newCards1);
            newCards.AddRange(newCards2);
            return newCards;
        }
    }
}
