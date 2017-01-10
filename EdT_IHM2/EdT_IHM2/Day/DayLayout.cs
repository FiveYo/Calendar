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

        public static readonly BindableProperty SubjectsProperty =
            BindableProperty.Create("Subjects", typeof(List<Subject>), typeof(DayView), null, propertyChanged: SubjectChanged);
        private static void SubjectChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayLayout day = bindable as DayLayout;
            day.LessonChanged?.Invoke(null, null);
        }


        const int HSTART = 0;
        const int HEND = 24;
        const int HEIGHT = 60;
        List<Subject> cours;
        List<BoxView> bones;

        public event EventHandler LessonChanged;


        public DayLayout() : base()
        {
        }
        
        internal void SetSubjects(List<Subject> subjects)
        {
            cours = subjects;
            DisplayLessons();
        }

        private void DisplayLessons()
        {
            Children.Clear();

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
