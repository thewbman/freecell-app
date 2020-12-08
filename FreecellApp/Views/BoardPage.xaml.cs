using FreecellApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FreecellApp.Views
{
    public partial class BoardPage : ContentPage
    {
        BoardViewModel _viewModel;

        public BoardPage() {
            InitializeComponent();

            BindingContext = _viewModel = new BoardViewModel();
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

    }
}