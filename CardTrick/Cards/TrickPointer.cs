namespace Cards
{
    public class TrickPointer
    {
        private readonly DeckRing _deckRing;
        private int _idx;

        public TrickPointer(DeckRing deckRing, int idx)
        {
            _deckRing = deckRing;
            _idx = idx;
        }

        public void MoveOn()
        {
            _idx++;
        }

        public bool IsExpected(Card card, int i = 0)
        {
            return _deckRing.NextIs(_idx + i, card);
        }

        public Card Expected()
        {
            return _deckRing.Next(_idx);
        }
    }
}