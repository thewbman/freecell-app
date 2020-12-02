using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using FreecellApp.Views;
using FreecellLib;

namespace FreecellApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Card _selectedItem;

        public ObservableCollection<Card> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Card> ItemTapped { get; }

        public ItemsViewModel() {
            Title = "Deck of Cards";
            Items = new ObservableCollection<Card>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Card>(OnItemSelected);
        }

        async Task ExecuteLoadItemsCommand() {
            IsBusy = true;

            try {
                Items.Clear();
                var items = await DataStore.GetItemsAsync();
                foreach (var item in items) {
                    Items.Add(item);
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex);
            } finally {
                IsBusy = false;
            }
        }

        public void OnAppearing() {
            IsBusy = true;
            SelectedItem = null;
        }

        public Card SelectedItem {
            get => _selectedItem;
            set {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        async void OnItemSelected(Card item) {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            var page = $"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.ShortName}";
            await Shell.Current.GoToAsync(page);
        }
    }
}