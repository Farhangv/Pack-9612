using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityDemo.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            return Content("Index");
        }
        [Authorize]
        public ActionResult Details()
        {
            return Content("Details");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit()
        {
            return Content("Edit");
        }
        [Authorize(Users = "farhangv@gmail.com")]
        public ActionResult Delete()
        {
            return Content("Delete");
        }
    }
}