using System;
using System.Collections.Generic;
using FreecellApp.ViewModels;
using FreecellApp.Views;
using Xamarin.Forms;

namespace FreecellApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell() {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
        }

    }
}
