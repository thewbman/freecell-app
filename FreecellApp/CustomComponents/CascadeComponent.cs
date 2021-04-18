using FreecellLib;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace FreecellApp
{
    public class CascadeComponent : Grid
    {
        private List<List<ICard>> _Cards = null;
        private ICard _SelectedCard = CardEx.Empty;
        private int _SelectedCascade = -1;

        public CascadeComponent(List<List<ICard>> cards, bool showAll = false) {
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
            BackgroundColor = Color.Gray;

            RefreshView();
        }

        private void RefreshView() {
            this.Children.Clear();
            this.ColumnDefinitions.Clear();

            for (int i = 0; i < _Cards?.Count; i++) {
                this.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                var col = new DataTemplates.CascadeComponentXaml(i);
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

            var previousCol = _SelectedCascade;
            _SelectedCascade = (sender as DataTemplates.CascadeComponentXaml)?.Column ?? -1;
            ICard top = (_SelectedCascade >= 0) ? _Cards[_SelectedCascade].LastOrDefault() : CardEx.Empty; // card available to play of cascade (visually on bottom but called top)

            ICard previous = null;
            foreach (var c in _Cards?.SelectMany(z => z)?.Where(z => z.Selected)) {
                //if (c.Selected) previous = c;
                c.Selected = false;
            }
            previous = _SelectedCard;

            var current = e.CurrentSelection.FirstOrDefault() as ICard;
            if ((current != null) && (top == current)) { // only allow top card in cascade to be selected
                current.Selected = true;
            }

            if (previous == CardEx.Empty) this.BackgroundColor = Color.Gray; // nothing previously selected
            else if (previous == current) this.BackgroundColor = Color.Gray; // same card
            else if (previous.CanBePlacedOnSingle(current)) this.BackgroundColor = Color.Green; // move is valid
            else this.BackgroundColor = Color.Yellow; // invalid move

            _SelectedCard = current;

            RefreshView();
        }
    }
}
