using System;
using System.Linq;
using FreecellLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FreecellLibTest
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void Models_Deck() {
            const int cnt = Deck.c_maxSuits * Deck.c_maxValues;
            const int chk = 20;
            Deck d = new Deck();
            Assert.AreEqual(cnt, d.AllCards.Length);
            Assert.AreEqual(cnt, d.Cards.Count());
            Assert.AreEqual(d.AllCards.Where(z => z.ToColor() == CardColor.Red).Count(), d.AllCards.Where(z => z.ToColor() == CardColor.Black).Count());
            Assert.AreEqual(d.AllCards[chk].ID, d.Cards.ToList()[chk].ID);
            d.Shuffle();
            int matches = 0;
            for(int i = 0; i < cnt; i++) {
                if (d.AllCards[i].ID == d.Cards.ToList()[i].ID) matches++;
            }
            Assert.IsTrue(matches < 5, $"Unexpected number ({matches}) of unshuffled cards");
            Card c = new Card(CardSuit.Clubs, CardValue.Five);
            Card p = new Card(CardSuit.Diamonds, CardValue.Six);
            Assert.IsTrue(c.CanBePlacedOnSingle(p));
            Assert.IsFalse(p.CanBePlacedOnSingle(c));
        }

        [TestMethod]
        public void Models_CustomDeck() {
            var suits = new CardSuit[] { CardSuit.Clubs, CardSuit.Diamonds };
            var cntValues = 10;
            int cnt = suits.Length * cntValues;
            const int chk = 4;
            Deck d = new Deck(suits, cntValues);
            Assert.AreEqual(cnt, d.AllCards.Length);
            Assert.AreEqual(cnt, d.Cards.Count());
            Assert.AreEqual(d.AllCards.Where(z => z.ToColor() == CardColor.Red).Count(), d.AllCards.Where(z => z.ToColor() == CardColor.Black).Count());
            Assert.AreEqual(d.AllCards[chk].ID, d.Cards.ToList()[chk].ID);
            d.Shuffle();
            int matches = 0;
            for (int i = 0; i < cnt; i++) {
                if (d.AllCards[i].ID == d.Cards.ToList()[i].ID) matches++;
            }
            Assert.IsTrue(matches < (cnt/2), $"Unexpected number ({matches}) of unshuffled cards");
        }

        [TestMethod]
        public void Models_StaticDecks() {
            const int chk = 4;
            Deck[] ds = new Deck[] { Deck.FullDeck(), Deck.QuarterDeck(), Deck.HalfDeck(), Deck.RedHalfDeck(), Deck.BlackHalfDeck() };
            foreach (var d in ds) {
                Assert.AreEqual(d.AllCards.Length, d.Cards.Count());
                int cnt = d.AllCards.Length;
                if (d.AllCards.Select(z => z.ToColor()).Distinct().Count() == 2) {
                    Assert.AreEqual(d.AllCards.Where(z => z.ToColor() == CardColor.Red).Count(), d.AllCards.Where(z => z.ToColor() == CardColor.Black).Count());
                }
                Assert.AreEqual(d.AllCards[chk].ID, d.Cards.ToList()[chk].ID);
                d.Shuffle();
                int matches = 0;
                for (int i = 0; i < cnt; i++) {
                    if (d.AllCards[i].ID == d.Cards.ToList()[i].ID) matches++;
                }
                Assert.IsTrue(matches < (cnt / 2), $"Unexpected number ({matches}) of unshuffled cards");
            }
        }
    }
}
