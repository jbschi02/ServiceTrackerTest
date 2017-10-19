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
    public partial class GetTest : ContentPage
    {
        public GetTest()
        {
            InitializeComponent();
        }

        void Handle_Clicked2(object sender, System.EventArgs e)
        {
            string url = "http://capstone1.cecsresearch.org:8080/ServiceTrackerFinal/webresources/entityclasses.jobs";
            PostJobAsync(url);
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            string url = "http://capstone1.cecsresearch.org:8080/ServiceTrackerFinal/webresources/entityclasses.jobs";
            JsonValue json = await FetchJobsAsync(url);
        }

        private async Task<JsonValue> FetchJobsAsync(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
                    System.Diagnostics.Debug.WriteLine("Response: {0}", jsonDoc.ToString());

                    return jsonDoc;
                }
            }

        }

        private async void PostJobAsync (string url) 
        {
            var client = new HttpClient();
			var job = new Jobs
			{
				Custname = "jackson",
				Cost = 222.03,
				jobDate = DateTime.Now,
				techid = "jackED",
				JobID = 1,
				ServiceType = "Repair"
			};

            var content = new StringContent(JsonConvert.SerializeObject(job), Encoding.UTF8, "application/json");
            var result = await client.PostAsync(url, content);
            if (result.IsSuccessStatusCode)
            {
                System.Diagnostics.Debug.WriteLine("job successfully added");
            }

            else {
                System.Diagnostics.Debug.WriteLine("FAILED with response code: {0}", result);
            }
		}

    }
}
