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

        public string tid;

        public AddJobs()
        {
            InitializeComponent();
        }

        public AddJobs(string tid)
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            ServiceType.Items.Add("Demand Service");             ServiceType.Items.Add("Maintenance");             ServiceType.Items.Add("Tune-up");             ServiceType.Items.Add("IAQ");             ServiceType.Items.Add("Warranty");             ServiceType.Items.Add("Equipment - Air Handler");             ServiceType.Items.Add("Service Agreement - New");             ServiceType.Items.Add("Service Agreement - Renewal");             ServiceType.Items.Add("Equpipment - AC & Coil");             ServiceType.Items.Add("Equipment - Heat Pump System");             ServiceType.Items.Add("Equipment - Gas Furnance");             ServiceType.Items.Add("Equipment - Packaged Unit");             ServiceType.Items.Add("Equipment - Geothermal");

            jobType.Items.Add("Demand Service");
            jobType.Items.Add("Maintenance");
            jobType.Items.Add("IAQ");
            jobType.Items.Add("Equipment - Air Handler");
            jobType.Items.Add("Service Agreement - New");
            jobType.Items.Add("Equpipment - AC & Coil");
            jobType.Items.Add("Equipment - Heat Pump System");
            jobType.Items.Add("Equipment - Gas Furnance");
            jobType.Items.Add("Equipment - Packaged Unit");
            jobType.Items.Add("Equipment - Geothermal");


            Opportunity.Items.Add("Yes");
            Opportunity.Items.Add("No");

            quoteField.Items.Add("Yes");
            quoteField.Items.Add("No");

            opportunityStatus.Items.Add("Open");
            opportunityStatus.Items.Add("Closed");

            this.tid = tid;
        }

        void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (Opportunity.SelectedIndex == 0)
            {
                ageField.IsVisible = true;
                quoteField.IsVisible = true;
            }

            else
            {
                ageField.IsVisible = false;
                quoteField.IsVisible = false;
            }
        }

        void Handle_SelectedIndexChanged2(object sender, System.EventArgs e)
        {
            if (quoteField.SelectedIndex == 0)
            {
                jobType.IsVisible = true;
                quoteAmount.IsVisible = true;
                opportunityStatus.IsVisible = true;
            }

            else
            {
                jobType.IsVisible = false;
                quoteAmount.IsVisible = false;
                opportunityStatus.IsVisible = false;

            }
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

                Goals goals = new Goals();
                goals = await ParseJSONToGoals(goals);
                goals.dailyactual += (float)Convert.ToDouble(costField.Text);
                goals.ytdactual += (float)Convert.ToDouble(costField.Text);
                goals.addToMonthlyActual((float)Convert.ToDouble(costField.Text));
                PutGoalsAsync(goals);
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


        private async Task<Goals> ParseJSONToGoals(Goals goals)
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
                        
                    }
                }
            }

            JsonObject jsonObject = jsonDoc as JsonObject;
            double money = Convert.ToDouble(costField.Text);
            string currentMonthDBActual = "";
            string currentMonthDBGoal = "";
            string sMonth = DateTime.Now.ToString("MM");
            int dayAmount = 31;
            goals = goals.ParseJSON(goals, jsonObject);
            /*switch (sMonth)
            {
                case "01":
                    goals.jan = ((float)jsonObject[currentMonthDBGoal]);
                    break;
                case "02":
                    goals.feb = ((float)jsonObject[currentMonthDBGoal]);
                    break;
                case "03":
                    goals.mar = ((float)jsonObject[currentMonthDBGoal]);
                    break;
                case "04":
                    goals.apr = ((float)jsonObject[currentMonthDBGoal]);
                    break;
                case "05":
                    goals.may = ((float)jsonObject[currentMonthDBGoal]);
                    break;
                case "06":
                    goals.jun = ((float)jsonObject[currentMonthDBGoal]);
                    break;
                case "07":
                    goals.jul = ((float)jsonObject[currentMonthDBGoal]);
                    break;
                case "08":
                    goals.aug = ((float)jsonObject[currentMonthDBGoal]);
                    break;
                case "09":
                    goals.sep = ((float)jsonObject[currentMonthDBGoal]);
                    break;
                case "10":
                    goals.oct = ((float)jsonObject[currentMonthDBGoal]);
                    break;
                case "11":
                    goals.nov = ((float)jsonObject[currentMonthDBGoal]);
                    break;
                case "12":
                    goals.dec = ((float)jsonObject[currentMonthDBGoal]);
                    break;
            }*/
            return goals;
        }
    
        private async void PutGoalsAsync(Goals goals)
        {
            string url = "http://capstone1.cecsresearch.org:8080/ServiceTrackerFinal/webresources/entityclasses.goals/";
            url += this.tid;
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(goals), Encoding.UTF8, "application/json");
            var result = await client.PutAsync(url, content);
            if (result.IsSuccessStatusCode)
            {
                System.Diagnostics.Debug.WriteLine("goals successfully updated");
                //await DisplayAlert("Success!", "The Job Has Been Added", "OK");
            }

            else
            {
                System.Diagnostics.Debug.WriteLine("FAILED with response code: {0}", result);
                //await DisplayAlert("Failed!", "The Job Has Not Been Added", "OK");
            }
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
