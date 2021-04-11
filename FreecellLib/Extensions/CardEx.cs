using System;
using System.Drawing;
using System.Linq;

namespace FreecellLib
{
    public static class CardEx
    {
        public static CardColor ToColor(this CardSuit suit) {
            switch (suit) {
                case CardSuit.Hearts:
                case CardSuit.Diamonds: return CardColor.Red;
                case CardSuit.Spades:
                case CardSuit.Clubs: return CardColor.Black;
            }
            return CardColor.Unknown;
        }
        public static CardColor ToColor(this ICard c) => c?.Suit.ToColor() ?? CardColor.Unknown;

        public static Color ToBackgroundColor(this CardColor cc, bool selected = false) {
            switch(cc) {
                case CardColor.Black: return (selected ? Color.DarkGray :  Color.LightGray);
                case CardColor.Red: return (selected ? Color.Orange : Color.Red);
            }
            return Color.Yellow;
        }
        public static Color ToTextColor(this CardColor cc, bool selected = false) {
            switch (cc) {
                case CardColor.Black: return (selected ? Color.Black : Color.Black);
                case CardColor.Red: return (selected ? Color.WhiteSmoke : Color.White);
            }
            return Color.Blue;
        }

        /// <summary>
        /// Single cards are places alternating colors in decreasing consecutive value
        /// </summary>
        /// <returns></returns>
        public static bool CanBePlacedOnSingle(this ICard c, ICard p) {
            if (c == null || p == null) return false;
            if (c.ToColor() == p.ToColor()) return false;
            if (c.Value != (p.Value - 1)) return false;
            return true;
        }

        public static CardSuit[] ValidSuits => _ValidSuits ?? (_ValidSuits = Enum.GetValues(typeof(CardSuit)).OfType<CardSuit>().Except(new CardSuit[] { CardSuit.Unknown }).ToArray());
        private static CardSuit[] _ValidSuits = null;
    }
}
