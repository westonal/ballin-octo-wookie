using System;
using System.Globalization;

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
            return string.Format("{0}{1}", ToString(CardValue), ToString(Suit));
        }

        private string ToString(Suit suit)
        {
            return suit.ToString()[0].ToString(CultureInfo.InvariantCulture);
        }

        private string ToString(CardValue cardValue)
        {
            switch (cardValue)
            {
                case CardValue.Ace:
                    return "A";
                case CardValue.Ten:
                    return "T";
                case CardValue.Jack:
                    return "J";
                case CardValue.King:
                    return "K";
                case CardValue.Queen:
                    return "Q";
                default:
                    return ((int) cardValue + 1).ToString(CultureInfo.InvariantCulture);
            }
        }

        public static Card FromString(string asString)
        {
            asString = asString.ToUpperInvariant();

            var suit = FindSuit(asString);
            var value = FindValue(asString);

            return new Card(suit, value);
        }

        public static Card TryFromString(string asString)
        {
            try
            {
                return FromString(asString);
            }
            catch
            {
                return null;
            }
        }

        private static CardValue FindValue(string asString)
        {
            if (asString.Contains("2"))
                return CardValue.Two;
            if (asString.Contains("3"))
                return CardValue.Three;
            if (asString.Contains("4"))
                return CardValue.Four;
            if (asString.Contains("5"))
                return CardValue.Five;
            if (asString.Contains("6"))
                return CardValue.Six;
            if (asString.Contains("7"))
                return CardValue.Seven;
            if (asString.Contains("8"))
                return CardValue.Eight;
            if (asString.Contains("9"))
                return CardValue.Nine;
            if (asString.Contains("T"))
                return CardValue.Ten;
            if (asString.Contains("10"))
                return CardValue.Ten;
            if (asString.Contains("J"))
                return CardValue.Jack;
            if (asString.Contains("Q"))
                return CardValue.Queen;
            if (asString.Contains("K"))
                return CardValue.King;
            if (asString.Contains("A"))
                return CardValue.Ace;
            if (asString.Contains("1"))
                return CardValue.Ace;
            throw new Exception("Value not specified, please use A,2-9,T,J,K,Q");
        }

        private static Suit FindSuit(string asString)
        {
            if (asString.Contains("C"))
                return Suit.Club;
            if (asString.Contains("D"))
                return Suit.Diamond;
            if (asString.Contains("H"))
                return Suit.Heart;
            if (asString.Contains("S"))
                return Suit.Spade;
            throw new Exception("Suit not specified, please use C,H,D or S");
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