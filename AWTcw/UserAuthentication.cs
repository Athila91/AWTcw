using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AWTcw.Models;
namespace AWTcw
{
    public class UserAuthentication
    {
        public static bool CheckUser(UserModel u)
        {

            if (!UserModel.CheckPassword(u))
            {

                return false;
            }
            else
            {
                return true;


            }
        }
    }
}