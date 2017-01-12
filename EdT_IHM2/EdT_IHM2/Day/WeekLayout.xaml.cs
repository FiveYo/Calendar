using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using EdT_IHM2.Event;

namespace EdT_IHM2.Day
{
    public partial class WeekLayout : ContentView
    {
        const int HSTART = 0;
        const int HEND = 24;
        const int HEIGHT = 60;
        const int HDEPSHOW = 7;
        const double NBCOLUMN = 8.0;
        List<BoxView> bones;
        List<Label> scales;

        public event EventHandler DayTapped;

        public WeekLayout()
        {
            InitializeComponent();

            bones = new List<BoxView>();
            scales = new List<Label>();

            for (int i = HSTART; i < HEND; i++)
            {
                var bone = new BoxView
                {
                    HeightRequest = 1,
                    Color = Color.Silver,
                };
                var position = new Rectangle(
                    0,
                    i * HEIGHT,
                    1,
                    1
                );

                AbsoluteLayout.SetLayoutBounds(bone, position);
                AbsoluteLayout.SetLayoutFlags(bone, AbsoluteLayoutFlags.WidthProportional);

                bones.Add(bone);

                var label = new Label
                {
                    Text = i.ToString() + "h",
                };
                var posL = new Rectangle(
                    1.0 / 20.0,
                    i * HEIGHT,
                    1.0 / 8.0,
                    HEIGHT
                );
                AbsoluteLayout.SetLayoutBounds(label, posL);
                AbsoluteLayout.SetLayoutFlags(label, AbsoluteLayoutFlags.WidthProportional | AbsoluteLayoutFlags.XProportional);

                scales.Add(label);
            }

            
            
        }

        private void AbsLayout_Tapped(object sender, EventArgs e)
        {
            // Pour la création à une certaine date on regarde la position et dans quel colonne on est
        }

        private void DrawScales()
        {
            foreach (var scale in scales)
            {
                Days.Children.Add(scale);
            }
        }

        private void DrawBones()
        {
            foreach (var bone in bones)
            {
                Days.Children.Add(bone);
            }
        }

        public void SetEvents(List<WeekEvent> events, DateTime firstDay)
        {
            Days.Children.Clear();
            DrawHeader(firstDay);
            DrawScales();
            DrawBones();
            foreach (var ev in events)
            {
                DrawEvent(ev);
            }
            CheckIntersectionEvent();
            foreach (var ev in events)
            {
                ev.PropertyChanged += Event_PropertyChanged;
            }
        }

        private void DrawHeader(DateTime firstDay)
        {
            var day_tmp = firstDay;
            DaysView.Children.Clear();
            DaysView.Children.Add(new Label { Text = "s" + (firstDay.DayOfYear / 7 + 1).ToString() }, 0, 0);
            for(int i = 1; i < 8; i++)
            {
                DaysView.Children.Add(
                    new DayHeader
                    {
                        year = day_tmp.Year,
                        month = day_tmp.Month,
                        day = day_tmp.Day,
                    }, i, 0
                );
               day_tmp = day_tmp.AddDays(1);
            }
            foreach (var item in DaysView.Children.Where(n => { return (n as DayHeader) != null; }))
            {
                (item as DayHeader).Tapped += (s, e) => DayTapped?.Invoke(s, e);
            }
        }

        private void DrawEvent(WeekEvent ev)
        {
            Rectangle position = new Rectangle();
            if (ev.start.DayOfWeek == DayOfWeek.Sunday)
            {
                position = new Rectangle(
                    1,
                    ev.start.Hour * HEIGHT + ev.start.Minute,
                    1.0 / NBCOLUMN,
                    (ev.end - ev.start).TotalMinutes
                );
            }
            else
            {
                position = new Rectangle(
                    ((double)ev.start.DayOfWeek - 2.0) / (NBCOLUMN - 1.0),
                    ev.start.Hour * HEIGHT + ev.start.Minute,
                    1.0 / NBCOLUMN,
                    (ev.end - ev.start).TotalMinutes
                );
            }

            //var position = new Rectangle(
            //        ((double)ev.start.DayOfWeek + 1) / (NBCOLUMN - 1.0),
            //        ev.start.Hour * HEIGHT + ev.start.Minute,
            //        1.0 / NBCOLUMN,
            //        (ev.end - ev.start).TotalMinutes
            //    );

            AbsoluteLayout.SetLayoutBounds(ev, position);
            AbsoluteLayout.SetLayoutFlags(ev, AbsoluteLayoutFlags.WidthProportional | AbsoluteLayoutFlags.XProportional);
            Days.Children.Add(ev);
        }

        private void CheckIntersectionEvent()
        {
            var events = Days.Children.Where(child =>
            {
                var ev = child as WeekEvent;
                return ev != null;
            });
            int i = 1;
            List<WeekConflict> toAdd = new List<WeekConflict>();
            foreach (var ev in events)
            {
                var position = AbsoluteLayout.GetLayoutBounds(ev);
                var flag = AbsoluteLayout.GetLayoutFlags(ev);
                var bigIntersection = new Rectangle();
                bigIntersection.Y = position.Y + position.Height;
                bigIntersection.X = position.X;
                bigIntersection.Width = position.Width;

                foreach (var ev2 in events.Skip(i))
                {
                    var position2 = AbsoluteLayout.GetLayoutBounds(ev2);
                    var intersection = position.Intersect(position2);

                    if (intersection.Y < bigIntersection.Y && intersection.Y != 0)
                    {
                        (ev as WeekEvent).Conflict();
                        (ev2 as WeekEvent).Conflict();
                        //var conflictZone = new WeekConflict(Color.Red);
                        //AbsoluteLayout.SetLayoutBounds(conflictZone, intersection);
                        //AbsoluteLayout.SetLayoutFlags(conflictZone, AbsoluteLayoutFlags.WidthProportional | AbsoluteLayoutFlags.XProportional);
                        //toAdd.Add(conflictZone);
                    }
                }
                i++;
            }
            foreach (var item in toAdd)
            {
                Days.Children.Add(item);
            }
        }

        private void Event_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            WeekEvent ev = sender as WeekEvent;
            if(ev != null)
            {
                var position = new Rectangle(
                    ((double)ev.start.DayOfWeek + 1) / (NBCOLUMN - 1),
                    ev.start.Hour * HEIGHT + ev.start.Minute,
                    1.0 / NBCOLUMN,
                    (ev.end - ev.start).TotalMinutes
                );
                AbsoluteLayout.SetLayoutBounds(ev, position);
                AbsoluteLayout.SetLayoutFlags(ev, AbsoluteLayoutFlags.WidthProportional | AbsoluteLayoutFlags.XProportional);
            }
        }

        public async void ScrollTo(double X = 0, double Y = HDEPSHOW * HEIGHT, bool animated = false)
        {
            await scroll.ScrollToAsync(X, Y, animated);
        }
    }
}
