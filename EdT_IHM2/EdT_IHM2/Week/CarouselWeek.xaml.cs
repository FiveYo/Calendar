using EdT_IHM2.School;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EdT_IHM2
{
    public partial class CarouselWeek : ContentView
    {
        static List<Subject> subjects = new List<Subject>
        {
            new Subject(Color.Blue, new DateTime(2017,1,1,8,0,0), new DateTime(2017,1,1,9,0,0)),
            new Subject(Color.Aqua, new DateTime(2017,1,2,9,0,0), new DateTime(2017,1,2,12,0,0)),
            new Subject(Color.Gray, new DateTime(2017,1,2,11,0,0), new DateTime(2017,1,2,12,0,0)),
            new Subject(Color.Yellow, new DateTime(2017,1,4,15,30,0), new DateTime(2017,1,4,16,0,0))
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
            //foreach (var day_tmp in DaysView.Children)
            //{
            //    DayView day = (DayView)day_tmp;
            //    day.subjects = subjects.Where(s => s.start.Day == day.day).ToList();
            //}
        }
    }
}
