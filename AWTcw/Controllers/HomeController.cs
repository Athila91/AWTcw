using AWTcw.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Http.Description;
namespace AWTcw.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Home()
        {
            return View();
        }
     
    }
}
