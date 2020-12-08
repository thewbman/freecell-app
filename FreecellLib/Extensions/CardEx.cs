using System;
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
        public static CardColor ToColor(this Card c) => c?.Suit.ToColor() ?? CardColor.Unknown;

        /// <summary>
        /// Single cards are places alternating colors in decreasing consecutive value
        /// </summary>
        /// <returns></returns>
        public static bool CanBePlacedOnSingle(this Card c, Card p) {
            if (c == null || p == null) return false;
            if (c.ToColor() == p.ToColor()) return false;
            if (c.Value != (p.Value - 1)) return false;
            return true;
        }

        public static CardSuit[] ValidSuits => _ValidSuits ?? (_ValidSuits = Enum.GetValues(typeof(CardSuit)).OfType<CardSuit>().Except(new CardSuit[] { CardSuit.Unknown }).ToArray());
        private static CardSuit[] _ValidSuits = null;
    }
}
