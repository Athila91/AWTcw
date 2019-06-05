using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AWTcw.Models;


namespace AWTcw.Controllers
{
    public class SignUpController : Controller
    {
       

        public ActionResult SignUp()
        {
            List<SelectListItem> l = UserTypeModel.Types();
            ViewBag.t = l;
            return View();
        }

        /// <summary>
        /// Creates a new user account
        /// </summary>
        /// <param name="us"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public ActionResult CreateUser(UserModel us, string t)
        {
            List<SelectListItem> l = UserTypeModel.Types();
            us.TypeId = Convert.ToInt32(t);
            bool tmpbool = UserModel.RegisterUser(us);
            if (tmpbool)
            {

                return RedirectToAction("Login","Login");
            }
            else
            {
                
                ViewBag.t = l;
                return View("SignUp", us);
            }
        
        }
        public ActionResult CheckEmail(string t)
        {
            List<SelectListItem> l = UserTypeModel.Types();
            UserModel us = new UserModel();
            us.Email = t;
            bool tmpbool = UserModel.CheckExistingUser(us);
            if (tmpbool)
            {

                return Json(true);
            }
            else
            {
                return Json(false);
            }

        }
            
    }
}
