using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AWTcw.Models;
namespace AWTcw.Controllers
{
    public class RestController : ApiController
    {
        public List<UserTypeModel> Get()
        {
            List<UserTypeModel> l = new List<UserTypeModel>();
            return l = UserTypeModel.GetUserType();
        }
    }
}
