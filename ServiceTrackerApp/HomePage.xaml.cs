using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ServiceTrackerApp
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Manager_Login());
        }

        void Handle_Clicked2(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Employee_Login());
        }
    }
}
