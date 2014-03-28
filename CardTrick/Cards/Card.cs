namespace Cards
{
    public sealed class Card
    {
        public Card(Suit suit, CardValue cardValue)
        {
            Suit = suit;
            CardValue = cardValue;
        }

        public CardValue CardValue { get; private set; }
        public Suit Suit { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", CardValue, Suit);
        }

        public static Card FromString(string asString)
        {
            return new Card(Suit.Club, CardValue.Ace);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Card);
        }

        public bool Equals(Card other)
        {
            return other.Suit == Suit && other.CardValue == CardValue;
        }

        public override int GetHashCode()
        {
            return Suit.GetHashCode()*31 + CardValue.GetHashCode();
        }
    }
}