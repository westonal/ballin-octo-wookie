using System.Collections.Generic;

namespace Cards.Manipulations
{
    public class AddCards : IDeckManipulator
    {
        private readonly List<Card> _cardsToAdd;

        public AddCards(List<Card> cardsToAdd)
        {
            _cardsToAdd = cardsToAdd;
        }

        public List<Card> Manipulate(List<Card> cards)
        {
            cards.AddRange(_cardsToAdd);
            return cards;
        }
    }
}