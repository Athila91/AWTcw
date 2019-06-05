using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AWTcw.Models;

namespace AWTcw.Controllers
{
    public class ViewAnswersController : Controller
    {
       [HttpGet]
        public ActionResult ViewAnswers(int quesid)
        {
            List<AnswerModel> lis = AnswerModel.GetAnswers(quesid);
            QuestionModel q = QuestionModel.GetQuestionById(quesid);
            Session["question"] = q;
            ViewBag.S = lis;
            return View(q);
        }

        /// <summary>
        /// Adds a reputation point.
        /// </summary>
        /// <param name="rep"></param>
        /// <returns></returns>
         public ActionResult AddReputation(int rep)
            {
                var user = Session["user"] as UserModel;
                if (user == null)
                {
                    return Json(false);
                }
                else
                {
                    UserModel.AddReputationPoints(rep);
                    
                    return View();
                }
            }

        /// <summary>
        /// Adds an answer
        /// </summary>
        /// <param name="ans"></param>
        /// <returns></returns>
            public ActionResult AddAnswer(string ans)
            {
                int qid = 0;
                var question = Session["question"] as QuestionModel;
                qid = question.QuestionId;
                if (ans != "")
                {
                    var user = Session["user"] as UserModel;
                   if(user == null)
                   {
                        return Json(false);
                   }
                    else if (user.TypeId == 2  )
                    {
                        return Json(false);
                    }
                    else
                    {
                        int uid = user.UserId;
                        if (!(ans == ""))
                        {
                            this.AddNoOfAnswers();
                            AnswerModel.AddAnswer(ans, uid, qid);
                        }
                    }

                }
                List<AnswerModel> lis = AnswerModel.GetAnswers(qid);
                QuestionModel q = QuestionModel.GetQuestionById(qid);

                ViewBag.S = lis;
                return View(q);
            }

        /// <summary>
        /// Adds loyalty points to the user.
        /// </summary>
        /// <returns></returns>
            public ActionResult LoyaltyPoints()
            {
                int uid = 0;
                var question = Session["question"] as QuestionModel;
                uid = question.UserId;
                var user = Session["user"] as UserModel;
                if (user == null)
                {
                    return Json(false);
                }
                else
                {
                    UserModel.AddLoyaltyPoints(uid);
                    return View();
                }
            }

            /// <summary>
            /// Increases the number of answers for a question.
            /// </summary>
            /// <returns></returns>
            public ActionResult AddNoOfAnswers()
            {
                
                int qid = 0;
                var question = Session["question"] as QuestionModel;
                qid = question.QuestionId;
                QuestionModel.AddNoOfAnswers(qid);
                
                return View();
            }
        }
    }

