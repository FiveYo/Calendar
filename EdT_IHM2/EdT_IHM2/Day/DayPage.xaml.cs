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
            context = new ObservableCollection<Evenement>
            {
                new Evenement("date",new DateTime(2017,1,12,0,29,0),new DateTime(2017,1,12,6,31,0),"Fucking working","206",new List<string>{ "La DreamTeam" },"20/20"),
                new Evenement("date1",new DateTime(2017,1,12,1,29,0),new DateTime(2017,1,12,6,31,0),"Fucking working","206",new List<string>{ "Milly", "Justin" },"20/20"),
                new Evenement("date2",new DateTime(2017,1,12,2,29,0),new DateTime(2017,1,12,4,31,0),"Fucking working","206",new List<string>{ "Quentin", "Samuel" },"20/20"),
                new Evenement("date3",new DateTime(2017,1,12,4,29,0),new DateTime(2017,1,12,6,31,0),"Ending working","206",new List<string>{ "La DreamTeam" },"20/20"),
            };
            
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listview = sender as ListView;
            var selected = listview.SelectedItem as Evenement;
            await Navigation.PushAsync(new DetailsEvents(selected));
        }
        
    }
}
