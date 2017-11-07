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
    public partial class MTDView : ContentPage
    {
        public string tid;
        public JsonValue jsondoc;
        public Goals goals;
        public float monthlyGoal;
        public float monthlyGoalActual;

        public MTDView(string tid)
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

            GoalText.Text = "$"+(this.monthlyGoal - this.monthlyGoalActual).ToString();
            RemainingGoal = (this.monthlyGoalActual / this.monthlyGoal);

            ActualLabel.Text = "$" + this.monthlyGoalActual.ToString();
            GoalLabel.Text = "$" + this.monthlyGoal.ToString();

            ProgressBar.Progress = RemainingGoal;
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Task.Run(async () => await GetMonthlyGoals());
            this.goals = new Goals();
            this.goals = ParseJSONToGoals(this.jsondoc, this.goals);

            float RemainingGoal;

            GoalText.Text = "$" + (this.monthlyGoal - this.monthlyGoalActual).ToString();
            RemainingGoal = (this.monthlyGoalActual / this.monthlyGoal);

            ActualLabel.Text = "$" + this.monthlyGoalActual.ToString();
            GoalLabel.Text = "$" + this.monthlyGoal.ToString();

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
            switch(sMonth)
            {
                case "01":
                    currentMonthDBActual = "janActual";
                    currentMonthDBGoal = "jan";
                    goals.jan = ((float)jsonObject[currentMonthDBGoal]);
                    goals.janActual = ((float)jsonObject[currentMonthDBActual]);
                    this.monthlyGoal = goals.jan;
                    this.monthlyGoalActual = goals.janActual;
                    break;
                case "02":
                    currentMonthDBActual = "febActual";
                    currentMonthDBGoal = "feb";
                    goals.feb = ((float)jsonObject[currentMonthDBGoal]);
                    goals.febActual = ((float)jsonObject[currentMonthDBActual]);
                    this.monthlyGoal = goals.feb;
                    this.monthlyGoalActual = goals.febActual;
                    break;
                case "03":
                    currentMonthDBActual = "marActual";
                    currentMonthDBGoal = "mar";
                    goals.mar = ((float)jsonObject[currentMonthDBGoal]);
                    goals.marActual = ((float)jsonObject[currentMonthDBActual]);
                    this.monthlyGoal = goals.mar;
                    this.monthlyGoalActual = goals.marActual;
                    break;
                case "04":
                    currentMonthDBActual = "aprActual";
                    currentMonthDBGoal = "apr";
                    goals.apr = ((float)jsonObject[currentMonthDBGoal]);
                    goals.aprActual = ((float)jsonObject[currentMonthDBActual]);
                    this.monthlyGoal = goals.apr;
                    this.monthlyGoalActual = goals.aprActual;
                    break;
                case "05":
                    currentMonthDBActual = "mayActual";
                    currentMonthDBGoal = "may";
                    goals.may = ((float)jsonObject[currentMonthDBGoal]);
                    goals.mayActual = ((float)jsonObject[currentMonthDBActual]);
                    this.monthlyGoal = goals.may;
                    this.monthlyGoalActual = goals.mayActual;
                    break;
                case "06":
                    currentMonthDBActual = "junActual";
                    currentMonthDBGoal = "jun";
                    goals.jun = ((float)jsonObject[currentMonthDBGoal]);
                    goals.junActual = ((float)jsonObject[currentMonthDBActual]);
                    this.monthlyGoal = goals.jun;
                    this.monthlyGoalActual = goals.junActual;
                    break;
                case "07":
                    currentMonthDBActual = "julActual";
                    currentMonthDBGoal = "jul";
                    goals.jul= ((float)jsonObject[currentMonthDBGoal]);
                    goals.julActual = ((float)jsonObject[currentMonthDBActual]);
                    this.monthlyGoal = goals.jul;
                    this.monthlyGoalActual = goals.julActual;
                    break;
                case "08":
                    currentMonthDBActual = "augActual";
                    currentMonthDBGoal = "aug";
                    goals.aug = ((float)jsonObject[currentMonthDBGoal]);
                    goals.augActual = ((float)jsonObject[currentMonthDBActual]);
                    this.monthlyGoal = goals.aug;
                    this.monthlyGoalActual = goals.augActual;
                    break;
                case "09":
                    currentMonthDBActual = "sepActual";
                    currentMonthDBGoal = "sep";
                    goals.sep = ((float)jsonObject[currentMonthDBGoal]);
                    goals.sepActual = ((float)jsonObject[currentMonthDBActual]);
                    this.monthlyGoal = goals.sep;
                    this.monthlyGoalActual = goals.sepActual;
                    break;
                case "10":
                    currentMonthDBActual = "octActual";
                    currentMonthDBGoal = "oct";
                    goals.oct = ((float)jsonObject[currentMonthDBGoal]);
                    goals.octActual = ((float)jsonObject[currentMonthDBActual]);
                    this.monthlyGoal = goals.oct;
                    this.monthlyGoalActual = goals.octActual;
                    break;
                case "11":
                    currentMonthDBActual = "novActual";
                    currentMonthDBGoal = "nov";
                    goals.nov = ((float)jsonObject[currentMonthDBGoal]);
                    goals.novActual = ((float)jsonObject[currentMonthDBActual]);
                    this.monthlyGoal = goals.nov;
                    this.monthlyGoalActual = goals.novActual;
                    break;
                case "12":
                    currentMonthDBActual = "decActual";
                    currentMonthDBGoal = "dec";
                    goals.dec = ((float)jsonObject[currentMonthDBGoal]);
                    goals.decActual = ((float)jsonObject[currentMonthDBActual]);
                    this.monthlyGoal = goals.dec;
                    this.monthlyGoalActual = goals.decActual;
                    break;
            }



            return goals;
        }
    }
}