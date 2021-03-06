﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EdT_IHM2.Event
{
    public partial class WeekEvent : ContentView
    {
        const double alphaMult = 0.6;
        private Color _colorTransparent;

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
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public WeekEvent()
        {
            InitializeComponent();
        }

        public WeekEvent(Color color, DateTime start, DateTime end)
        {
            InitializeComponent();
            this.color = color;
            this.start = start;
            this.end = end;
            _colorTransparent = color.MultiplyAlpha(alphaMult);
        }

        public WeekEvent(Evenement ev)
        {
            InitializeComponent();
            BindingContext = ev;
            this.color = ev.Color;
            this.start = ev.DateDebut;
            this.end = ev.DateFin;
            _colorTransparent = color.MultiplyAlpha(alphaMult);
        }

        public void Conflict()
        {
            color = _colorTransparent;
        }
    }
    public class WeekEventSelectedEventArgs : EventArgs
    {
        public readonly WeekEvent selected;

        public WeekEventSelectedEventArgs(WeekEvent selected)
        {
            this.selected = selected;
        }

    }
}
