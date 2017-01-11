using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using EdT_IHM2.Event;

namespace EdT_IHM2
{
    public partial class CarouselWeek : ContentView
    {
        static List<WeekEvent> events = new List<WeekEvent>
        {
            new WeekEvent(Color.Blue, new DateTime(2017,1,1,8,0,0), new DateTime(2017,1,1,9,0,0)),
            new WeekEvent(Color.Aqua, new DateTime(2017,1,2,9,0,0), new DateTime(2017,1,2,12,0,0)),
            new WeekEvent(Color.Gray, new DateTime(2017,1,3,11,0,0), new DateTime(2017,1,3,12,0,0)),
            new WeekEvent(Color.Yellow, new DateTime(2017,1,4,15,30,0), new DateTime(2017,1,4,17,0,0)),
            new WeekEvent(Color.Blue, new DateTime(2017,1,5,8,0,0), new DateTime(2017,1,5,9,0,0)),
            new WeekEvent(Color.Aqua, new DateTime(2017,1,6,9,0,0), new DateTime(2017,1,6,12,0,0)),
            new WeekEvent(Color.Gray, new DateTime(2017,1,7,11,0,0), new DateTime(2017,1,7,12,0,0)),
            new WeekEvent(Color.Yellow, new DateTime(2017,1,8,15,30,0), new DateTime(2017,1,8,17,0,0)),
            new WeekEvent(Color.Lime, new DateTime(2017,1,2,9,30,0), new DateTime(2017,1,2,11,0,0)),
            new WeekEvent(Color.Black, new DateTime(2017,1,2,11,30,0), new DateTime(2017,1,2,12,30,0)),
        };
        public int week
        {
            get;
            set;
        }
        public CarouselWeek()
        {
            InitializeComponent();
            week = 50;
            weekLayout.SetEvents(events);
                //day.subjects = subjects.Where(s => s.start.Day == day.day).ToList();
        }

        public void OnAppearing()
        {
            weekLayout.ScrollTo(animated: true);
        }
    }
}
