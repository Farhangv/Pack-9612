using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppDemo.Models;

namespace WebAppDemo.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            List<User> users = new List<User>() {
                new User() { Id = 1, FullName = "John Doe", Username = "jdoe" },
                new User() { Id = 2, FullName = "Sarah Smith", Username = "ssmith" },
                new User() { Id = 3, FullName = "Ross Geller", Username = "rgeller" },
                new User() { Id = 4, FullName = "Monica Geller", Username = "mgeller" },
            };
            //ViewData["Users"] = users;
            //ViewBag.Users = users;
            ViewBag.Title = "مدیریت کاربران";
            return View(users);
        }
    }
}