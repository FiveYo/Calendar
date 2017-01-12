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
            List<string> participants = new List<string>();
            participants.Add("-ta maman");
            participants.Add("-encore ta maman");
            participants.Add("-encore ta maman");
            participants.Add("-encore ta maman");
            participants.Add("-encore ta maman");
            BindingContext = new Evenement("Lundi 29 Fevrier", new DateTime(2016, 03, 12, 12, 30, 00), new DateTime(2016, 03, 12, 13, 30, 00), "On baise ta maman ", "Chez ta maman ", participants, "SalePute");

            var tapImage1 = new TapGestureRecognizer();
            var tapImage2 = new TapGestureRecognizer();
            //Binding events  
            tapImage1.Tapped += tapImage1_Tapped;
            tapImage2.Tapped += Return;
            //Associating tap events to the image buttons  
            img2.GestureRecognizers.Add(tapImage1);
            img.GestureRecognizers.Add(tapImage2);
        }
        async void tapImage1_Tapped(object sender, EventArgs e)
             
        {
            // handle the tap  
            var answer = await DisplayAlert("Attention", "Vous êtes sûr de vouloir supprimer cet évenement de votre emploi du temps ?", "Oui", "Non");
        }
        void Return(object sender, EventArgs e)

        {
            // handle the tap  
            DisplayAlert("Alert", "This is an image button", "OK");
        }

    }
}
