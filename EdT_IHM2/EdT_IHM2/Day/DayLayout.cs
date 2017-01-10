using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using EdT_IHM2.School;

using Xamarin.Forms;
using System.Diagnostics;

namespace EdT_IHM2
{
    public class DayLayout : AbsoluteLayout
    {
        const int HSTART = 0;
        const int HEND = 24;
        const int HEIGHT = 60;
        List<Subject> cours;
        List<BoxView> bones;


        public DayLayout() : base()
        {
            bones = new List<BoxView>();
            for (int i = HSTART; i < HEND; i++)
            {
                var bone = new BoxView{
                    HeightRequest = 1,
                    Color = Color.Silver,
                };
                var position = new Rectangle(
                    0,
                    i * HEIGHT,
                    Width,
                    HEIGHT
                );

                SetLayoutBounds(bone, position);
                bones.Add(bone);
            }
            DrawBones();
        }

        private void DrawBones()
        {
            foreach (var bone in bones)
            {
                Children.Add(bone);
            }
        }

        internal void SetSubjects(List<Subject> subjects)
        {
            cours = subjects;
            DisplayLessons();
        }

        private void DisplayLessons()
        {
            Children.Clear();
            DrawBones();

            foreach (var cour in cours)
            {
                Debug.WriteLine(cour.start.Hour);
                var position = new Rectangle(
                    0,
                    cour.start.Hour * 60 + cour.start.Minute,
                    Width,
                    (cour.end - cour.start).TotalMinutes
                );
                SetLayoutBounds(cour, position);
                Children.Add(cour);
            }
        }
    }
}
