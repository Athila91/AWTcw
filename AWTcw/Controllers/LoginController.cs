using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Mvc;
using AWTcw.Models;

namespace AWTcw.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Login()
        {

            //string ses = UserModel.GetSessionId();
            ////var user = Session["user"] as UserModel;

            //UserModel u = (UserModel)Session[ses];
            ////Session["asd"] = u;
           
            ////Session.Timeout= 10000;
            ////u = (UserModel)Session[ses];
            //if (ses == null)
            //{
                return View();
            //}
            //else
            //{
            //    return RedirectToAction("Home", "Home");
            //}

        }

        public ActionResult ValidateUser(UserModel u)
        {
            if (UserAuthentication.CheckUser(u))
            {
                
                
                string s;
                s = Session.SessionID;
                Session["user"] = u;
                
                
                UserModel.AddSessionId(s);
                
                List<UserTypeModel> l = UserTypeModel.GetUserType();;
                
                //var url = Url.RouteUrl("ActionApi", new { controller = "Home", action = "Get" });
                //return RedirectToAction("Get", "Home", Url.RouteUrl("ActionApi", new { controller = "Home" }));
                return RedirectToAction("Home", "Home");
            }
            else
            {
                //ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View("Login",u);
            }
        }
    }
}
