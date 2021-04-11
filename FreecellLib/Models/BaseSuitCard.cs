using System.Drawing;

namespace FreecellLib
{
    public class BaseSuitCard : CardBase {
        public override string DisplayName => $"{Suit}";
        public override string ShortName => $"{Suit.ToString().Substring(0, 1)}";

        public BaseSuitCard(CardSuit _suit) : base(_suit, CardValue.Default) { }
    }
}
