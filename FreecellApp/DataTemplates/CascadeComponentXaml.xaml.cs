using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FreecellApp.DataTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CascadeComponentXaml : CollectionView
    {
        public CascadeComponentXaml(int col) {
            Column = col;
            InitializeComponent();
        }

        public int Column { get; private set; }
    }
}