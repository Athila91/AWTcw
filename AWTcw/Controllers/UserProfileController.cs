using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AWTcw.Models;
namespace AWTcw.Controllers
{
    public class UserProfileController : Controller
    {
      
        /// <summary>
        /// Displays all the user details.
        /// </summary>
        /// <returns></returns>
        public ActionResult UserProfile()
        {
            
            var user = Session["user"] as UserModel;
            if (user != null)
            {
                UserModel u = UserModel.GetUserDetails(user);
                return View(u);
            }
            return RedirectToAction("Home", "Home");
            
        }

        /// <summary>
        /// Saves changes to the profile.
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public ActionResult SaveProfile(UserModel u)
        {
            var user = Session["user"] as UserModel;
            string email = user.Email;
            UserModel.UpdateUser(u, email);
            Session["user"] = u;
            return RedirectToAction("UserProfile");
        }

    }
}
