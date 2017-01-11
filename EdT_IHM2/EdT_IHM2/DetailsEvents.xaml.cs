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
            BindingContext = new Evenement("Lundi 29 Fevrier",new DateTime(2016,03,12,12,30,00), new DateTime(2016, 03, 12, 13, 30, 00) ,"On baise ta maman ","Chez ta maman ", participants, "SalePute");
        }
    
      
    }
}
