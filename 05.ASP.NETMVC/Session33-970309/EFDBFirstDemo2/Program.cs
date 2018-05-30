using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDBFirstDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            EFDBEntities ctx = new EFDBEntities();
            //ctx.InsertUser("JohnDoe", "123");
            User newUser = new User()
            {
                Username = "DavidSmith",
                Password = "123"
            };
            ctx.Users.Add(newUser);
            ctx.SaveChanges();
        }
    }
}
