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
        public AddJobs()
        {
            InitializeComponent();
            ServiceType.Items.Add("Demand Service");             ServiceType.Items.Add("Maintenance");             ServiceType.Items.Add("Tune-up");             ServiceType.Items.Add("IAQ");             ServiceType.Items.Add("Warranty");             ServiceType.Items.Add("Equipment - Air Handler");             ServiceType.Items.Add("Service Agreement - New");             ServiceType.Items.Add("Service Agreement - Renewal");             ServiceType.Items.Add("Equpipment - AC & Coil");             ServiceType.Items.Add("Equipment - Heat Pump System");             ServiceType.Items.Add("Equipment - Gas Furnance");             ServiceType.Items.Add("Equipment - Packaged Unit");             ServiceType.Items.Add("Equipment - Geothermal");
        }


        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (custNameField.Text == null || costField.Text == null || tidField.Text == null || ServiceType.SelectedItem.Equals(false))
            {
                await DisplayAlert("Error", "A required field is empty", "OK");
            }

            else 
            {
                string url = "http://capstone1.cecsresearch.org:8080/ServiceTrackerFinal/webresources/entityclasses.jobs";
                PostJobAsync(url);

            }
        }

        private async void PostJobAsync(string url)
        {
            double money = Convert.ToDouble(costField.Text);
            var client = new HttpClient();
            var job = new Jobs
            {
                Custname = custNameField.Text,
                Cost = money,
                Date = DateTime.Now,
                tid = tidField.Text,
                JobID = 998,
                ServiceType = ServiceType.SelectedItem.ToString()
            };

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
