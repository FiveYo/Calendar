using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EdT_IHM2
{
    public partial class CarouselWeek : ContentView
    {
        public int week
        {
            get;
            set;
        }
        public CarouselWeek()
        {
            InitializeComponent();
            week = 50;
        }
    }
}
