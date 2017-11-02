using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ServiceTrackerApp
{
    public partial class ViewGoals : ContentPage
    {
        public ViewGoals()
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();


        }

        async void Handle_Clicked3(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new YTDView());
        }

        async void Handle_Clicked2(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new DTDView());
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MTDView());
        }
    }
}
