using System.ComponentModel;
using Xamarin.Forms;
using FreecellApp.ViewModels;

namespace FreecellApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage() {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}