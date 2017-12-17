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
    public partial class ChangePassword : ContentPage
    {
        public User user = new User();
        public ChangePassword()
        {
            InitializeComponent();

        }

        async public void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (password.Text != confirmPassword.Text || password.Text == null || confirmPassword.Text == null)
            {
                await DisplayAlert("Error", "Passwords do not Match", "OK");
            }
            else 
            {
                if (await CheckValidLogin(usernameField.Text, oldPassword.Text))
                {

                    string newPwd = password.Text;
                    string newPwdHash = "";
                    newPwdHash = this.user.getpasswordSalt() + newPwd;
                    newPwdHash = sha256(newPwdHash);
                    newPwdHash = newPwdHash.ToLower();
                    this.user.setpasswordHash(newPwdHash);

                    PutPwdAsync(this.user);

                }

                else {
                    await DisplayAlert("ERROR", "Passwords do not match", "OK");
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

            this.user = new User();
            await Task.Run(() => this.user = ParseJSONToUser(jsonDoc, user));
            System.Diagnostics.Debug.WriteLine(this.user.toString());

            string compareHash = "";
            await Task.Run(() => compareHash = getCompareHash(this.user.getpasswordSalt(), password));



            if (compareHash.Equals(this.user.getpasswordHash()))
            {
                System.Diagnostics.Debug.WriteLine("Old password Correct");
                return true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(compareHash);
                return false;
            }
        }

        private string getCompareHash(string salt, string password)
        {
            string result = "";

            string temp = salt + password;
            result = sha256(temp);
            result = result.ToLower();

            return result;
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
    

        private async void PutPwdAsync(User user)
        {
            this.user.setHasLoggedIn(true);
            string url = "http://capstone1.cecsresearch.org:8080/ServiceTrackerFinal/webresources/entityclasses.users/";
            //user.setUserID(usernameField.Text.ToString());
            //string username = user.getUserID();
            url += this.user.getUserID();
            //user.setisManager(false);
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(this.user), Encoding.UTF8, "application/json");
            var result = await client.PutAsync(url, content);
            if (result.IsSuccessStatusCode)
            {
                System.Diagnostics.Debug.WriteLine("Password Updated");
                await DisplayAlert("Success!", "Your password has been updated!", "OK");
                await Navigation.PushAsync(new Employee_Options(usernameField.Text));
            }

            else
            {
                System.Diagnostics.Debug.WriteLine("FAILED with response code: {0}", result);
                //await DisplayAlert("Failed!", "The Job Has Not Been Added", "OK");
            }
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

