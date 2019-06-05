using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace AWTcw.Models
{
    public class QuestionModel
    {
        public int QuestionId { get; set; }

        [Required]
        [Display(Name = "Question")]
        public string Question { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        public int NoOfAnswers { get; set; }
        [Required]
        //[StringLength(100, ErrorMessage = "Enter the last name.", MinimumLength = 1)]
        //[DataType(DataType.Text)]
        [Display(Name = "Question Title")]
        public string Title { get; set; }
        public DateTime AddedDate { get; set; }
        public List<TagModel> tags { get; set; }

        public static List<QuestionModel> GetQuestions()
        {

            List<QuestionModel> l = new List<QuestionModel>();

            Database d = DatabaseConnection.Connection.Connect();
            {

                using (DbCommand command = d.GetStoredProcCommand("GetQuestions"))
                {

                    using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            QuestionModel u = new QuestionModel();
                            u.QuestionId = Convert.ToInt32(reader["QuestionId"]);
                            u.Title = (reader["Title"].ToString());
                            u.Question = (reader["QuestionBody"].ToString());
                            u.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                            u.AddedDate = Convert.ToDateTime(reader["AddedDate"]);
                            u.NoOfAnswers = Convert.ToInt32(reader["NoOfAnswers"]);
                             
                            l.Add(u);
                        }
                    }
                }
            }
            return l;
        }
        public static bool AddQuestion(QuestionModel u)
        {
            Database d = DatabaseConnection.Connection.Connect();
            {
                if (u.Question == null || u.Title == null)
                {
                    return false;
                }
                else
                {
                    using (DbCommand command = d.GetStoredProcCommand("AddQuestion"))
                    {
                        d.AddInParameter(command, "@QuestionBody", DbType.String, u.Question);
                        d.AddInParameter(command, "@CategoryId", DbType.String, u.CategoryId);
                        d.AddInParameter(command, "@Title", DbType.String, u.Title);
                        d.AddInParameter(command, "@UserId", DbType.String, u.UserId);
                      
                        using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                        {
                        }
                    }
                    return true;
                }
            }


        }
        public static List<QuestionModel> SearchQuestion(string searchString )
        {
            List<QuestionModel> qlist = new List<QuestionModel>();
            Database d = DatabaseConnection.Connection.Connect();
            {

                using (DbCommand command = d.GetStoredProcCommand("SearchQuestions"))
                {
                    d.AddInParameter(command, "@text", DbType.String, searchString);
                    using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            QuestionModel ques = new QuestionModel();
                            ques.Title = (reader["Title"].ToString());
                            ques.Question = ((reader["QuestionBody"].ToString()));
                            ques.QuestionId = (Convert.ToInt32(reader["QuestionId"]));
                            ques.UserId = (Convert.ToInt32(reader["UserId"]));
                            ques.NoOfAnswers = (Convert.ToInt32(reader["NoOfAnswers"]));
                            qlist.Add(ques);
                        }
                    }
                }

            }
            return qlist;

        }
        public static QuestionModel GetQuestionById(int qid)
        {
            QuestionModel ques = new QuestionModel();
            List<TagModel> taglis = GetTagsByQuestionById(qid);
            ques.tags = taglis;
            Database d = DatabaseConnection.Connection.Connect();
            {

                using (DbCommand command = d.GetStoredProcCommand("GetQuestionsById"))
                {
                    d.AddInParameter(command, "@questionid", DbType.String, qid);
                    using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            
                            ques.Title = (reader["Title"].ToString());
                            ques.Question = ((reader["QuestionBody"].ToString()));
                            ques.UserId= (Convert.ToInt32(reader["UserId"]));
                            ques.QuestionId = qid;
                        }
                    }
                }

            }
            return ques;

        }
        public static List<TagModel> GetTagsByQuestionById(int qid)
        {
            
            List<TagModel> tagList = new List<TagModel>();
            Database d = DatabaseConnection.Connection.Connect();
            {

                using (DbCommand command = d.GetStoredProcCommand("GetTagsByQuestionId"))
                {
                    d.AddInParameter(command, "@questionid", DbType.String, qid);
                    using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            TagModel tag = new TagModel();
                            tag.TagName = (reader["TagName"].ToString());
                            tagList.Add(tag);
                        }
                    }
                }

            }
            return tagList;

        }
        public static QuestionModel GetLastQuestion()
        {
            QuestionModel ques = new QuestionModel();
            List<QuestionModel> qlist = new List<QuestionModel>();
            Database d = DatabaseConnection.Connection.Connect();
            {

                using (DbCommand command = d.GetStoredProcCommand("GetLastQuestion"))
                {
                   
                    using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {

                          
                            ques.QuestionId = (Convert.ToInt32(reader["QuestionId"]));
                            //us.Email = ((reader["Email"].ToString()));
                        }
                    }
                }

            }
            return ques;

        }
        public static void AddNoOfAnswers(int qid)
        {
            Database d = DatabaseConnection.Connection.Connect();
            {

                using (DbCommand command = d.GetStoredProcCommand("AddNoOfAnswers"))
                {
                    d.AddInParameter(command, "@QuestionId", DbType.Int32, qid);
                    using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                        }
                    }
                }

            }


        }
        public static List<QuestionModel> GetQuestionsByCategory(string category)
        {

            List<QuestionModel> l = new List<QuestionModel>();

            Database d = DatabaseConnection.Connection.Connect();
            {

                using (DbCommand command = d.GetStoredProcCommand("GetQuestionByCategory"))
                {

                    d.AddInParameter(command, "@cat", DbType.String, category);
                    using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            QuestionModel u = new QuestionModel();
                            u.NoOfAnswers = Convert.ToInt32(reader["NoOfAnswers"]);
                            u.Title = (reader["Title"].ToString());
                            u.Question = (reader["QuestionBody"].ToString());
                            u.QuestionId = Convert.ToInt32(reader["QuestionId"]);
                            u.UserId = Convert.ToInt32(reader["UserId"]);
                            l.Add(u);
                        }
                    }
                }
            }
            return l;
        }
        public static List<QuestionModel> GetQuestionsByTag(string tag)
        {

            List<QuestionModel> l = new List<QuestionModel>();

            Database d = DatabaseConnection.Connection.Connect();
            {

                using (DbCommand command = d.GetStoredProcCommand("GetQuestionByTag"))
                {

                    d.AddInParameter(command, "@cat", DbType.String, tag);
                    using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            QuestionModel u = new QuestionModel();
                            u.NoOfAnswers = Convert.ToInt32(reader["NoOfAnswers"]);
                            u.Title = (reader["Title"].ToString());
                            u.Question = (reader["QuestionBody"].ToString());
                            u.QuestionId = Convert.ToInt32(reader["QuestionId"]);
                            u.UserId = Convert.ToInt32(reader["UserId"]);
                            l.Add(u);
                        }
                    }
                }
            }
            return l;
        }
    }
}