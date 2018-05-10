using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    public delegate void InvalidPasswordHandler(string username, int count);
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Count { get; private set; }

        public event InvalidPasswordHandler InvalidPassword;

        public bool Authenticate()
        {
            if (this.Username == "admin" && this.Password == "admin")
                return true;
            else
            {
                //Firing Event
                if(InvalidPassword != null)
                    InvalidPassword(this.Username, ++this.Count);
                return false;
            }
        }
    }
}
