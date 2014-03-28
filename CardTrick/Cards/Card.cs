namespace Cards
{
    public class Card
    {
        public CardValue CardValue { get; internal set; }
        public Suit Suit { get; internal set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", CardValue, Suit);
        }
    }
}