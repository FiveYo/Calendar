using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EdT_IHM2
{
    public partial class MapView : ContentPage
    {
        public MapView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            var tapImage1 = new TapGestureRecognizer();
            tapImage1.Tapped += ToReturn;
            return_im.GestureRecognizers.Add(tapImage1);
        }
        async internal void ToReturn(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
