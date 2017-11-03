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
//using System.Security.Cryptography;

using Xamarin.Forms;

namespace ServiceTrackerApp
{
    public partial class Employee_Login : ContentPage
    {

        public Employee_Login()

        {
            
            InitializeComponent();
           
        }

        async public void Handle_Clicked(object sender, System.EventArgs e)
        {
           
            if (usernameField.Text == null || passwordField.Text == null)
            {
               await DisplayAlert("Error", "A required field is empty", "OK");
            }

            else
            {
                if (await CheckValidLogin(usernameField.Text, passwordField.Text))
                {

                    //App.Current.MainPage = new Employee_Options(usernameField.Text);
                    //await Navigation.PushAsync(new GetTest());

                    
                    await Navigation.PushAsync(new Employee_Options(usernameField.Text));

                }
                else
                {
                    await DisplayAlert("Error", "Username or password incorrect", "OK");
                }
            }
        }

        async Task<bool> CheckValidLogin(string username, string password)
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

            User user = new User();
            await Task.Run(() => user = ParseJSONToUser(jsonDoc, user));
            System.Diagnostics.Debug.WriteLine(user.toString());

            string compareHash = "";
            await Task.Run(() => compareHash = getCompareHash(user.getpasswordSalt(), password));



            if (compareHash.Equals(user.getpasswordHash()))
            {
                return true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(compareHash);
                return false;
            }
        }

        private User ParseJSONToUser(JsonValue json, User user)
        {
            JsonObject jsonObject = json as JsonObject;

            user.setUserID((string)jsonObject["username"]);
            user.setisManager((bool)jsonObject["manager"]);
            user.setpasswordHash((string)jsonObject["passwordHash"]);
            user.setpasswordSalt((string)jsonObject["salt"]);

            return user;
        }

        private string getCompareHash(string salt, string password)
        {
            string result = "";

            string temp = salt + password;
            result = sha256(temp);
            result = result.ToLower();

            return result;
        }

        private string sha256(string text)
		{
            //var encData = Encoding.UTF8.GetBytes(text);
			Org.BouncyCastle.Crypto.Digests.Sha256Digest myHash = new Org.BouncyCastle.Crypto.Digests.Sha256Digest();
            byte[] msgBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(text);
            myHash.BlockUpdate(msgBytes, 0, msgBytes.Length);
			byte[] compArr = new byte[myHash.GetDigestSize()];
            myHash.DoFinal(compArr, 0);
            return BitConverter.ToString(compArr).Replace("-", string.Empty);
		}
    }
}

//coommment


//hello git