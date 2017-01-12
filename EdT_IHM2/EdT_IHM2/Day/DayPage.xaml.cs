using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using EdT_IHM2;
using System.Diagnostics;

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
            //context = 
        }

        public DayPage(ObservableCollection<Evenement> list, DateTime day)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            ObservableCollection<Evenement> context_tmp = new ObservableCollection<Evenement>();
            foreach (var item in list.Where(i => { return i.DateDebut.Day == day.Day && i.DateDebut.Month == day.Month && i.DateDebut.Year == day.Year; }))
            {
                context_tmp.Add(item);
            }
            context = context_tmp;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listview = sender as ListView;
            var selected = listview.SelectedItem as Evenement;
            await Navigation.PushAsync(new DetailsEvents(selected));
        }

    }
}
