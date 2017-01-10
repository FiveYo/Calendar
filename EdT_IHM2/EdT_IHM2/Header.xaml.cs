using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EdT_IHM2
{
    public partial class Header : ContentView
    {
        public Header()
        {
            InitializeComponent();
            var tapImage = new TapGestureRecognizer();
            //Binding events  
            tapImage.Tapped += tapImage_Tapped;
            //Associating tap events to the image buttons  
            img.GestureRecognizers.Add(tapImage);

        }
            void tapImage_Tapped(object sender, EventArgs e)
            {
                // handle the tap  
                DisplayAlert("Alert", "This is an image button", "OK");
            }

        private void DisplayAlert(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }
    }


    }

