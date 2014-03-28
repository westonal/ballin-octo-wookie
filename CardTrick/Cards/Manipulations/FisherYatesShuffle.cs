using System.Collections.Generic;

namespace Cards.Manipulations
{
    public sealed class FisherYatesShuffle : IDeckManipulator
    {
        public List<Card> Manipulate(List<Card> cards)
        {
            return cards;
        }
    }
}