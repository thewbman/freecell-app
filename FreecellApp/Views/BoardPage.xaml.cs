using FreecellApp.ViewModels;
using FreecellLib;
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

            DisplayBoard();
        }

        private void DisplayBoard() {
            //Grid fndGrid = new Grid() { Padding = 0, Margin = 0, MinimumHeightRequest = 100 };
            //fndGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            //for (int i = 0; i < _viewModel?.Foundations.Count; i++) {
            //    fndGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            //    var lbl = new CardComponent(_viewModel.Foundations[i], 0, i);
            //    fndGrid.Children.Add(lbl);
            //}
            //FoundationStackFrame.Content = fndGrid;
            FoundationStackFrame.Content = new HorizontalCardArrayComponent(_viewModel?.Foundations?.ToArray());


            //Grid csGrid = new Grid() { Padding = 0, Margin = 0, MinimumHeightRequest = 100 };
            //csGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            //for (int i = 0; i < _viewModel?.Cascades.Count; i++) {
            //    csGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            //    var lbl = new CardComponent(_viewModel.Cascades[i], 0, i);
            //    csGrid.Children.Add(lbl);
            //}
            //CascadeStackFrame.Content = csGrid;
            CascadeStackFrame.Content = new CascadeComponent(_viewModel.FullCascades.To2DArray());

            //Grid fcGrid = new Grid() { Padding = 0, Margin = 0, MinimumHeightRequest = 100 };
            //fcGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            //for (int i = 0; i < _viewModel?.Freecells.Count; i++) {
            //    fcGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            //    //var lbl = new Frame() { BorderColor = Color.WhiteSmoke, Padding = 0, MinimumWidthRequest = 100, MinimumHeightRequest = 100, Content = new Label() { Text = _viewModel.Freecells[i].ShortName, MinimumHeightRequest = 100, HorizontalTextAlignment = TextAlignment.Center } };
            //    //Grid.SetRow(lbl, 0);
            //    //Grid.SetColumn(lbl, i);
            //    var lbl = new CardComponent(_viewModel.Freecells[i], 0, i);
            //    fcGrid.Children.Add(lbl);
            //}
            //FreecellStackFrame.Content = fcGrid;
            FreecellStackFrame.Content = new HorizontalCardArrayComponent(_viewModel?.Freecells?.ToArray());
        }

    }
}