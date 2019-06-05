using AWTcw.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AWTcw.Controllers
{
    public class searchController : ApiController
    {
        /// <summary>
        /// Gets all the questions.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<QuestionModel> Get()
        {
            IEnumerable<QuestionModel> l = QuestionModel.GetQuestions();
            return l;
        }

        /// <summary>
        /// Gets the questions according to user's search request.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public IEnumerable<QuestionModel> questions(string s)
        {
            IEnumerable<QuestionModel> k = QuestionModel.SearchQuestion(s); 
            return k;
        }
    }
}
