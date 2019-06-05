using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace AWTcw.Models
{
    public class UserTypeModel
    {
        public int TypeId { get; set; }

        public string Type { get; set; }

        public static List<UserTypeModel> GetUserType()
        {
            List<UserTypeModel> list = new List<UserTypeModel>();
            Database d = DatabaseConnection.Connection.Connect();
            {

                using (DbCommand command = d.GetStoredProcCommand("GetUserType"))
                {
                   
                    using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            UserTypeModel us = new UserTypeModel();
                            us.TypeId = (Convert.ToInt32(reader["TypeId"]));
                            us.Type = ((reader["Type"].ToString()));
                            list.Add(us);

                        }
                    }
                }

            }
            return list;
        }

        public static List<System.Web.Mvc.SelectListItem> Types()
        {
            List<UserTypeModel> lis = UserTypeModel.GetUserType();
            List<System.Web.Mvc.SelectListItem> items = new List<System.Web.Mvc.SelectListItem>();

            items.Add(new System.Web.Mvc.SelectListItem { Text = lis[0].Type, Value = lis[0].TypeId.ToString(), Selected = true });

            items.Add(new System.Web.Mvc.SelectListItem { Text = lis[1].Type, Value = lis[1].TypeId.ToString() });

            return items;
        }
    }
}