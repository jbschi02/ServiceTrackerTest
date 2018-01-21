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
            double remaining = this.goals.daily - this.goals.dailyactual;
            string remainingString = string.Format("{0:.00}", remaining);
            if (remaining < 0)
            {
                remainingString = "0";
            }

            GoalText.Text = "$" + remainingString;

            string s = (goals.dailyactual / goals.daily).ToString();

            RemainingGoal = (float)(goals.dailyactual / goals.daily);

            ActualLabel.Text = "$" + this.goals.dailyactual.ToString();
            GoalLabel.Text = "$" + this.goals.daily.ToString();

            ProgressBar.Progress = RemainingGoal;
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
                await Task.Run(async () => await GetMonthlyGoals());
            this.goals = new Goals();
            this.goals = ParseJSONToGoals(this.jsondoc, this.goals);

            float RemainingGoal;
            double remaining = this.goals.daily - this.goals.dailyactual;
            string remainingString = string.Format("{0:.00}", remaining);

            GoalText.Text = "$" + remainingString;

            string s = (goals.dailyactual / goals.daily).ToString();

            RemainingGoal = (float)(goals.dailyactual / goals.daily);

            ActualLabel.Text = "$" + this.goals.dailyactual.ToString();
            GoalLabel.Text = "$" + this.goals.daily.ToString();

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
            int dayAmount = 20;
            switch (sMonth)
            {
                case "01":
                    currentMonthDBActual = "janActual";
                    currentMonthDBGoal = "jan";
                    goals.jan = ((float)jsonObject[currentMonthDBGoal]);
                    goals.janActual= ((float)jsonObject[currentMonthDBActual]);

                    goals.daily= (goals.jan / dayAmount);
                    break;
                case "02":
                    currentMonthDBActual = "febActual";
                    currentMonthDBGoal = "feb";
                            goals.feb = ((float)jsonObject[currentMonthDBGoal]);
                            goals.febActual = ((float)jsonObject[currentMonthDBActual]);

                            goals.daily = (goals.feb / dayAmount);

                    break;
                case "03":
                    currentMonthDBActual = "marActual";
                    currentMonthDBGoal = "mar";

                            goals.mar = ((float)jsonObject[currentMonthDBGoal]);
                            goals.marActual = ((float)jsonObject[currentMonthDBActual]);

                            goals.daily = (goals.mar / dayAmount);
                    break;
                case "04":
                    currentMonthDBActual = "aprActual";
                    currentMonthDBGoal = "apr";
                            goals.apr = ((float)jsonObject[currentMonthDBGoal]);
                            goals.aprActual = ((float)jsonObject[currentMonthDBActual]);

                            goals.daily = (goals.apr / dayAmount);
                    break;
                case "05":
                    currentMonthDBActual = "mayActual";
                    currentMonthDBGoal = "may";

                    goals.may = ((float)jsonObject[currentMonthDBGoal]);
                    goals.mayActual = ((float)jsonObject[currentMonthDBActual]);

                    goals.daily = (goals.may / dayAmount);
                    break;
                case "06":
                    currentMonthDBActual = "junActual";
                    currentMonthDBGoal = "jun";

                            goals.jun = ((float)jsonObject[currentMonthDBGoal]);
                            goals.junActual = ((float)jsonObject[currentMonthDBActual]);

                            goals.daily = (goals.jun / dayAmount);
                    break;
                case "07":
                    currentMonthDBActual = "julActual";
                    currentMonthDBGoal = "jul";

                            goals.jul = ((float)jsonObject[currentMonthDBGoal]);
                            goals.julActual = ((float)jsonObject[currentMonthDBActual]);

                            goals.daily = (goals.jul / dayAmount);
                    break;
                case "08":
                    currentMonthDBActual = "augActual";
                    currentMonthDBGoal = "aug";
                            goals.aug = ((float)jsonObject[currentMonthDBGoal]);
                            goals.augActual = ((float)jsonObject[currentMonthDBActual]);

                            goals.daily = (goals.aug / dayAmount);
                    break;
                case "09":
                    currentMonthDBActual = "sepActual";
                    currentMonthDBGoal = "sep";

                            goals.sep = ((float)jsonObject[currentMonthDBGoal]);
                            goals.sepActual = ((float)jsonObject[currentMonthDBActual]);

                            goals.daily = (goals.sep / dayAmount);
                    break;
                case "10":
                    currentMonthDBActual = "octActual";
                    currentMonthDBGoal = "oct";

                            goals.oct = ((float)jsonObject[currentMonthDBGoal]);
                            goals.octActual = ((float)jsonObject[currentMonthDBActual]);

                            goals.daily = (goals.oct / dayAmount);
                    break;
                case "11":
                    currentMonthDBActual = "novActual";
                    currentMonthDBGoal = "nov";

                            goals.nov = ((float)jsonObject[currentMonthDBGoal]);
                            goals.novActual = ((float)jsonObject[currentMonthDBActual]);

                            goals.daily = (goals.nov / dayAmount);
                    break;
                case "12":
                    currentMonthDBActual = "decActual";
                    currentMonthDBGoal = "dec";

                            goals.dec = ((float)jsonObject[currentMonthDBGoal]);
                            goals.decActual = ((float)jsonObject[currentMonthDBActual]);

                            goals.daily = (goals.dec / dayAmount);
                    break;
            }

            
                    goals.dailyactual = ((float)jsonObject["dailyactual"]);

            return goals;
        }
    }
}
