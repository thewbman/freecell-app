using FreecellLib;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FreecellApp
{
    public class CardComponent : Frame
    {
        public BindableProperty NameProperty = BindableProperty.Create("Name", typeof(string), typeof(CardComponent), null);

        public string Name {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public BindableProperty ShortNameProperty = BindableProperty.Create("ShortName", typeof(string), typeof(CardComponent), null);

        public string ShortName {
            get { return (string)GetValue(ShortNameProperty); }
            set { SetValue(ShortNameProperty, value); }
        }

        public BindableProperty CardProperty = BindableProperty.Create("Card", typeof(ICard), typeof(CardComponent), null);
        public ICard Card {
            get { return (ICard)GetValue(CardProperty); }
            set { ShortName = value?.ShortName; Name = value?.ShortName; SetValue(CardProperty, value); }
        }

        public CardComponent(ICard _card = null, int gridRow = 0, int gridCol = 0, double fontSize = 16) {
            Card = _card;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.FillAndExpand;
            Padding = 0;
            Content = new Frame() {
                BackgroundColor = Card?.BackgroundColor ?? Color.WhiteSmoke,
                //Padding = 1,
                //Margin = 1,
                MinimumWidthRequest = 100,
                MinimumHeightRequest = 100,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = new Label() {
                    Text = this.ShortName,
                    MinimumHeightRequest = 100,
                    HorizontalTextAlignment = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    //Padding = 1,
                    //Margin = 1,
                    FontSize = fontSize,
                    TextColor = Card?.TextColor ?? Color.Black
                } 
            };
            Grid.SetRow(this, gridRow);
            Grid.SetColumn(this, gridCol);
        }

    }

    public class CardDataTemplate : DataTemplate {

        public CardDataTemplate() {

            
            Frame f = new Frame() {
                BorderColor = Color.WhiteSmoke,
                //Padding = 1,
                //Margin = 1,
                MinimumWidthRequest = 100,
                MinimumHeightRequest = 100,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            
            
            var lbl = new Label() {
                Text = "adf",//card?.ShortName,
                MinimumHeightRequest = 100,
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                //Padding = 1,
                //Margin = 1,
                FontSize = 16,
            };
            //lbl.SetBinding(Label.TextProperty, "ShortName");

            f.Content = lbl;
            

            //View = f;

            var grid = new Grid();
            var nameLabel = new Label { FontAttributes = FontAttributes.Bold };
            var ageLabel = new Label();
            var locationLabel = new Label { HorizontalTextAlignment = TextAlignment.End };

            nameLabel.SetBinding(Label.TextProperty, "Name");
            ageLabel.SetBinding(Label.TextProperty, "Age");
            locationLabel.SetBinding(Label.TextProperty, "Location");

            grid.Children.Add(nameLabel);
            grid.Children.Add(ageLabel, 1, 0);
            grid.Children.Add(locationLabel, 2, 0);

            //this = grid;
        }
    }
}
