using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EdT_IHM2
{
    public partial class newEvent : ContentPage
    {
        public Boolean alldaySwitchIsOn { get; set; }
        public newEvent()
        {
            InitializeComponent();
            alldaySwitchIsOn = false;
            fuseau.SelectedIndex = 13;
            rappel.SelectedIndex = 0;
            repeat.SelectedIndex = 0;
            etat.SelectedIndex = 0;
            dateDebutStack.IsVisible = !alldaySwitchIsOn;
            dateFinStack.IsVisible = !alldaySwitchIsOn;
            journee.IsVisible = alldaySwitchIsOn;

            NavigationPage.SetHasNavigationBar(this, false);
        }
        void switcher_Toggled(object sender, ToggledEventArgs e)
        {
            alldaySwitchIsOn = !alldaySwitchIsOn;
            dateDebutStack.IsVisible = !alldaySwitchIsOn;
            dateFinStack.IsVisible = !alldaySwitchIsOn;
            journee.IsVisible = alldaySwitchIsOn;
        }

        void create_onClick(object sender, EventArgs e)
        {
            string Date = "";
            string Description = objet.Text.ToString();
            string Lieu = lieu.Text.ToString();
            List<string> Participants = new List<string> { "Groupe 1" };
            string Note = description.Text.ToString();
            DateTime DateDebut;
            DateTime DateFin;

            if (alldaySwitchIsOn)
            {
                Date = string.Format("{0} {1} {2}", journee.Date.DayOfWeek, journee.Date.Day, journee.Date.Month);
                int year = journee.Date.Year;
                int month = journee.Date.Month;
                int day = journee.Date.Day;
                DateDebut = new DateTime(year, month, day, 0, 0, 0);
                DateFin = new DateTime(year, month, day, 23, 59, 59);
            } else
            {
                Date = string.Format("Du {0} {1} au {2} {3}", dateDebut.Date.DayOfWeek, dateDebut.Date.Month, dateFin.Date.DayOfWeek, dateFin.Date.Month);
                int yearStart = dateDebut.Date.Year;
                int yearEnd = dateFin.Date.Year;
                int monthStart = dateDebut.Date.Month;
                int monthEnd = dateFin.Date.Month;
                int dayStart = dateDebut.Date.Day;
                int dayEnd = dateFin.Date.Day;
                int hourStart = heureDebut.Time.Hours;
                int hourEnd = heureFin.Time.Hours;
                int minStart = heureDebut.Time.Minutes;
                int minEnd = heureFin.Time.Minutes;
                int secStart = heureDebut.Time.Seconds;
                int secEnd = heureFin.Time.Seconds;
                DateDebut = new DateTime(yearStart, monthStart, dayStart, hourStart, minStart, secStart);
                DateFin = new DateTime(yearEnd, monthEnd, dayEnd, hourEnd, minEnd, secEnd);
            }
            Evenement ev = new Evenement(Date, DateDebut, DateFin, Description, Lieu, Participants, Note, Color.Yellow);
            Debug.WriteLine(ev);
        }
    }
}
