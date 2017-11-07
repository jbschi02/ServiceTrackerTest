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

using Xamarin.Forms;

namespace ServiceTrackerApp
{
    public partial class AddJobs : ContentPage
    {
<<<<<<< HEAD
        public string tid;
        public AddJobs(string tid)
=======
        public AddJobs()
>>>>>>> 5be4e01... All Goals Pages complete
        {
            InitializeComponent();
        }
        public string tid;
        public AddJobs(string tid)
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            ServiceType.Items.Add("Demand Service");             ServiceType.Items.Add("Maintenance");             ServiceType.Items.Add("Tune-up");             ServiceType.Items.Add("IAQ");             ServiceType.Items.Add("Warranty");             ServiceType.Items.Add("Equipment - Air Handler");             ServiceType.Items.Add("Service Agreement - New");             ServiceType.Items.Add("Service Agreement - Renewal");             ServiceType.Items.Add("Equpipment - AC & Coil");             ServiceType.Items.Add("Equipment - Heat Pump System");             ServiceType.Items.Add("Equipment - Gas Furnance");             ServiceType.Items.Add("Equipment - Packaged Unit");             ServiceType.Items.Add("Equipment - Geothermal");

            Opportunity.Items.Add("Yes");
            Opportunity.Items.Add("No");
<<<<<<< HEAD
            this.tid = tid;
=======

            this.tid = tid;


          
>>>>>>> 5be4e01... All Goals Pages complete
        }

        async void Handle_Clicked2(object sender, System.EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (custNameField.Text == null || costField.Text == null || ServiceType.SelectedItem.Equals(false))
            {
                await DisplayAlert("Error", "A required field is empty", "OK");
            }

            else 
            {
                string url = "http://capstone1.cecsresearch.org:8080/ServiceTrackerFinal/webresources/entityclasses.jobs";
                PostJobAsync(url);

                custNameField.Text = String.Empty;
                costField.Text = String.Empty;
                Opportunity.SelectedItem = null;
                ServiceType.SelectedItem = null;

            }
        }

        private async Task<bool> CheckJobID (int num)
        {
            string url = "http://capstone1.cecsresearch.org:8080/ServiceTrackerFinal/webresources/entityclasses.jobs/";
            url += num.ToString();
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
                        return true;
                    }
                }
            }
            return false;
        }




        private int GetRand()
        {
            Random rand = new Random();
            int newID = rand.Next(0, 2000000000);

            return newID;
        }


        private Goals ParseJSONToGoals(JsonValue json, Goals goals)
        {
            JsonObject jsonObject = json as JsonObject;
            double money = Convert.ToDouble(costField.Text);
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
            goals.SetDailyActual((float)jsonObject["dailyactual"]) ;

            goals.SetDailyGoals(goals.GetMonthlyGoal() / dayAmount);


            return goals;
        }
    
        private async void UpdateGoalsAsync(string url)
        {
            
        }

        private async void PostJobAsync(string url)
        {
            double money = Convert.ToDouble(costField.Text);
            int newJobId = GetRand();
            var client = new HttpClient();
            var job = new Jobs
            {
                Custname = custNameField.Text,
                Cost = money,
                Date = DateTime.Now,
                tid = this.tid,
                JobID = newJobId,
                ServiceType = ServiceType.SelectedItem.ToString()
            };

            do
            {
                newJobId = GetRand();
            } while (!(await CheckJobID(newJobId)));

            var content = new StringContent(JsonConvert.SerializeObject(job), Encoding.UTF8, "application/json");
            var result = await client.PostAsync(url, content);
            if (result.IsSuccessStatusCode)
            {
                System.Diagnostics.Debug.WriteLine("job successfully added");
               await DisplayAlert("Success!", "The Job Has Been Added", "OK");
            }

            else
            {
                System.Diagnostics.Debug.WriteLine("FAILED with response code: {0}", result);
                await DisplayAlert("Failed!", "The Job Has Not Been Added", "OK");
            }
        }
    }
}
