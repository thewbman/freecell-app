namespace FreecellLib
{
    public class Card : ICard
    {
        public override string ToString() => ShortName;
        public string DisplayName => $"{Value} of {Suit}";
        public string ShortName => $"{(int)Value}{Suit.ToString().Substring(0,1)}";
        public int ID => (int)Suit * 100 + (int)Value;
        public CardSuit Suit { get; private set; }
        public CardValue Value { get; private set; }

        public Card(CardSuit _suit, CardValue _value) {
            Suit = _suit;
            Value = _value;
        }
    }
}
