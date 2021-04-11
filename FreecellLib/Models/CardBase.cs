using System.Drawing;

namespace FreecellLib
{
    public abstract class CardBase : ICard
    {
        public override string ToString() => ShortName;
        public virtual string DisplayName => $"{Value} of {Suit}";
        public virtual string ShortName => $"{(int)Value}{Suit.ToString().Substring(0, 1)}";
        public int ID => (int)Suit * 100 + (int)Value;
        public CardSuit Suit { get; private set; }
        public CardValue Value { get; private set; }

        public virtual Color BackgroundColor { get { return _BackgroundColor ?? this.Suit.ToColor().ToBackgroundColor(Selected); } }
        private Color? _BackgroundColor = null;
        public virtual Color TextColor { get { return _TextColor ?? this.Suit.ToColor().ToTextColor(Selected); } }
        private Color? _TextColor = null;

        public bool Selected {
            get => _Selected; set {
                _Selected = value;
                _BackgroundColor = this.Suit.ToColor().ToBackgroundColor(Selected);
                _TextColor = this.Suit.ToColor().ToTextColor(Selected);
            }
        }
        private bool _Selected = false;

        public CardBase(CardSuit _suit, CardValue _value) {
            Suit = _suit;
            Value = _value;
        }

    }
}
