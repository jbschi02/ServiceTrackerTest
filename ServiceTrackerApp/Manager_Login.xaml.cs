using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ServiceTrackerApp
{
    public partial class Manager_Login : ContentPage
    {
        public Manager_Login()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
			
			if (usernameField.Text == null || passwordField.Text == null)
			{
					DisplayAlert("Error", "A required field is empty", "OK");
			}

			else
			{
                Navigation.PushAsync(new GetTest());
			}
        }
    }
}
