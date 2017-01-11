using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EdT_IHM2
{
    public class TextHandler : Page
    {

        public async void OnLabelClicked(Label temps)
        {
            var action = await DisplayActionSheet("Choix", null, null, "Semaine", "Jour");
            Debug.WriteLine("Action: " + action);
            temps.Text= action;
        }
    }
    public partial class Header : ContentView
    {
        public Header()
        {
            InitializeComponent();
            //Creating TapGestureRecognizers  
            var tapImage = new TapGestureRecognizer();
            //Binding events  
            tapImage.Tapped += tapImage_Tapped;
            //Associating tap events to the image buttons 
            img.GestureRecognizers.Add(tapImage);

            TextHandler texteHandle = new TextHandler();
            var tgr = new TapGestureRecognizer();
            tgr.Tapped += (s, e) => texteHandle.OnLabelClicked(temps);
            temps.GestureRecognizers.Add(tgr);
        }

        void tapImage_Tapped(object sender, EventArgs e)
        {
            
            // handle the tap  

        }


    }


}

