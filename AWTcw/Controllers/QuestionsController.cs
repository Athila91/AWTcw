using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AWTcw.Models;
namespace AWTcw.Controllers
{
    public class QuestionsController : Controller
    {

        public ActionResult Questions()
        {

            return View();
        }

        /// <summary>
        /// Gets questions by the category.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public ActionResult CategoryQuestions(string category)
        {
            List<QuestionModel> lis = QuestionModel.GetQuestionsByCategory(category);
            ViewBag.categoryList = lis;
            return View("Questions");
        }

        /// <summary>
        /// Gets questions by the tag.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public ActionResult TagQuestions(string tag)
        {
            List<QuestionModel> lis = QuestionModel.GetQuestionsByTag(tag);
            ViewBag.tagList = lis;
            return View("Questions");
        }
    

    }
}
