using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppDemo.Models;

namespace WebAppDemo.Controllers
{
    public class FirstController : Controller
    {
        
        public ActionResult Sample()
        {
            //return Content("First Controller, Sample Action Works!");
            var student = new Student() { Id = 1, Name = "Joey", Family = "Tribbiani", Phone = "+9891245678963" };
            //return Json(student, JsonRequestBehavior.AllowGet);
            return View(student);
        }
    }
}