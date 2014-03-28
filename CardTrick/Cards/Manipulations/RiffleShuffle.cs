using System.Collections.Generic;
using System.Linq;

namespace Cards.Manipulations
{
    public class RiffleShuffle : IDeckManipulator
    {
        public List<Card> Manipulate(List<Card> cards)
        {
            var size = cards.Count/2;
            var newCards = new List<Card>();
            var half1 = cards.Take(size).ToList();
            var half2 = cards.Skip(size).ToList();
            for (var n = 0; n < size; n++)
            {
                newCards.Add(half1.First());
                newCards.Add(half2.First());
                half1.RemoveAt(0);
                half2.RemoveAt(0);
            }
            return newCards;
        }
    }
}