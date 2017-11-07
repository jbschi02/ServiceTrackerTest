using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Json;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using Xamarin.Forms;

namespace ServiceTrackerApp
{
    public partial class DTDView : ContentPage
    {
        public string tid;
        public JsonValue jsondoc;
        public Goals goals;

        public DTDView(string tid)
        {
            this.tid = tid;
            //this.goals = new Goals();
            InitializeComponent();

            //JsonValue jsondoc = GetMonthlyGoals();
        }

        protected override async void OnAppearing()
        {
            await Task.Run(async () => await GetMonthlyGoals());
            this.goals = new Goals();
            this.goals = ParseJSONToGoals(this.jsondoc, this.goals);

            float RemainingGoal;
            double remaining = this.goals.GetDailyGoal() - this.goals.GetDailyActual();
            string remainingString = string.Format("{0:.00}", remaining);

            GoalText.Text = "$" + remainingString;

            string s = (goals.GetDailyActual() / goals.GetDailyGoal()).ToString();

            RemainingGoal = (float)(goals.GetDailyActual() / goals.GetDailyGoal());

            ActualLabel.Text = "$" + this.goals.GetDailyActual().ToString();
            GoalLabel.Text = "$" + this.goals.GetDailyGoal().ToString();

            ProgressBar.Progress = RemainingGoal;
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Task.Run(async () => await GetMonthlyGoals());
            this.goals = new Goals();
            this.goals = ParseJSONToGoals(this.jsondoc, this.goals);

            float RemainingGoal;

            GoalText.Text = "$" + (this.goals.GetDailyGoal() - this.goals.GetDailyActual()).ToString();
            RemainingGoal = (float)(goals.GetDailyActual() / goals.GetDailyGoal());

            ActualLabel.Text = "$" + this.goals.GetDailyActual().ToString();
            GoalLabel.Text = "$" + this.goals.GetDailyGoal().ToString();

            ProgressBar.Progress = RemainingGoal;
        }

        async Task GetMonthlyGoals()
        {
            string url = "http://capstone1.cecsresearch.org:8080/ServiceTrackerFinal/webresources/entityclasses.goals/";
            url += this.tid;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";
            JsonValue jsonDoc = null;

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    try
                    {
                        jsonDoc = await Task.Run(() => JsonObject.Load(stream));
                    }
                    catch (System.ArgumentException)
                    {
                        await DisplayAlert("Error", "Awaiting Manager to Update Your Goals", "OK");

                    }
                }
            }

            this.jsondoc = jsonDoc;
        }

        private Goals ParseJSONToGoals(JsonValue json, Goals goals)
        {
            JsonObject jsonObject = json as JsonObject;
            string currentMonthDBActual = "";
            string currentMonthDBGoal = "";
            string sMonth = DateTime.Now.ToString("MM");
            int dayAmount = 31;
            switch (sMonth)
            {
                case "01":
                    currentMonthDBActual = "janActual";
                    currentMonthDBGoal = "jan";
                    dayAmount = 31;
                    break;
                case "02":
                    currentMonthDBActual = "febActual";
                    currentMonthDBGoal = "feb";
                    dayAmount = 28;
                    break;
                case "03":
                    currentMonthDBActual = "marActual";
                    currentMonthDBGoal = "mar";
                    dayAmount = 31;
                    break;
                case "04":
                    currentMonthDBActual = "aprActual";
                    currentMonthDBGoal = "apr";
                    dayAmount = 30;
                    break;
                case "05":
                    currentMonthDBActual = "mayActual";
                    currentMonthDBGoal = "may";
                    dayAmount = 31;
                    break;
                case "06":
                    currentMonthDBActual = "junActual";
                    currentMonthDBGoal = "jun";
                    dayAmount = 30;
                    break;
                case "07":
                    currentMonthDBActual = "julActual";
                    currentMonthDBGoal = "jul";
                    dayAmount = 31;
                    break;
                case "08":
                    currentMonthDBActual = "augActual";
                    currentMonthDBGoal = "aug";
                    dayAmount = 31;
                    break;
                case "09":
                    currentMonthDBActual = "sepActual";
                    currentMonthDBGoal = "sep";
                    dayAmount = 30;
                    break;
                case "10":
                    currentMonthDBActual = "octActual";
                    currentMonthDBGoal = "oct";
                    dayAmount = 31;
                    break;
                case "11":
                    currentMonthDBActual = "novActual";
                    currentMonthDBGoal = "nov";
                    dayAmount = 30;
                    break;
                case "12":
                    currentMonthDBActual = "decActual";
                    currentMonthDBGoal = "dec";
                    dayAmount = 31;
                    break;
            }

            goals.SetMonthlyGoal((float)jsonObject[currentMonthDBGoal]);
            goals.SetDailyActual((float)jsonObject["dailyactual"]);

            goals.SetDailyGoals(goals.GetMonthlyGoal()/dayAmount);


            return goals;
        }
    }
}
