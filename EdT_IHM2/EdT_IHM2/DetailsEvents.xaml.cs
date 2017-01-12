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
            //BindingContext = new Evenement("Lundi 29 Fevrier", "On baise ta maman ", "12h", "13h", "Chez ta maman ", "Ta maman ", "SalePute");
        }

        public DetailsEvents(Evenement ev)
        {
            InitializeComponent();
            BindingContext = ev;
        }
    
      
    }
}
