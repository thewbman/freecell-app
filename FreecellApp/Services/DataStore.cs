using FreecellLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreecellApp.Services
{
    public class DataStore : IDataStore<Card> {
        private List<Card> items {
            get {
                if (_items == null) {
                    Deck d = Deck.FullDeck(shuffle: true);
                    _items = d.Cards;
                }
                var first = _items?.FirstOrDefault();
                return _items;
            }
        }
        private List<Card> _items = null;

        public DataStore() {
        }

        public async Task<Card> GetItemAsync(string itemId) {
            return await Task.FromResult(items.FirstOrDefault(s => s.ShortName == itemId));
        }

        public async Task<List<Card>> GetItemsAsync(bool forceRefresh = false) {
            if (forceRefresh) _items = null;
            var ret = items;
            return await Task.FromResult(ret);
        }

        public async Task<IEnumerable<Card>> GetAllParents(Card c) {
            List<Card> ret = new List<Card>();
            foreach (var p in items) if (c.CanBePlacedOnSingle(p)) ret.Add(p);
            return await Task.FromResult(ret);
        }
        public async Task<IEnumerable<Card>> GetAllChildren(Card p) {
            List<Card> ret = new List<Card>();
            foreach (var c in items) if (c.CanBePlacedOnSingle(p)) ret.Add(c);
            return await Task.FromResult(ret);
        }
    }
}