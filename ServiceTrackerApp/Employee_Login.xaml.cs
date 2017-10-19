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

using Xamarin.Forms;

namespace ServiceTrackerApp
{
    public partial class Employee_Login : ContentPage
    {
        public Employee_Login()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (usernameField.Text == null || passwordField.Text == null)
            {
               await DisplayAlert("Error", "A required field is empty", "OK");
            }

            else
            {
                if (await CheckValidLogin(usernameField.Text, passwordField.Text))
                {
                    
                    await Navigation.PushAsync(new GetTest());
                }
                else
                {
                    await DisplayAlert("Error", "Username or password incorrect", "OK");
                }
            }
        }

        async Task<bool> CheckValidLogin(string username, string password)
        {
            JsonValue json = await getUserInfoAsync(username);
            //bool isValidJSON = await CheckValidJSON(json);
            return true;
        }

		private async Task<JsonValue> getUserInfoAsync(string username)
		{
            string url = "http://capstone1.cecsresearch.org:8080/ServiceTrackerFinal/webresources/entityclasses.users/";
            url += username;
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
			request.ContentType = "application/json";
			request.Method = "GET";

			using (WebResponse response = await request.GetResponseAsync())
			{
				using (Stream stream = response.GetResponseStream())
				{
                    JsonValue jsonDoc = null;
                    try
                    {
						jsonDoc = await Task.Run(() => JsonObject.Load(stream));
						System.Diagnostics.Debug.WriteLine("Response: {0}", jsonDoc.ToString());
                    }
                    catch (System.ArgumentException)
                    {
                        //jsonDoc = null;
                    }
                    string jsoncheck = jsonDoc.ToString();
                    System.Diagnostics.Debug.WriteLine("Doc type: {0}", jsoncheck);
					return jsonDoc;
				}
			}

		}
    }
}

//coommment
