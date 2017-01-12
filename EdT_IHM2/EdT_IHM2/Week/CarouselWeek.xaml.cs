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
        public static int currentWeek = 1;
        static List<WeekEvent> events = new List<WeekEvent>
        {
            new WeekEvent(Color.Blue, new DateTime(2017,1,1,8,0,0), new DateTime(2017,1,1,9,0,0)),
            new WeekEvent(Color.Aqua, new DateTime(2017,1,2,9,0,0), new DateTime(2017,1,2,12,0,0)),
            new WeekEvent(Color.Gray, new DateTime(2017,1,3,11,0,0), new DateTime(2017,1,3,12,0,0)),
            new WeekEvent(Color.Yellow, new DateTime(2017,1,4,15,30,0), new DateTime(2017,1,4,17,0,0)),
            new WeekEvent(Color.Blue, new DateTime(2017,1,5,8,0,0), new DateTime(2017,1,5,9,0,0)),
            new WeekEvent(Color.Aqua, new DateTime(2017,1,6,9,0,0), new DateTime(2017,1,6,12,0,0)),
            new WeekEvent(Color.Gray, new DateTime(2017,1,7,11,0,0), new DateTime(2017,1,7,12,0,0)),
            new WeekEvent(Color.Lime, new DateTime(2017,1,2,9,30,0), new DateTime(2017,1,2,11,0,0)),
            new WeekEvent(Color.Black, new DateTime(2017,1,2,11,30,0), new DateTime(2017,1,2,12,30,0)),
        };

        public List<WeekEvent> events2 = new List<WeekEvent>
        {
            new WeekEvent(Color.Blue, new DateTime(2017,1,8,8,0,0), new DateTime(2017,1,8,9,0,0)),
            new WeekEvent(Color.Aqua, new DateTime(2017,1,9,9,0,0), new DateTime(2017,1,9,12,0,0)),
            new WeekEvent(Color.Gray, new DateTime(2017,1,10,11,0,0), new DateTime(2017,1,10,12,0,0)),
            new WeekEvent(Color.Yellow, new DateTime(2017,1,11,15,30,0), new DateTime(2017,1,11,17,0,0)),
            new WeekEvent(Color.Blue, new DateTime(2017,1,12,8,0,0), new DateTime(2017,1,12,9,0,0)),
            new WeekEvent(Color.Aqua, new DateTime(2017,1,13,9,0,0), new DateTime(2017,1,13,12,0,0)),
            new WeekEvent(Color.Gray, new DateTime(2017,1,14,11,0,0), new DateTime(2017,1,14,12,0,0)),
        };

        public List<WeekEvent> events3 = new List<WeekEvent>
        {
            new WeekEvent(Color.Gray, new DateTime(2017,1,15,8,0,0), new DateTime(2017,1,15,10,0,0)),
            new WeekEvent(Color.Aqua, new DateTime(2017,1,16,8,0,0), new DateTime(2017,1,16,12,0,0)),
            new WeekEvent(Color.Blue, new DateTime(2017,1,17,14,0,0), new DateTime(2017,1,17,16,0,0)),
            new WeekEvent(Color.Yellow, new DateTime(2017,1,18,14,30,0), new DateTime(2017,1,18,18,0,0)),
            new WeekEvent(Color.Blue, new DateTime(2017,1,19,16,0,0), new DateTime(2017,1,19,17,30,0)),
            new WeekEvent(Color.Yellow, new DateTime(2017,1,20,7,0,0), new DateTime(2017,1,20,9,0,0)),
            new WeekEvent(Color.Black, new DateTime(2017,1,21,10,0,0), new DateTime(2017,1,21,12,0,0)),
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

        public void nextWeek(object sender, EventArgs e)
        {
            if (currentWeek == 1)
            {
                currentWeek = 2;
                weekLayout.SetEvents(events2);
            } else if (currentWeek == 2)
            {
                currentWeek = 3;
                weekLayout.SetEvents(events3);
            } else if (currentWeek == 3)
            {
                currentWeek = 1;
                weekLayout.SetEvents(events);
            }
            
        }

        public void previousWeek(object sender, EventArgs e)
        {
            if (currentWeek == 1)
            {
                currentWeek = 3;
                weekLayout.SetEvents(events3);
            }
            else if (currentWeek == 2)
            {
                currentWeek = 1;
                weekLayout.SetEvents(events);
            }
            else if (currentWeek == 3)
            {
                currentWeek = 2;
                weekLayout.SetEvents(events2);
            }
        }
    }
}
