using System;
namespace ServiceTrackerApp
{
    public class Goals
    {
        public float daily { get; set; }
        public float dailyactual { get; set; }
        public float jan { get; set; }
        public float feb { get; set; }
        public float mar { get; set; }
        public float apr { get; set; }
        public float may { get; set; }
        public float jun { get; set; }
        public float jul { get; set; }
        public float aug { get; set; }
        public float sep { get; set; }
        public float oct { get; set; }
        public float nov { get; set; }
        public float dec { get; set; }
        public float janActual { get; set; }
        public float febActual { get; set; }
        public float marActual { get; set; }
        public float aprActual { get; set; }
        public float mayActual { get; set; }
        public float junActual { get; set; }
        public float julActual { get; set; }
        public float augActual { get; set; }
        public float sepActual { get; set; }
        public float octActual { get; set; }
        public float novActual { get; set; }
        public float decActual { get; set; }
        public float ytd { get; set; }
        public float ytdactual { get; set; }
        public string tid { get; set; }

        public Goals()
        {
            this.daily = 0;
            this.dailyactual = 0;
            this.ytd = 0;
            this.ytdactual = 0;
            this.tid = "";
                
        }
    }
}
