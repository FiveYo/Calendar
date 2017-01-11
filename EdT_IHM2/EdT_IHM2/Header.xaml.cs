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

            //Creating TapGestureRecognizers  
            var tapImage = new TapGestureRecognizer();
            //Binding events  
            tapImage.Tapped += tapImage_Tapped;
            //Associating tap events to the image buttons  
            img.GestureRecognizers.Add(tapImage);
        }
        void tapImage_Tapped(object sender, EventArgs e)
        {
            // handle the tap  

        }


    }


}

