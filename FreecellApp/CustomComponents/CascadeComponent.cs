using FreecellLib;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace FreecellApp
{
    public class CascadeComponent : Grid
    {
        private ICard[][] _Cards = null;

        public CascadeComponent(ICard[][] cards, bool showAll = false) {
            _Cards = cards;
            //Padding = 1;
            //Margin = 1;
            //MinimumHeightRequest = 100;
            RowDefinitions = new RowDefinitionCollection() { new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) } };
            ColumnDefinitions = new ColumnDefinitionCollection();
            ColumnSpacing = 1;
            RowSpacing = 1;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.FillAndExpand;

            RefreshView();
        }

        private void RefreshView() {
            this.Children.Clear();
            this.ColumnDefinitions.Clear();

            for (int i = 0; i < _Cards?.Length; i++) {
                this.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                var col = new DataTemplates.CascadeComponentXaml();
                col.ItemsSource = _Cards[i].ToList();
                col.SelectionChanged += OnSelectionChanged;

                /*
                var col = new CollectionView() {
                    ItemsSource = cards[i].ToList(),
                    //ItemsSource = new ICard[] { new EmptyCard() },
                    ItemTemplate = new DataTemplate(
                        //() => { CardComponentCS cardComponentCS = new CardComponentCS(); return cardComponentCS; })
                        typeof(CardDataTemplate)
                //typeof(CardComponentCS))

                () => {
                    var component = new CardComponent(fontSize: 10);
                    component.SetBinding(component.NameProperty, "ShortName");
                    return component;
                })

        };
        //col.SetBinding(ItemsView.ItemsSourceProperty, cards[i].ToList());
        */

                //var col = new StackLayout() { Orientation = StackOrientation.Vertical };
                //Grid.SetRow(col, 0);
                //Grid.SetColumn(col, i);
                //for (int j = 0; j < cards[i]?.Length; j++) {
                //    var lbl = new CardComponent(cards[i][j], fontSize: 10);
                //    col.Children.Add(lbl);
                //}
                this.Children.Add(col, i, 0);
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (e == null) return;

            ICard previous = null;
            foreach (var c in _Cards?.SelectMany(z => z)) {
                if (c.Selected) previous = c;
                c.Selected = false;
            }
            var current = e.CurrentSelection.FirstOrDefault() as ICard;
            if (current != null) current.Selected = true;
            if (previous.CanBePlacedOnSingle(current)) this.BackgroundColor = Color.Green;
            else this.BackgroundColor = Color.Yellow;
            RefreshView();
        }
    }
}
