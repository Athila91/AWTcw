using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AWTcw.Models;
namespace AWTcw.Controllers
{
    public class TagController : Controller
    {
        
        [HttpGet]
        public ActionResult Tag()
        {
            List<TagModel> lis = TagModel.GetTags();
            ViewBag.tags = lis;
            return View();
        }
       

    }
}
