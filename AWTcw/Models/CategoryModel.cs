using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace AWTcw.Models
{
    public class CategoryModel
    {
        public string Name { get; set; }
        public int QuestionId { get; set; }
        public int CategoryId { get; set; }
        public int NoOfQuestions { get; set; }
        public static List<CategoryModel> GetCategory()
        {

            List<CategoryModel> l = new List<CategoryModel>();
           
            Database d = DatabaseConnection.Connection.Connect();
            {

                using (DbCommand command = d.GetStoredProcCommand("GetCategory"))
                {
                    //d.AddInParameter(command, "@text", DbType.String, cat);

                    using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            CategoryModel u = new CategoryModel();
                            u.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                            u.Name = (reader["Name"].ToString());
                            l.Add(u);
                        }
                    }
                }
            }
            return l;
        }
        public static List<CategoryModel> GetCategories()
        {

            List<CategoryModel> l = new List<CategoryModel>();

            Database d = DatabaseConnection.Connection.Connect();
            {

                using (DbCommand command = d.GetStoredProcCommand("GetCategories"))
                {
                    //d.AddInParameter(command, "@text", DbType.String, cat);

                    using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            CategoryModel u = new CategoryModel();
                            u.NoOfQuestions = Convert.ToInt32(reader["qid"]);
                            u.Name = (reader["Name"].ToString());
                            l.Add(u);
                            //u.Password = ((reader["Password"].ToString()));
                            //u.Email = ((reader["Email"].ToString()));
                        }
                    }
                }
            }
            return l;
        }
       
        public static List<System.Web.Mvc.SelectListItem> Categories()
        {
            List<CategoryModel> lis = CategoryModel.GetCategory();
            List<System.Web.Mvc.SelectListItem> items = new List<System.Web.Mvc.SelectListItem>();

            items.Add(new System.Web.Mvc.SelectListItem { Text = lis[0].Name, Value = lis[0].CategoryId.ToString(), Selected = true });

            items.Add(new System.Web.Mvc.SelectListItem { Text = lis[1].Name, Value = lis[1].CategoryId.ToString() });

            items.Add(new System.Web.Mvc.SelectListItem { Text = lis[2].Name, Value = lis[2].CategoryId.ToString() });

            return items;
        }
    }
}