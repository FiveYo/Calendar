using EdT_IHM2.Day;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EdT_IHM2
{
    public partial class WeekPage : ContentPage
    {
        static ObservableCollection<Evenement> events = new ObservableCollection<Evenement>
            {
                new Evenement("12 janvier 2017", new DateTime(2017,1,12,0,29,0),new DateTime(2017,1,12,6,31,0),"working","206",new List<string>{ "La DreamTeam" },"20/20", Color.Blue),
                new Evenement("12 janvier 2017", new DateTime(2017,1,12,1,29,0),new DateTime(2017,1,12,6,31,0),"working","206",new List<string>{ "Milly", "Justin" },"20/20", Color.Aqua),
                new Evenement("12 janvier 2017", new DateTime(2017,1,12,2,29,0),new DateTime(2017,1,12,4,31,0),"working","206",new List<string>{ "Quentin", "Samuel" },"20/20", Color.Yellow),
                new Evenement("12 janvier 2017", new DateTime(2017,1,25,4,29,0),new DateTime(2017,1,25,6,31,0),"working","206",new List<string>{ "La DreamTeam" },"20/20", Color.Teal),
                new Evenement("1er janvier 2017", new DateTime(2017,1,9,8,0,0), new DateTime(2017,1,1,11,0,0),"working","206",new List<string>{ "La DreamTeam" },"20/20",Color.Blue),
                new Evenement("2 janvier 2017", new DateTime(2017,1,9,9,0,0), new DateTime(2017,1,9,12,0,0),"working","206",new List<string>{ "La DreamTeam" },"20/20",Color.Aqua),
                new Evenement("3 janvier 2017", new DateTime(2017,1,10,11,0,0), new DateTime(2017,1,10,12,0,0),"working","206",new List<string>{ "La DreamTeam" },"20/20",Color.Gray),
                new Evenement("4 janvier 2017", new DateTime(2017,1,10,15,30,0), new DateTime(2017,1,10,17,0,0),"working","206",new List<string>{ "La DreamTeam" },"20/20",Color.Yellow),
                new Evenement("5 janvier 2017", new DateTime(2017,1,9,8,0,0), new DateTime(2017,1,9,9,0,0),"working","206",new List<string>{ "La DreamTeam" },"20/20",Color.Blue),
                new Evenement("6 janvier 2017", new DateTime(2017,1,9,9,0,0), new DateTime(2017,1,9,12,0,0),"working","206",new List<string>{ "La DreamTeam" },"20/20",Color.Aqua),
                new Evenement("7 janvier 2017", new DateTime(2017,1,15,11,0,0), new DateTime(2017,1,15,12,0,0),"working","206",new List<string>{ "La DreamTeam" },"20/20",Color.Gray),
                new Evenement("2 janvier 2017", new DateTime(2017,1,14,9,30,0), new DateTime(2017,1,14,11,0,0),"working","206",new List<string>{ "La DreamTeam" },"20/20",Color.Lime),
                new Evenement("2 janvier 2017", new DateTime(2017,1,16,11,30,0), new DateTime(2017,1,16,12,3,0,0),"working","206",new List<string>{ "La DreamTeam" },"20/20",Color.Black),
                new Evenement("8 janvier 2017", new DateTime(2017,1,21,8,0,0), new DateTime(2017,1,21,9,0,0), "working","206",new List<string>{ "La DreamTeam" },"20/20",Color.Blue),
                new Evenement("9 janvier 2017", new DateTime(2017, 1, 9, 9, 0, 0), new DateTime(2017, 1, 9, 12, 0, 0), "working", "206", new List<string> { "La DreamTeam" }, "20/20", Color.Aqua),
                new Evenement("10 janvier 2017", new DateTime(2017, 1, 10, 11, 0, 0), new DateTime(2017, 1, 10, 12, 0, 0), "working", "206", new List<string> { "La DreamTeam" }, "20/20", Color.Gray),
                new Evenement("11 janvier 2017", new DateTime(2017, 1, 11, 15, 30, 0), new DateTime(2017, 1, 11,0, 0, 0), "working", "206", new List<string> { "La DreamTeam" }, "20/20", Color.Yellow),
                new Evenement("12 janvier 2017", new DateTime(2017, 1, 12, 8, 0, 0), new DateTime(2017, 1, 12, 9, 0, 0), "working", "206", new List<string> { "La DreamTeam" }, "20/20", Color.Blue),
                new Evenement("13 janvier 2017", new DateTime(2017, 1, 13, 9, 0, 0), new DateTime(2017, 1, 13, 12, 0, 0), "working", "206", new List<string> { "La DreamTeam" }, "20/20", Color.Aqua),
                new Evenement("16 janvier 2017", new DateTime(2017, 1, 16, 11, 0, 0), new DateTime(2017, 1, 16, 12, 0, 0), "working", "206", new List<string> { "La DreamTeam" }, "20/20", Color.Gray)

            };
        public WeekPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            carousel.DayTapped += CarouselHeader_DayTapped;
            
            carousel.SetEvents(events);

        }

        private void CarouselHeader_DayTapped(object sender, EventArgs e)
        {
            DayHeader date = sender as DayHeader;
            var date_tmp = new DateTime(date.year, date.month, date.day);

            Navigation.PushAsync(new DayPage(events, date_tmp));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            carousel.OnAppearing();
        }
    }
}
