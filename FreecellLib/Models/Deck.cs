using System;
using System.Collections.Generic;
using System.Linq;

namespace FreecellLib
{
    /// <summary>
    /// Set of cards
    /// </summary>
    public class Deck
    {
        public static Deck FullDeck(bool shuffle = false) {
            var ret = new Deck();
            if (shuffle) ret.Shuffle();
            return ret;
        }
        public static Deck QuarterDeck(bool shuffle = false) {
            var ret = new Deck(new CardSuit[] { CardSuit.Clubs, CardSuit.Diamonds }, c_maxValues/2);
            if (shuffle) ret.Shuffle();
            return ret;
        }
        public static Deck HalfDeck(bool shuffle = false) {
            var ret = new Deck(new CardSuit[] { CardSuit.Clubs, CardSuit.Diamonds }, c_maxValues);
            if (shuffle) ret.Shuffle();
            return ret;
        }
        public static Deck BlackHalfDeck(bool shuffle = false) {
            var ret = new Deck(new CardSuit[] { CardSuit.Clubs, CardSuit.Spades }, c_maxValues);
            if (shuffle) ret.Shuffle();
            return ret;
        }
        public static Deck RedHalfDeck(bool shuffle = false) {
            var ret = new Deck(new CardSuit[] { CardSuit.Hearts, CardSuit.Diamonds }, c_maxValues);
            if (shuffle) ret.Shuffle();
            return ret;
        }

        public const int c_maxSuits = 4;
        public const int c_maxValues = 13;


        public Deck() {
            List<Card> c = new List<Card>();
            foreach(var s in Enum.GetValues(typeof(CardSuit)).OfType<CardSuit>()) {
                if (s == CardSuit.Unknown) continue;
                foreach (var v in Enum.GetValues(typeof(CardValue)).OfType<CardValue>()) {
                    if (v == CardValue.Default) continue;
                    c.Add(new Card(s, v));
                }
            }
            AllCards = c.ToArray();
            _Cards = AllCards.OrderBy(z => z.ID).ToList();
        }
        public Deck(CardSuit[] suits, CardValue[] values) {
            if ((suits?.Count() ?? 0) <= 0) suits = Enum.GetValues(typeof(CardSuit)).OfType<CardSuit>().ToArray();
            if ((values?.Count() ?? 0) <= 0) values = Enum.GetValues(typeof(CardValue)).OfType<CardValue>().ToArray();
            List<Card> c = new List<Card>();
            foreach (var s in suits.OrderBy(z => (int)z)) {
                if (s == CardSuit.Unknown) continue;
                foreach (var v in values.OrderBy(z => (int)z)) {
                    if (v == CardValue.Default) continue;
                    c.Add(new Card(s, v));
                }
            }
            AllCards = c.ToArray();
            _Cards = AllCards.OrderBy(z => z.ID).ToList();
        }
        public Deck(CardSuit[] suits, int cntValues = c_maxValues) {
            if ((suits?.Count() ?? 0) <= 0) suits = Enum.GetValues(typeof(CardSuit)).OfType<CardSuit>().ToArray();
            if (cntValues <= 0 || cntValues > c_maxValues) cntValues = c_maxValues;
            CardValue[] values = Enum.GetValues(typeof(CardValue)).OfType<CardValue>().OrderBy(z => (int)z).Take(cntValues).ToArray();
            List<Card> c = new List<Card>();
            foreach (var s in suits.OrderBy(z => (int)z)) {
                if (s == CardSuit.Unknown) continue;
                foreach (var v in values.OrderBy(z => (int)z)) {
                    if (v == CardValue.Default) continue;
                    c.Add(new Card(s, v));
                }
            }
            AllCards = c.ToArray();
            _Cards = AllCards.OrderBy(z => z.ID).ToList();
        }

        /// <summary>
        /// Fixed ordering of all included cards
        /// </summary>
        public Card[] AllCards { get; private set; }

        /// <summary>
        /// Ordered set of cards. On init will match AllCards, but order can be altered
        /// </summary>
        public List<Card> Cards {
            get {
                return _Cards ?? (_Cards = AllCards.OrderBy(z => z.ID).ToList());
            }
        }
        private List<Card> _Cards = null;

        public bool Shuffle() {
            Random r = new Random();
            _Cards = Cards?.OrderBy(z => r.Next()).ToList();
            return true;
        }
    }
}
