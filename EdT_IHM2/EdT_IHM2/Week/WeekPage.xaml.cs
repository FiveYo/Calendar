using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            header.DisplayPopUp += Header_ChangeView;
        }

        private async void Header_ChangeView(object sender, EventArgs e)
        {
            if( (sender as View).ClassId == "1")
            {
                var action = await DisplayActionSheet("Choix", null, null, "Compte", "Recherche", "Conseil et aides", "Deconnexion");
                //Debug.WriteLine("Action: " + action);
                if(action != null)
                {
                    if (action == "Compte")
                    {
                        await Navigation.PushAsync(new Paramètres.Compte());
                        //await DisplayAlert("Alert", "Page paramètre", "OK");
                    }
                    else if(action == "Recherche")
                    {
                        await Navigation.PushAsync(new Paramètres.Recherche());
                    }
                    else if(action == "Conseil et aides")
                    {

                    }
                    else
                    {
                        await Navigation.PushAsync(new Login());
                    }
                }     
            }
            else if ((sender as View).ClassId == "0")
            {
                var action = await DisplayActionSheet("Choix", null, null, "Semaine", "Jour");
                if (action != null)
                {
                    Debug.WriteLine("Action: " + action);
                    header.changeLabelText(action);
                }
            }
            else if ((sender as View).ClassId == "2")
            {
                
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            carousel.OnAppearing();
        }
    }
}
