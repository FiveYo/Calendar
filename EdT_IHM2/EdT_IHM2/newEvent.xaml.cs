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
        public Evenement evt;
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

        public newEvent(Evenement evenement)
        {
            evt = evenement;
            InitializeComponent();
            objet.Text = evt.Description;
            lieu.Text = evt.Lieu;
            alldaySwitchIsOn = false;
            //apres merge avec milly, commenter ligne précédente et decommenter la suivante
            //alldaySwitchIsOn = evt.journeeEntiere;
            if (alldaySwitchIsOn)
            {
                journee.Date = evt.DateDebut;
            }
            else
            {
                dateDebut.Date = evt.DateDebut;
                dateFin.Date = evt.DateFin;
                heureDebut.Time = new TimeSpan(evt.DateDebut.Hour, evt.DateDebut.Minute, evt.DateDebut.Second);
                heureFin.Time = new TimeSpan(evt.DateFin.Hour, evt.DateFin.Minute, evt.DateFin.Second);
            }
            description.Text = evt.Note;

            fuseau.SelectedIndex = 13;
            rappel.SelectedIndex = 0;
            //apres merge avec milly, decommenter la ligne suivante
            //rappel.?? = evt.Rappel;
            repeat.SelectedIndex = 0;
            etat.SelectedIndex = 0;
            dateDebutStack.IsVisible = !alldaySwitchIsOn;
            dateFinStack.IsVisible = !alldaySwitchIsOn;
            journee.IsVisible = alldaySwitchIsOn;

            // decommenter les lignes suivantes pour modifier le comportement du bouton de validation
            //validerBtn.Text = "Modifier";
            //validerBtn.Clicked = "modify_onClick"; // (avec ou sans guillemets ?)

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
            bool journeeEntiere = alldaySwitchIsOn;
            string Date = "";
            string Description = objet.Text.ToString();
            string Lieu = lieu.Text.ToString();
            string Participants = "moi";
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
            // Apres merge avec Milly, normalement il a rajoute un bool "journee" ou qlq chose dans le chose qui indique si l'evenement
            // s'etale sur une journee entiere ou pas. Faut donc le rajouter dans le constructeur suivant (champs journeeEntiere dénifi
            // au début de cette fonction) :
            Evenement ev = new Evenement(Date, DateDebut, DateFin, Description, Lieu, Participants, Note);
            Debug.WriteLine(ev);
        }

        void modify_onClick(object sender, EventArgs e)
        {
            // Cette fonction modifie directement l'evenement passé en paramètre dans le constructeur
            evt.Description = objet.Text.ToString();
            evt.Lieu = lieu.Text.ToString();
            // avec la nouvelle version Participant sera une liste de string et plus un simple string
            //evt.Participant = new List<string>();
            evt.Participant = "";
            evt.Note = description.Text.ToString();

            if (alldaySwitchIsOn)
            {
                evt.Date = string.Format("{0} {1} {2}", journee.Date.DayOfWeek, journee.Date.Day, journee.Date.Month);
                int year = journee.Date.Year;
                int month = journee.Date.Month;
                int day = journee.Date.Day;
                evt.DateDebut = new DateTime(year, month, day, 0, 0, 0);
                evt.DateFin = new DateTime(year, month, day, 23, 59, 59);
            }
            else
            {
                evt.Date = string.Format("Du {0} {1} au {2} {3}", dateDebut.Date.DayOfWeek, dateDebut.Date.Month, dateFin.Date.DayOfWeek, dateFin.Date.Month);
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
                evt.DateDebut = new DateTime(yearStart, monthStart, dayStart, hourStart, minStart, secStart);
                evt.DateFin = new DateTime(yearEnd, monthEnd, dayEnd, hourEnd, minEnd, secEnd);
            }
        }
    }
}
