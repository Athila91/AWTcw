using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AWTcw.Models;
namespace AWTcw.Controllers
{
    public class CategoryController : Controller
    {
        /// <summary>
        /// Returns the Category view.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Category()
        {
            List<CategoryModel> list = CategoryModel.GetCategories();
            ViewBag.lis = list;
            return View();
        }

    }
}
