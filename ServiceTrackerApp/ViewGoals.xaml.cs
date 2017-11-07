using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ServiceTrackerApp
{
    public partial class ViewGoals : ContentPage
    {
        public string tid;
        public ViewGoals()
        {
            InitializeComponent();
        }
        public ViewGoals(string tid)
        {
            NavigationPage.SetHasBackButton(this, false);
            this.tid = tid;
            InitializeComponent();


        }

        async void Handle_Clicked3(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new YTDView(this.tid));
        }

        async void Handle_Clicked2(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new DTDView(this.tid));
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MTDView(this.tid));
        }

        async void Handle_Clicked4(object sender, System.EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
