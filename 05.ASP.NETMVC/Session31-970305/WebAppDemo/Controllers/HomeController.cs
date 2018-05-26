using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //return Content("Home Page!");
            //return new ContentResult()
            //{
            //    Content = "Home Page!",
            //    ContentEncoding = System.Text.Encoding.UTF8,
            //    ContentType = "text/plain"
            //};
            //return Redirect("https://google.com");
            return new EmptyResult();
        }
    }
}