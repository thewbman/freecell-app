namespace FreecellLib
{
    public class EmptyCard : ICard
    {
        public override string ToString() => ShortName;
        public string DisplayName => $"[ ]";
        public string ShortName => $"[ ]";
        public int ID => (int)Suit * 100 + (int)Value;
        public CardSuit Suit => CardSuit.Unknown;
        public CardValue Value => CardValue.Default;

        public EmptyCard() {
        }
    }
}
