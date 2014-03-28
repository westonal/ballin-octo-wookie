using System.Collections.Generic;

namespace Cards.Manipulations
{
    public interface IDeckManipulator
    {
        List<Card> Manipulate(List<Card> cards);
    }
}