using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EdT_IHM2
{
    public partial class newEvent : ContentPage
    {
        public Boolean alldaySwitchIsOn { get; set; }
        public newEvent()
        {
            InitializeComponent();
            alldaySwitchIsOn = false;
            fuseau.SelectedIndex = 13;
            rappel.SelectedIndex = 0;
            repeat.SelectedIndex = 0;
            etat.SelectedIndex = 0;
            dateDebutStack.IsVisible = !alldaySwitchIsOn;
            dateFinStack.IsVisible = !alldaySwitchIsOn;
            journee.IsVisible = alldaySwitchIsOn;
            NavigationPage.SetHasNavigationBar(this, false);
        }
        void switcher_Toggled(object sender, ToggledEventArgs e)
        {
            alldaySwitchIsOn = !alldaySwitchIsOn;
            dateDebutStack.IsVisible = !alldaySwitchIsOn;
            dateFinStack.IsVisible = !alldaySwitchIsOn;
            journee.IsVisible = alldaySwitchIsOn;
        }

        void create_onClick(object sender, EventArgs e)
        {

        }
    }
}
