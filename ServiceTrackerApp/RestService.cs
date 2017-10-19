using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;



namespace ServiceTrackerApp
{
    public class RestService : IRestService
    {
		HttpClient client;

        public List<Jobs> jobs { get; private set; }

	public RestService()
        {
            var authData = string.Format("{0}:{1}", "jggavu01", "CecsCapstone1");
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        public async Task<List<Jobs>> RefreshDataAsync()
        {
            jobs = new List<Jobs>();
            //RestURL = "http://capstone1.cecsresearch.org:8888/ServiceTracker3/webresources/entityclasses.jobs";

            var uri = new Uri(string.Format("http://capstone1.cecsresearch.org:8888/ServiceTracker3/webresources/entityclasses.jobs", string.Empty));

            try {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    jobs = JsonConvert.DeserializeObject<List<Jobs>>(content);
                }
            }

            catch (Exception ex) {
                Debug.WriteLine(@"                 Error {0}", ex.Message);
            }

            return jobs;
        }

        public async Task SaveJobsAsync (Jobs jobs, bool isNewJob = false)
        {
			//RestURL = "http://capstone1.cecsresearch.org:8888/ServiceTracker3/webresources/entityclasses.jobs";

			var uri = new Uri(string.Format("http://capstone1.cecsresearch.org:8888/ServiceTracker3/webresources/entityclasses.jobs", string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(jobs);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewJob)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"              Jobs successfully saved");
                }
            }

                catch (Exception ex)
                {
                    Debug.WriteLine(@"                  ERROR {0}", ex.Message);
                }

            }

        public async Task DeleteJobsAsync (string id)
            {
               //RestURL = "http://capstone1.cecsresearch.org:8888/ServiceTracker3/webresources/entityclasses.jobs";
                    
             var uri = new Uri(string.Format("http://capstone1.cecsresearch.org:8888/ServiceTracker3/webresources/entityclasses.jobs", string.Empty));

             try {
                    var response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode) {
                    Debug.WriteLine(@"                  Jobs succesfully deleted.");
                }

            }catch (Exception ex) {
                Debug.WriteLine(@"                  ERROR {0}", ex.Message);

                
                }
		    }
		}
    }
