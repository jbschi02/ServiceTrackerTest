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

/*
namespace ServiceTrackerApp
{
    public partial class ForgotPassword : ContentPage
    {
        public User user = new User();
        public ForgotPassword()
        {
            InitializeComponent();
        }

        async public void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (usernameField.Text == "")
            {
                await DisplayAlert("Error", "Please enter your username", "OK");
            }

            else
            {
                if (await CheckValidLogin(usernameField.Text))
                {
                    
                }
            }
        }



        async Task<bool> CheckValidLogin(string username)
        {
            string url = "http://capstone1.cecsresearch.org:8080/ServiceTrackerFinal/webresources/entityclasses.users/";
            url += username;
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
                        return false;
                    }
                }
            }

            this.user = new User();
            await Task.Run(() => this.user = ParseJSONToUser(jsonDoc, user));
            System.Diagnostics.Debug.WriteLine(this.user.toString());

            return true;


        }


      

        private User ParseJSONToUser(JsonValue json, User user)
        {
            JsonObject jsonObject = json as JsonObject;

            user.setUserID((string)jsonObject["username"]);
            user.setisManager((bool)jsonObject["manager"]);
            user.setpasswordHash((string)jsonObject["passwordHash"]);
            user.setpasswordSalt((string)jsonObject["salt"]);
            user.setEmail((string)jsonObject["email"]);
            user.setisOwner((bool)jsonObject["isOwner"]);
            user.setHasLoggedIn((bool)jsonObject["hasLoggedIn"]);

            return user;
        }


        private async Task<User> ParseJSONToUsers(User user)
        {
            string url = "http://capstone1.cecsresearch.org:8080/ServiceTrackerFinal/webresources/entityclasses.users/";
            url += this.user;
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
            user = ParseJSONToUser(jsonDoc, user);
            return user;
        }
    }

 }
*/