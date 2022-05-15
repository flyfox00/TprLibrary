using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TprLibrary
{
    public class TprRec : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private decimal? temperature = null;
        public decimal Temperature
        {
            get => (decimal)temperature;
            set
            {
                if (value != temperature)
                {
                    temperature = value;
                    OnPropertyChanged(nameof(Temperature));
                }
            }
        }

        private int pulse = 0;
        public int Pulse
        {
            get => pulse;
            set
            {
                if (value != pulse)
                {
                    pulse = value;
                    OnPropertyChanged(nameof(Pulse));
                }
            }
        }

        private int respiratory = 0;
        public int Respiratory
        {
            get => respiratory;
            set
            {
                if (value != respiratory)
                {
                    respiratory = value;
                    OnPropertyChanged(nameof(Respiratory));
                }
            }
        }

        private int sbp = 0;
        public int Sbp
        {
            get => sbp;
            set
            {
                if (value != sbp)
                {
                    sbp = value;
                    OnPropertyChanged(nameof(Sbp));
                }
            }
        }

        private int dbp = 0;
        public int Dbp
        {
            get => dbp;
            set
            {
                if (value != dbp)
                {
                    dbp = value;
                    OnPropertyChanged(nameof(Dbp));
                }
            }
        }

        public event EventHandler TprBuild;
        public void OnTprBuild(TprEventArgs e)
        {
            TprBuild?.Invoke(this, e);
        }   

        public void Build()
        {
            TprEventArgs tprEventArgs = new TprEventArgs(this.Temperature, this.Pulse,
                                                         this.Respiratory, this.Sbp, this.Dbp);
            OnTprBuild(tprEventArgs);
        }
    }
    public class TprEventArgs : EventArgs
    {
        public decimal Temperature { get; private set; }
        public int Pulse { get; private set; }
        public int Respiratory { get; private set; }
        public int Sbp { get; private set; }
        public int Dbp { get; private set; }
        public TprEventArgs(decimal temperature, int pulse, int respiratory, int sbp, int dbp)
        {
            this.Temperature = temperature;
            this.Pulse = pulse;
            this.Respiratory = respiratory;
            this.Sbp = sbp;
            this.Dbp = dbp;
        }
    }

}
