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
            NavigationPage.SetHasNavigationBar(this, false);
        }
        void switcher_Toggled(object sender, ToggledEventArgs e)
        {
        //    label.Text = String.Format("Switch is now {0}", e.Value);
        }
    }
}
