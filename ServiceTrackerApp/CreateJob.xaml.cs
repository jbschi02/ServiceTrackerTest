using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ServiceTrackerApp
{
    public partial class CreateJob : ContentPage
    {
        public CreateJob()
        {
            InitializeComponent();

			ServiceType.Items.Add("Demand Service");
			ServiceType.Items.Add("Maintenance");
			ServiceType.Items.Add("Tune-up");
			ServiceType.Items.Add("IAQ");
			ServiceType.Items.Add("Warranty");
			ServiceType.Items.Add("Equipment - Air Handler");
			ServiceType.Items.Add("Service Agreement - New");
			ServiceType.Items.Add("Service Agreement - Renewal");
			ServiceType.Items.Add("Equpipment - AC & Coil");
			ServiceType.Items.Add("Equipment - Heat Pump System");
			ServiceType.Items.Add("Equipment - Gas Furnance");
			ServiceType.Items.Add("Equipment - Packaged Unit");
			ServiceType.Items.Add("Equipment - Geothermal"); ;
        }
    }
}
