using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using EdT_IHM2.Event;
using System.Collections.ObjectModel;

namespace EdT_IHM2
{
    public partial class CarouselWeek : ContentView
    {
        public event EventHandler DayTapped;
        public static int currentWeek = 1;
        //static List<WeekEvent> events = new List<WeekEvent>
        //{
        //    new WeekEvent(Color.Blue, new DateTime(2017,1,1,8,0,0), new DateTime(2017,1,1,9,0,0)),
        //    new WeekEvent(Color.Aqua, new DateTime(2017,1,2,9,0,0), new DateTime(2017,1,2,12,0,0)),
        //    new WeekEvent(Color.Gray, new DateTime(2017,1,3,11,0,0), new DateTime(2017,1,3,12,0,0)),
        //    new WeekEvent(Color.Yellow, new DateTime(2017,1,4,15,30,0), new DateTime(2017,1,4,17,0,0)),
        //    new WeekEvent(Color.Blue, new DateTime(2017,1,5,8,0,0), new DateTime(2017,1,5,9,0,0)),
        //    new WeekEvent(Color.Aqua, new DateTime(2017,1,6,9,0,0), new DateTime(2017,1,6,12,0,0)),
        //    new WeekEvent(Color.Gray, new DateTime(2017,1,7,11,0,0), new DateTime(2017,1,7,12,0,0)),
        //    new WeekEvent(Color.Lime, new DateTime(2017,1,2,9,30,0), new DateTime(2017,1,2,11,0,0)),
        //    new WeekEvent(Color.Black, new DateTime(2017,1,2,11,30,0), new DateTime(2017,1,2,12,30,0)),
        //};

        //public List<WeekEvent> events2 = new List<WeekEvent>
        //{
        //    new WeekEvent(Color.Blue, new DateTime(2017,1,8,8,0,0), new DateTime(2017,1,8,9,0,0)),
        //    new WeekEvent(Color.Aqua, new DateTime(2017,1,9,9,0,0), new DateTime(2017,1,9,12,0,0)),
        //    new WeekEvent(Color.Gray, new DateTime(2017,1,10,11,0,0), new DateTime(2017,1,10,12,0,0)),
        //    new WeekEvent(Color.Yellow, new DateTime(2017,1,11,15,30,0), new DateTime(2017,1,11,17,0,0)),
        //    new WeekEvent(Color.Blue, new DateTime(2017,1,12,8,0,0), new DateTime(2017,1,12,9,0,0)),
        //    new WeekEvent(Color.Aqua, new DateTime(2017,1,13,9,0,0), new DateTime(2017,1,13,12,0,0)),
        //    new WeekEvent(Color.Gray, new DateTime(2017,1,14,11,0,0), new DateTime(2017,1,14,12,0,0)),
        //};

        //public List<WeekEvent> events3 = new List<WeekEvent>
        //{
        //    new WeekEvent(Color.Gray, new DateTime(2017,1,15,8,0,0), new DateTime(2017,1,15,10,0,0)),
        //    new WeekEvent(Color.Aqua, new DateTime(2017,1,16,8,0,0), new DateTime(2017,1,16,12,0,0)),
        //    new WeekEvent(Color.Blue, new DateTime(2017,1,17,14,0,0), new DateTime(2017,1,17,16,0,0)),
        //    new WeekEvent(Color.Yellow, new DateTime(2017,1,18,14,30,0), new DateTime(2017,1,18,18,0,0)),
        //    new WeekEvent(Color.Blue, new DateTime(2017,1,19,16,0,0), new DateTime(2017,1,19,17,30,0)),
        //    new WeekEvent(Color.Yellow, new DateTime(2017,1,20,7,0,0), new DateTime(2017,1,20,9,0,0)),
        //    new WeekEvent(Color.Black, new DateTime(2017,1,21,10,0,0), new DateTime(2017,1,21,12,0,0)),
        //};

        public Dictionary<int, List<WeekEvent>> events;

        public int week
        {
            get;
            set;
        }
        public CarouselWeek()
        {
            InitializeComponent();
            week = 50;
            //weekLayout.SetEvents(events, events.First().start);
            weekLayout.DayTapped += (s, e) => DayTapped?.Invoke(s, e);
            //day.subjects = subjects.Where(s => s.start.Day == day.day).ToList();
            events = new Dictionary<int, List<WeekEvent>>();
        }

        public void SetEvents(ObservableCollection<Evenement> evs)
        {
            var groupir = evs.GroupBy(n => { return (int)n.DateDebut.DayOfYear / 7; });
            // groupir contient plusieurs semaines
            foreach (var item in groupir)
            {
                Debug.WriteLine(item.Key);
                // ordonnee contient les evenements associé aux jour de la semaine ordonnée sur le jour
                List<Evenement> ordonne = item.OrderBy(n => { return ((int)n.DateDebut.DayOfWeek + 6) % 7; }).ToList();
                List<WeekEvent> weeks = new List<WeekEvent>();
                foreach (var ev in ordonne)
                {
                    Debug.WriteLine(ev.DateDebut.DayOfWeek);
                    weeks.Add(new WeekEvent(ev));
                }
                events.Add(item.Key, weeks);
            }
            currentWeek = 0;
            nextWeek(null, null);

        }

        public void OnAppearing()
        {
            weekLayout.ScrollTo(animated: true);
        }

        public void nextWeek(object sender, EventArgs e)
        {
            currentWeek = (currentWeek + 1) % 3;
            List<WeekEvent> currentEvents = null;
            if (events.TryGetValue(currentWeek, out currentEvents))
            {
                foreach (var item in currentEvents)
                {
                    Debug.WriteLine(item.start.Hour);
                }

                var lundi = currentEvents.First().start.AddDays(-(int)currentEvents.First().start.DayOfWeek + 1);
                weekLayout.SetEvents(currentEvents, lundi);
            }
            else
            {
                Debug.WriteLine("on est la");
                //Probleme ici
                weekLayout.SetEvents(new List<WeekEvent>(), new DateTime());
            }

        }

        public void previousWeek(object sender, EventArgs e)
        {
            currentWeek = (currentWeek - 1) % 3;
            List<WeekEvent> currentEvents = null;
            if (events.TryGetValue(currentWeek, out currentEvents))
            {
                weekLayout.SetEvents(currentEvents, currentEvents.First().start);
            }
            else
            {
                //Probleme ici
                weekLayout.SetEvents(new List<WeekEvent>(), new DateTime());
            }
        }
    }
}
