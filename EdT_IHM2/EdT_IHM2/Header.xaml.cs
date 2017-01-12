using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using Xamarin.Forms;

namespace EdT_IHM2
{
    public class EventHandlerHeader : Page
    {

        public async void OnLabelClicked(Label temps)
        {
            var action = await DisplayActionSheet("Choix", null, null, "Semaine", "Jour");
            Debug.WriteLine("Action: " + action);
            temps.Text = action;
        }

        public async void OnLabelClickedParam(Image param)
        {
            var action = await DisplayActionSheet("Choix", null, null, "Compte", "Deconnexion");
            Debug.WriteLine("Action: " + action);
            if (action.Equals("Compte"))
            {
                await Navigation.PushAsync(new Paramètres.Compte());
                //await DisplayAlert("Alert", "Page paramètre", "OK");
            }
            else
            {
                await Navigation.PushAsync(new Login());
            }
        }
    }
    public partial class Header : ContentView
    {
        public event EventHandler DisplayPopUp;

        public void changeLabelText(String text)
        {
            temps.Text = text;
        }

        public Header()
        {
            InitializeComponent();
        //Creating TapGestureRecognizers  
        var tapImage = new TapGestureRecognizer();
            //Binding events  
            tapImage.Tapped += (s, e) => DisplayPopUp?.Invoke(s, e);
            //Associating tap events to the image buttons 
        img.GestureRecognizers.Add(tapImage);

            // Choix semaine ou jour
            var tgr = new TapGestureRecognizer();
        tgr.Tapped += (s, e) => DisplayPopUp?.Invoke(s, e);
        temps.GestureRecognizers.Add(tgr);

            // Paramètres
            var tgr2 = new TapGestureRecognizer();
        tgr2.Tapped += (s, e) => DisplayPopUp?.Invoke(s, e);
        param.GestureRecognizers.Add(tgr2);

        }

    void tapImage_Tapped(object sender, EventArgs e)
    {

        // handle the tap  

    }


}


}

