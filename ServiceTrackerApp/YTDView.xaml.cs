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
    public partial class YTDView : ContentPage
    {
        public string tid;
        public JsonValue jsondoc;
        public Goals goals;

        public YTDView(string tid)
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

            GoalText.Text = "$" + (this.goals.GetYearlyGoal() - this.goals.GetYearlyActual()).ToString();
            RemainingGoal = (goals.GetYearlyActual() / goals.GetYearlyGoal());

            ActualLabel.Text = "$" + this.goals.GetYearlyActual().ToString();
            GoalLabel.Text = "$" + this.goals.GetYearlyGoal().ToString();

            ProgressBar.Progress = RemainingGoal;
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Task.Run(async () => await GetMonthlyGoals());
            this.goals = new Goals();
            this.goals = ParseJSONToGoals(this.jsondoc, this.goals);

            float RemainingGoal;

            GoalText.Text = "$" + (this.goals.GetYearlyGoal() - this.goals.GetYearlyActual()).ToString();
            RemainingGoal = (goals.GetYearlyActual() / goals.GetYearlyGoal());

            ActualLabel.Text = "$" + this.goals.GetYearlyActual().ToString();
            GoalLabel.Text = "$" + this.goals.GetYearlyGoal().ToString();

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


            goals.SetYearlyGoal((float)jsonObject[currentMonthDBGoal]);
            goals.SetYearlyActual((float)jsonObject[currentMonthDBActual]);

            return goals;
        }
    }
}
