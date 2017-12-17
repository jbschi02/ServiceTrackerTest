using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;
using System.Json;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceTrackerApp
{
    public class User
    {
        public string username  {get; set; }
        public string passwordHash {get; set; }
        public string salt { get; set; }
        public bool manager { get; set; }
        public bool isOwner { get; set; }
        public string email { get; set; }
        public bool hasLoggedIn { get; set; }

        public User()
        {
            this.username = "";
            this.manager = false;
            this.passwordHash = "";
            this.salt = "";
            this.isOwner = false;
            this.email = "";
            this.hasLoggedIn = false;
        }


        public void setUserID(string id)
        {
            this.username = id;
        }

        public void setisManager(bool manager)
		{
            this.manager = manager;
		}

		public void setpasswordHash(string pwd)
		{
            this.passwordHash = pwd;
		}

		public void setpasswordSalt(string salt)
		{
            this.salt = salt;
		}

        public string getUserID()
		{
            return this.username;
		}

        public bool getHasLoggedIn()
        {
            return this.hasLoggedIn;
        }

        public void setHasLoggedIn(bool loggedIn)
        {
            this.hasLoggedIn = loggedIn;
        }


        public bool getisManager()
		{
            return this.manager;
		}

        public void setisOwner(bool owner)
        {
            this.isOwner = owner;
        }

        public bool getisOwner()
        {
            return this.isOwner;
        }

        public string getEmail ()
        {
            return this.email;
        }

        public void setEmail (string email)
        {
            this.email = email;
        }

        public string getpasswordHash()
		{
            return this.passwordHash;
		}

        public string getpasswordSalt()
		{
            return this.salt;
		}

        public string toString()
        {
            return "User " + this.getUserID() + " with password hash " + this.getpasswordHash() + " and salt " + this.getpasswordSalt() + " and is a manager? " + this.getisManager();
        }
    }
}
