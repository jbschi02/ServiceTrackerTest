using System;
namespace ServiceTrackerApp
{
    public class User
    {
        private string userid  {get; set; }
        private string passwordHash {get; set; }
        private string passwordSalt { get; set; }
        private bool isManager { get; set; }

        public User()
        {
            this.userid = "";
            this.isManager = false;
            this.passwordHash = "";
            this.passwordSalt = "";
        }
    }
}
