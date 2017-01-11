﻿using System;
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
        List<string> participants = new List<string>();
        string date, description, heureDebut, heureFin, lieu, note;
        DateTime dateDebut, dateFin;
        public Evenement(string Date, DateTime DateDebut, DateTime DateFin, string Description, string Lieu, List<string>  Participants, string Note)
        {
            this.date = Date;
            this.dateDebut = DateDebut;
            this.dateFin = DateFin;
            this.description = Description;
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

        public DateTime DateDebut
        {
            get
            {
                return dateDebut;
            }
            set
            {
                if (dateDebut != value)
                {
                    dateDebut = value;
                    OnPropertyChanged("DateDebut");
                }
            }
        }

        public DateTime DateFin
        {
            get
            {
                return dateFin;
            }
            set
            {
                if (dateFin != value)
                {
                    dateFin = value;
                    OnPropertyChanged("DateFin");
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
        public List<string> Participant
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


        public string DescriptionFinale => string.Format("{0} \n De {1}h{3} à {2}h{4}", Description, DateDebut.Hour, DateFin.Hour,DateDebut.Minute,DateFin.Minute);
    }
}
