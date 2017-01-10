using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EdT_IHM2.School
{
    public partial class Subject : ContentView
    {
        private Color color
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
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public Subject()
        {
            InitializeComponent();
        }

        public Subject(Color color, DateTime start, DateTime end)
        {
            InitializeComponent();
            this.color = color;
            this.start = start;
            this.end = end;
        }
    }
}
