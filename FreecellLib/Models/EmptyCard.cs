using System.Drawing;

namespace FreecellLib
{
    public class EmptyCard : CardBase
    {
        public override string DisplayName => $"[ ]";
        public override string ShortName => $"[ ]";

        public override Color BackgroundColor => Color.WhiteSmoke;
        public override Color TextColor => Color.DarkGray;

        public EmptyCard() : base(CardSuit.Unknown, CardValue.Default) { }
    }
}
