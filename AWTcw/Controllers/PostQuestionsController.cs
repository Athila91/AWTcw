using AWTcw.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AWTcw.Controllers
{
    public class PostQuestionsController : Controller
    {
        
        /// <summary>
        /// Post question action
        /// </summary>
        /// <returns></returns>
        public ActionResult PostQuestions()
        {
                List<SelectListItem> l = CategoryModel.Categories();
                ViewBag.t = l;
                return View();
        }

        /// <summary>
        /// Checks whether the user is logged in o post a question.
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckUser()
        {

            var user = Session["user"] as UserModel;

            if (user == null)
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddQuestions(QuestionModel ques, string t, string tag)
        {
            int s = 0;
            var user = Session["user"] as UserModel;
            s = user.UserId;
            if (ques != null)
            {
                ques.UserId = s;
                ques.CategoryId = Convert.ToInt32(t);
                QuestionModel.AddQuestion(ques);
                this.AddTag(tag);
                
            }
            return RedirectToAction("PostQuestions");
        }
        public ActionResult AddTag(string tq)
        {
            if (!(tq == ""))
            {
                QuestionModel q = new QuestionModel();
                q = QuestionModel.GetLastQuestion();

                int s = 0;
                s = q.QuestionId;
                TagModel.AddTag(tq, s);
            }
            
            

            //QuestionModel.AddQuestion(ques);
            return RedirectToAction("PostQuestions");
        }
       
        
    }
}
