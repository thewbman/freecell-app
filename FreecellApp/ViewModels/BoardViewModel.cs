using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using FreecellApp.Services;
using FreecellLib;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;

namespace FreecellApp.ViewModels
{
    public class BoardViewModel : BaseViewModel
    {
        // https://en.wikipedia.org/wiki/FreeCell
     
        const int c_cnt_opencells = 4;
        const int c_cnt_foundations = 4;
        const int c_cnt_cascades = 8;


        public ObservableCollection<ICard> Deck { get; private set; }
        public ObservableCollection<IEnumerable<ICard>> FullFoundations { get; private set; }
        public ObservableCollection<ICard> Foundations { get; private set; }
        public ObservableCollection<IEnumerable<ICard>> FullCascades { get; private set; }
        public ObservableCollection<ICard> Cascades { get; private set; }
        public ObservableCollection<ICard> Freecells { get; private set; }
        public bool BoardIsSet = false;

        public Command<Card> ItemTapped { get; }

        public BoardViewModel() {
            Title = "Board";
            Deck = new ObservableCollection<ICard>();
            FullFoundations = new ObservableCollection<IEnumerable<ICard>>();
            Foundations = new ObservableCollection<ICard>();
            FullCascades = new ObservableCollection<IEnumerable<ICard>>();
            Cascades = new ObservableCollection<ICard>();
            Freecells = new ObservableCollection<ICard>();

            //LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(forceRefresh: true));

            //ItemTapped = new Command<Card>(OnItemSelected);
        }


        async Task ExecuteLoadItemsCommand(bool forceRefresh = false) {
            IsBusy = true;

            try {
                Deck.Clear();
                var items = await DataStore.GetItemsAsync(forceRefresh);
                foreach (var item in items) {
                    Deck.Add(item);
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex);
            } finally {
                IsBusy = false;
            }
        }

        public void OnAppearing() {
            IsBusy = true;

            if (Deck.Count == 0) ExecuteLoadItemsCommand().Wait();

            if (!BoardIsSet) SetBoard();
        }

        public void SetBoard() {
            FullFoundations.Clear();
            foreach (var suit in CardEx.ValidSuits) FullFoundations.Add(new ICard[] { new BaseSuitCard(suit) });
            Foundations.Clear();
            foreach (var fs in FullFoundations) Foundations.Add(fs.LastOrDefault());

            FullCascades.Clear();
            List<List<ICard>> layout = new List<List<ICard>>();
            for (int c = 0; c < Deck.Count; c++) {
                int col = c % c_cnt_cascades;
                int pos = c - (c_cnt_cascades * col);
                if (layout.Count <= col) layout.Add(new List<ICard>());
                layout[col].Add(Deck[c]);
            }
            foreach (var col in layout) FullCascades.Add(col);
            Cascades.Clear();
            foreach (var fc in FullCascades) Cascades.Add(fc.LastOrDefault());

            Freecells.Clear();
            for (int i = 0; i < c_cnt_opencells; i++) Freecells.Add(new EmptyCard());

            BoardIsSet = true;
        }

    }
}
