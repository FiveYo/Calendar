using EdT_IHM2.Day;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EdT_IHM2
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async internal void GoToDetails(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DayPage());
        }
    }
}
