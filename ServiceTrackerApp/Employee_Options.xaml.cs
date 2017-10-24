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
            InitializeComponent();
            this.Children.Add((new AddJobs(tid)));
            this.Children.Add(new ViewGoals());
            //this.tid = tid;
        }
    }
}


