using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace AWTcw.Models
{
    public class AnswerModel
    {
        public string QuestionTitle { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public string AnswerText { get; set; }
        public string QuestionBody { get; set; }

        public static List<AnswerModel> GetAnswers(int questionId)
        {
            List<AnswerModel> list = new List<AnswerModel>();
            Database d = DatabaseConnection.Connection.Connect();
            {

                using (DbCommand command = d.GetStoredProcCommand("GetAnswers"))
                {
                    d.AddInParameter(command, "@questionid", DbType.Int32, questionId);
                    using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            AnswerModel ans = new AnswerModel();
                            ans.QuestionId = (Convert.ToInt32(reader["QuestionId"]));
                            ans.UserId = (Convert.ToInt32(reader["UserId"]));
                           ans.AnswerText = ((reader["AnswerText"].ToString()));
                           list.Add(ans);
                        }
                    }
                }

            }
            return list;

        }
        public static void AddAnswer(string ans,int uid,int qid)
        {
            List<AnswerModel> list = new List<AnswerModel>();
            Database d = DatabaseConnection.Connection.Connect();
            {

                using (DbCommand command = d.GetStoredProcCommand("AddAnswer"))
                {
                    
                    d.AddInParameter(command, "@answer", DbType.String, ans);
                    d.AddInParameter(command, "@quesid", DbType.Int32, qid);
                    d.AddInParameter(command, "@useid", DbType.Int32, uid);
                    using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                    {
                    }
                }

            }
            

        }
    }
}