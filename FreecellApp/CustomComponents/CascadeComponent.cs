using FreecellLib;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace FreecellApp
{
    public class CascadeComponent : Grid
    {

        public CascadeComponent(ICard[][] cards, bool showAll = false) {
            //Padding = 1;
            //Margin = 1;
            //MinimumHeightRequest = 100;
            RowDefinitions = new RowDefinitionCollection() { new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) } };
            ColumnDefinitions = new ColumnDefinitionCollection();
            ColumnSpacing = 1;
            RowSpacing = 1;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.FillAndExpand;
            for (int i = 0; i < cards?.Length; i++) {
                this.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                var col = new CollectionView() {
                    ItemsSource = cards[i].ToList(),
                    //ItemsSource = new ICard[] { new EmptyCard() },
                    ItemTemplate = new DataTemplate(
                        /*typeof(CardDataTemplate)*/
                        () => {
                            return new CardComponent(new EmptyCard(), fontSize: 10);
                        })
                };


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
    }
}
