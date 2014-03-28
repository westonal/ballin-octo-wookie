using System.Collections.Generic;

namespace Cards.Manipulations
{
    public sealed class NullManipulate : IDeckManipulator
    {
        public List<Card> Manipulate(List<Card> cards)
        {
            return cards;
        }
    }
}