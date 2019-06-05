using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace AWTcw.Models
{
    public class TagModel
    {
        public string TagName { get; set; }
        public int QuestionId { get; set; }
        public int NoOfQuestions { get; set; }

        public static void AddTag(String st, int qid)
        {
            String[] values = st.Split(',');
            foreach(string s in values)
                    {
            Database d = DatabaseConnection.Connection.Connect();
            {

                using (DbCommand command = d.GetStoredProcCommand("AddTag"))
                {
                    
                    d.AddInParameter(command, "@Tagname", DbType.String, s );
                     d.AddInParameter(command, "@Questionid", DbType.Int32, qid);
                    using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                    {
                    }
                }
            }

            }
           

        }
        public static List<TagModel> GetTags()
        {

            List<TagModel> tags = new List<TagModel>();
                Database d = DatabaseConnection.Connection.Connect();
                {

                    using (DbCommand command = d.GetStoredProcCommand("GetTags"))
                    {

                      
                        using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                        {
                            while (reader.Read())
                            {
                                TagModel tag = new TagModel();
                                tag.TagName = (reader["TagName"].ToString());
                                tag.NoOfQuestions = (Convert.ToInt32(reader["qid"]));
                                tags.Add(tag);
                            }
                        }
                    }
                

            }

                return tags;
        }
    }
}