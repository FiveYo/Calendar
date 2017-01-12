using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EdT_IHM2
{
    public partial class DetailsEvents : ContentPage
    {
        public DetailsEvents()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public DetailsEvents(Evenement ev)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = ev;
            var tapImage1 = new TapGestureRecognizer();
            var tapImage2 = new TapGestureRecognizer();
            var tapImage3 = new TapGestureRecognizer();
            //Binding events  
            tapImage1.Tapped += ToReturn;
            tapImage2.Tapped += ToModify;
            tapImage3.Tapped += ToDelete;
            //Associating tap events to the image buttons  
            return_im.GestureRecognizers.Add(tapImage1);
            modif_img.GestureRecognizers.Add(tapImage2);
            delete_img.GestureRecognizers.Add(tapImage3);
        }
        async void ToDelete(object sender, EventArgs e)
        {
            // handle the tap  
            var answer = await DisplayAlert("Attention", "Vous êtes sûr de vouloir supprimer cet évenement de votre emploi du temps ?", "Non", "Oui");
            if (!answer)
            {
                await Navigation.PopAsync();
            }
        }
        async void ToReturn(object sender, EventArgs e)

        {
            await Navigation.PopAsync();
        }

        async void ToModify(object sender, EventArgs e,Evenement ev)
        {
            await Navigation.PushAsync(new newEvent(ev));
        }
        async void ToMap(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MapView());
        }

    }
}
