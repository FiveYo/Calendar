using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EdT_IHM2
{
    public partial class WeekPage : ContentPage
    {
        public WeekPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            carousel.DayTapped += CarouselHeader_DayTapped;
        }

        private void CarouselHeader_DayTapped(object sender, EventArgs e)
        {
            //Navigation.PushAsync
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            carousel.OnAppearing();
        }
    }
}
