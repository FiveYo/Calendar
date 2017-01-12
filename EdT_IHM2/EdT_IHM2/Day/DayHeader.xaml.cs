using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EdT_IHM2.Day
{
    public partial class DayHeader : ContentView
    {

        public static readonly BindableProperty YearProperty =
            BindableProperty.Create("Year", typeof(int), typeof(DayHeader), 1, propertyChanged: YearChanged);

        private static void YearChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayHeader day = bindable as DayHeader;
            day.DateChanged?.Invoke(null, null);
        }

        public static readonly BindableProperty MonthProperty =
            BindableProperty.Create("Month", typeof(int), typeof(DayHeader), 1, propertyChanged: MonthChanged);

        private static void MonthChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayHeader day = bindable as DayHeader;
            day.DateChanged?.Invoke(null, null);
        }

        public static readonly BindableProperty DayProperty =
            BindableProperty.Create("Day", typeof(int), typeof(DayHeader), 1, propertyChanged: DayChanged);

        private static void DayChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayHeader day = bindable as DayHeader;
            day.DateChanged?.Invoke(null, null);
        }

        public event EventHandler DateChanged;

        public int year
        {
            get { return (int)GetValue(YearProperty); }
            set { SetValue(YearProperty, value); }
        }
        public int month
        {
            get { return (int)GetValue(MonthProperty); }
            set { SetValue(MonthProperty, value); }
        }
        public int day
        {
            get { return (int)GetValue(DayProperty); }
            set { SetValue(DayProperty, value); }
        }

        //public List<Subject> subjects
        //{
        //    //get { return (List<Subject>)GetValue(SubjectsProperty); }
        //    //set { SetValue(SubjectsProperty, value); }
        //}

        public event EventHandler Tapped;

        public DayHeader()
        {
            InitializeComponent();
            DateChanged += DayView_DateChanged;

            var tpg = new TapGestureRecognizer();
            tpg.Tapped += (s,e) => Tapped?.Invoke(this,e);

            GestureRecognizers.Add(tpg);
        }

        private void DayView_DateChanged(object sender, EventArgs e)
        {
            dayOfWeek.Text = getDateName();
            dayNumber.Text = day.ToString();
        }

        private string getDateName()
        {
            DateTime d = new DateTime(year, month, day);
            string dayOfWeek = d.DayOfWeek.ToString().Substring(0, 3);
            return dayOfWeek;
        }
    }
}
