using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EdT_IHM2.Event
{
    public partial class WeekConflict : ContentView
    {
        public Color color
        {
            get
            {
                return box.Color;
            }
            set
            {
                box.Color = value;
            }
        }

        public WeekConflict()
        {
            InitializeComponent();
            color = Color.Blue;
        }

        public WeekConflict(Color color)
        {
            InitializeComponent();
            this.color = color;
        }
    }
}
