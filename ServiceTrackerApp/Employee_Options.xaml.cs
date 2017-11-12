using System.Collections.Generic;
using System.Net.Http;
using System.Collections.Specialized;

using Xamarin.Forms;

namespace ServiceTrackerApp
{
    public partial class Employee_Options : TabbedPage
    {
        //string tid;
        public Employee_Options(string tid)
        {
            NavigationPage.SetHasBackButton(this, false);
            Children.Add(new AddJobs(tid));

            Children.Add(new ViewGoals(tid));

            InitializeComponent();

            //this.tid = tid;
        }

        public Employee_Options()
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            //this.tid = tid;
        }
    }
}


