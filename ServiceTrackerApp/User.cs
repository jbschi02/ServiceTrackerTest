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

        public void setUserID(string id)
        {
            this.userid = id;
        }

        public void setisManager(bool manager)
		{
            this.isManager = manager;
		}

		public void setpasswordHash(string pwd)
		{
            this.passwordHash = pwd;
		}

		public void setpasswordSalt(string salt)
		{
            this.passwordSalt = salt;
		}

        public string getUserID()
		{
			return this.userid;
		}

        public bool getisManager()
		{
			return this.isManager;
		}

        public string getpasswordHash()
		{
			return this.passwordHash;
		}

        public string getpasswordSalt()
		{
			return this.passwordSalt;
		}

        public string toString()
        {
            return "User " + this.getUserID() + " with password hash " + this.getpasswordHash() + " and salt " + this.getpasswordSalt() + " and is a manager? " + this.getisManager();
        }
    }
}
