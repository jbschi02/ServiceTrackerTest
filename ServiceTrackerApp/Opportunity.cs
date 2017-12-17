using System;
namespace ServiceTrackerApp
{
    public class Opportunity
    {
        public int age { get; set; }

        public int oppid { get; set; }

        public double quoteamount { get; set; }

        public bool quoteGiven { get; set; }

        public string equipmenttype { get; set; }

        public string custname { get; set; }

        public bool isClosed { get; set; }

        public string tid { get; set; }

        public DateTime date { get; set; }

        public string brand { get; set; }
    }
}