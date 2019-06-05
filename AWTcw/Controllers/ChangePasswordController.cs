using AWTcw.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AWTcw.Controllers
{
    public class ChangePasswordController : Controller
    {
       /// <summary>
       /// Returns the change password view.
       /// </summary>
       /// <returns></returns>
        public ActionResult ChangePassword()
        {
            return View();
        }

        /// <summary>
        /// Updates the password
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        public ActionResult UpdatePassword(ChangePasswordModel ch)
        {
            var user = Session["user"] as UserModel;
            string mail = user.Email;
            ChangePasswordModel.UpdatePassword(ch, mail);
            return View("ChangePassword", ch);
        }
    }
}
