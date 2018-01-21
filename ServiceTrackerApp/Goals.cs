using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;
using System.Json;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

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
        public float comEquipment;
        public float comDemand;
        public float comServNew;
        public float comServRenew;
        public float comTotalDollars;
        public float comTotalDollarsMonth;

        public Goals()
        {
            this.daily = 0;
            this.dailyactual = 0;
            this.ytd = 0;
            this.ytdactual = 0;
            this.tid = "";
                
        }

        public Goals ParseJSON(Goals goals, JsonObject jsonObject)
        {
            goals.daily = (float)jsonObject["daily"];
            goals.dailyactual = (float)jsonObject["dailyactual"];
            goals.jan = (float)jsonObject["jan"];
            goals.feb = (float)jsonObject["feb"];
            goals.mar = (float)jsonObject["mar"];
            goals.apr = (float)jsonObject["apr"];
            goals.may = (float)jsonObject["may"];
            goals.jun = (float)jsonObject["jun"];
            goals.jul = (float)jsonObject["jul"];
            goals.aug = (float)jsonObject["aug"];
            goals.sep = (float)jsonObject["sep"];
            goals.oct = (float)jsonObject["oct"];
            goals.nov = (float)jsonObject["nov"];
            goals.dec = (float)jsonObject["dec"];
            goals.janActual = (float)jsonObject["janActual"];
            goals.febActual = (float)jsonObject["febActual"];
            goals.marActual = (float)jsonObject["marActual"];
            goals.aprActual = (float)jsonObject["aprActual"];
            goals.mayActual = (float)jsonObject["mayActual"];
            goals.junActual = (float)jsonObject["junActual"];
            goals.julActual = (float)jsonObject["julActual"];
            goals.augActual = (float)jsonObject["augActual"];
            goals.sepActual = (float)jsonObject["sepActual"];
            goals.octActual = (float)jsonObject["octActual"];
            goals.novActual = (float)jsonObject["novActual"];
            goals.decActual = (float)jsonObject["decActual"];
            goals.ytd = (float)jsonObject["ytd"];
            goals.ytdactual = (float)jsonObject["ytdactual"];
            goals.tid = (string)jsonObject["tid"];
            goals.comDemand = (float)jsonObject["comDemand"];
            goals.comServNew = (float)jsonObject["comServNew"];
            goals.comEquipment = (float)jsonObject["comEquipment"];
            goals.comServRenew = (float)jsonObject["comServRenew"];
            goals.comTotalDollars = (float)jsonObject["comTotalDollars"];
            goals.comTotalDollarsMonth = (float)jsonObject["comTotalDollarsMonth"];

            return goals;
        }

        public void addToMonthlyActual(float revenue)
        {
            string sMonth = DateTime.Now.ToString("MM");
            switch (sMonth)
            {
                case "01":
                    this.janActual += revenue;
                    break;
                case "02":
                    this.febActual += revenue;
                    break;
                case "03":
                    this.marActual += revenue;
                    break;
                case "04":
                    this.aprActual += revenue;
                    break;
                case "05":
                    this.mayActual += revenue;
                    break;
                case "06":
                    this.junActual += revenue;
                    break;
                case "07":
                    this.julActual += revenue;
                    break;
                case "08":
                    this.augActual += revenue;
                    break;
                case "09":
                    this.sepActual += revenue;
                    break;
                case "10":
                    this.octActual += revenue;
                    break;
                case "11":
                    this.novActual += revenue;
                    break;
                case "12":
                    this.decActual += revenue;
                    break;
            }
        }
    }
}
