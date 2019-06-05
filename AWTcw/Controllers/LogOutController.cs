using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AWTcw.Controllers
{
    public class LogOutController : Controller
    {
        /// <summary>
        /// Logout action.
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login","Login");
        }

    }
}
