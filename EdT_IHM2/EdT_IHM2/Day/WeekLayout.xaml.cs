using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EdT_IHM2.Day
{
    public partial class WeekLayout : ContentView
    {
        const int HSTART = 0;
        const int HEND = 24;
        const int HEIGHT = 60;
        const int NBCOLUMN = 8;
        List<BoxView> bones;
        List<DayLayout> week;
        List<Label> scales;
        public WeekLayout()
        {
            InitializeComponent();

            bones = new List<BoxView>();
            week = new List<DayLayout>();
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
                AbsoluteLayout.SetLayoutFlags(bone, AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.WidthProportional);
                Days.Children.Add(bone);

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
                Days.Children.Add(label);
            }




            //for (int i = 0; i < NBCOLUMN - 1; i++)
            //{
            //    DayLayout d = new DayLayout();
            //    week.Add(d);
            //}
            //DrawScales();
            //DrawBones();
            
        }

        private void DrawScales()
        {
            foreach (var scale in scales)
            {
                Debug.WriteLine(scale);
                Debug.WriteLine(scale.HeightRequest);
                Debug.WriteLine(AbsoluteLayout.GetLayoutBounds(scale).Height);
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
    }
}
