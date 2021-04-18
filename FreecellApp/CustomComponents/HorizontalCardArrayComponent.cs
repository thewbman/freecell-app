using FreecellLib;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace FreecellApp
{
    public class HorizontalCardArrayComponent : Grid
    {
        /// <summary>
        /// Component to hold a 2D list of cards only showing the top card
        /// </summary>
        /// <param name="cards"></param>
        public HorizontalCardArrayComponent(List<List<ICard>> cards) {
            //Padding = 1;
            //Margin = 1;
            //MinimumHeightRequest = 100;
            RowDefinitions = new RowDefinitionCollection() { new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) } };
            ColumnDefinitions = new ColumnDefinitionCollection();
            ColumnSpacing = 1;
            RowSpacing = 1;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.FillAndExpand;
            for (int i = 0; i < cards?.Count(); i++) {
                this.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                var lbl = new CardComponent(cards[i].LastOrDefault(), 0, i);
                this.Children.Add(lbl);
            }
        }

        
    }
}
