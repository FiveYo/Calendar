using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdT_IHM2
{
    public class Evenement : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string date, description, heureDebut, heureFin, lieu, participants, note;
        public Evenement(string Date , string Description, string HeureDebut, string HeureFin, string Lieu, string Participants, string Note)
        {
            this.date = Date;
            this.description = Description;
            this.heureFin = HeureFin;
            this.heureDebut = HeureDebut;
            this.lieu = Lieu;
            this.participants = Participants;
            this.note = Note;
        }
        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                if (date != value)
                {
                    date = value;
                    OnPropertyChanged("Date");
                }
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        public string HeureFin
        {
            get
            {
                return heureFin;
            }
            set
            {
                if (heureFin != value)
                {
                    heureFin = value;
                    OnPropertyChanged("HeureFin");
                }
            }
        }
        public string HeureDebut
        {
            get
            {
                return heureDebut;
            }
            set
            {
                if (heureDebut != value)
                {
                    heureDebut = value;
                    OnPropertyChanged("HeureDebut");
                }
            }
        }
        public string Lieu
        {
            get
            {
                return lieu;
            }
            set
            {
                if (lieu != value)
                {
                    lieu = value;
                    OnPropertyChanged("Lieu");
                }
            }
        }
        public string Participant
        {
            get
            {
                return participants;
            }
            set
            {
                if (participants != value)
                {
                    participants = value;
                    OnPropertyChanged("Participant");
                }
            }
        }
        public string Note
        {
            get
            {
                return note;
            }
            set
            {
                if (note != value)
                {
                    note = value;
                    OnPropertyChanged("Note");
                }
            }
        }
        protected virtual void OnPropertyChanged (string PropertyName)
        {
            var changed = PropertyName;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }


        public string DescriptionFinale => string.Format("{0} \n {1} --> {2}", Description, HeureDebut, HeureFin);
    }
}
