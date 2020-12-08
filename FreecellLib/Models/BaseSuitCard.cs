namespace FreecellLib
{
    public class BaseSuitCard : ICard
    {
        public override string ToString() => ShortName;
        public string DisplayName => $"{Suit}";
        public string ShortName => $"{Suit.ToString().Substring(0,1)}";
        public int ID => (int)Suit * 100 + (int)Value;
        public CardSuit Suit { get; private set; }
        public CardValue Value => CardValue.Default;

        public BaseSuitCard(CardSuit _suit) {
            Suit = _suit;
        }
    }
}
