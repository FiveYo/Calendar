using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EdT_IHM2
{
    public partial class Day : ContentView
    {

        public static readonly BindableProperty WeekProperty =
  BindableProperty.Create("Week", typeof(Week), typeof(int), null);
        public int Number
        {
            get;
            set;
        }
        public int Week
        {
            get;
            set;
        }

        public string day
        {
            get
            {
                DateTime d = new DateTime(2017, Week, Number);
                Debug.WriteLine(Number);
                Debug.WriteLine(Week);
                return d.DayOfWeek.ToString();
            }
        }
        public Day()
        {
            InitializeComponent();
            Number = 12;
        }
    }
}
