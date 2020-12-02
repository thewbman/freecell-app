using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace FreecellApp.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;
        private int id;
        private string children;
        private string parents;

        public string Text {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description {
            get => description;
            set => SetProperty(ref description, value);
        }

        public int ID {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string Children {
            get => children;
            set => SetProperty(ref children, value);
        }

        public string Parents {
            get => parents;
            set => SetProperty(ref parents, value);
        }

        public string ItemId {
            get {
                return itemId;
            }
            set {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string _itemId) {
            try {
                var item = await DataStore.GetItemAsync(itemId);
                ID = item.ID;
                Text = item.ShortName;
                Description = item.DisplayName;
                itemId = _itemId;

                var unders = await DataStore.GetAllChildren(item);
                Children = string.Join(",", unders.Select(z => z.ShortName));
                var overs = await DataStore.GetAllParents(item);
                Parents = string.Join(",", overs.Select(z => z.ShortName));
            } catch (Exception) {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
