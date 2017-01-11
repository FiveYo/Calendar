using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EdT_IHM2.Day
{
    public partial class DayPage : ContentPage
    {
        public ObservableCollection<Evenement> context
        {
            get
            {
                return (ObservableCollection<Evenement>)BindingContext;
            }
            set
            {
                BindingContext = value.OrderBy(n => n.Date); //DateDebut
            }
        }
        public DayPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            context = new ObservableCollection<Evenement>
            {
                new Evenement("date","saloute","10.50","12.00","lieu","parcipant","note"),
                new Evenement("date","salout2e","10.50","12.00","lieu","parcipant","note"),
                new Evenement("date","saloute3","10.50","12.00","lieu","parcipant","note"),
                new Evenement("date","saloute4","10.50","12.00","lieu","parcipant","note"),
            };
        }
    }
}
