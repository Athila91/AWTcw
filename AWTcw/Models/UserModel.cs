using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Data.Common;
using System.Data;
using System.Text;
using System.IO;

using System.Web.WebPages.Html;

namespace AWTcw.Models
{
    public class UserModel
    {

        public int UserId { get; set; }
        public int Reputation { get; set; }
        public int LoyaltyPoints { get; set; }
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        //[StringLength(100, ErrorMessage = "Enter the last name.", MinimumLength = 1)]
        //[DataType(DataType.Text)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string LoginPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Keep me logged in")]
        public bool IsLoggedin { get; set; }

        
        //[StringLength(100, ErrorMessage = "Enter the first name.", MinimumLength = 1)]
        //[DataType(DataType.Text)]
        
        public int TypeId { get; set; }

       

        public static UserModel GetUserDetails(UserModel u)
        {
            Database d = DatabaseConnection.Connection.Connect();
            {

                using (DbCommand command = d.GetStoredProcCommand("CheckPassword"))
                {
                    d.AddInParameter(command, "@Email", DbType.String, u.Email);
                    using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {

                            u.FirstName = (reader["FirstName"].ToString());
                            u.LastName = (reader["LastName"].ToString());
                            u.Password = ((reader["Password"].ToString()));
                            u.UserId = (Convert.ToInt32(reader["UserId"]));
                            u.TypeId = (Convert.ToInt32(reader["TypeId"]));
                            //us.Email = ((reader["Email"].ToString()));
                        }
                    }
                }

            }
            return u;

        }
        public static bool CheckPassword(UserModel us)
        {
            string tempPassword = "";
            UserModel u = GetUserDetails(us);
            if (us.LoginPassword != null)
            {
                tempPassword = EncryptPassword(us.LoginPassword);
            }
            u.LoginPassword = tempPassword;
            if (tempPassword == u.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckExistingUser(UserModel us)
        {
          
            string temp = us.Email;
            UserModel u = new UserModel();
            Database d = DatabaseConnection.Connection.Connect();
            {

                using (DbCommand command = d.GetStoredProcCommand("CheckExistingUser"))
                {
                    d.AddInParameter(command, "@Email", DbType.String, us.Email);

                    using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {

                            u.FirstName = (reader["FirstName"].ToString());
                            u.Password = ((reader["Password"].ToString()));
                            u.Email = ((reader["Email"].ToString()));
                            u.Reputation= Convert.ToInt32((reader["Reputation"]));
                            u.LoyaltyPoints = Convert.ToInt32((reader["LoyaltyPoints"]));
                            u.LastName = ((reader["LastName"].ToString()));
                        }
                    }
                }
                if (us.Email == u.Email)
                {
                    return false;
                }
                else if (us.ConfirmPassword == null || us.FirstName == null || us.LastName == null || us.Password == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }
        public static bool RegisterUser(UserModel u)
        {
            bool tmpbool = CheckExistingUser(u);
            if (tmpbool)
            {

                string hashpassword = EncryptPassword(u.Password);
                Database d = DatabaseConnection.Connection.Connect();
                {

                    using (DbCommand command = d.GetStoredProcCommand("RegisterUser"))
                    {
                        d.AddInParameter(command, "@FirstName", DbType.String, u.FirstName);
                        d.AddInParameter(command, "@LastName", DbType.String, u.LastName);
                        d.AddInParameter(command, "@Email", DbType.String, u.Email);
                        d.AddInParameter(command, "@Password", DbType.String, hashpassword);
                        d.AddInParameter(command, "@Typeid", DbType.String, u.TypeId);
                        //d.AddInParameter(command, "@TypeId", DbType.String, u.);
                        using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                        {
                            //while (reader.Read())
                            //{
                            //    u.Email = (reader["Email"].ToString());
                            //    u.Password = ((reader["Password"].ToString()));
                            //}
                        }
                    }
                    return true;
                }
            }
            else
            {
                return false;

            }
        }
        public static void UpdateUser(UserModel u, string str)
        {
           

                string hashpassword = EncryptPassword(u.Password);
                Database d = DatabaseConnection.Connection.Connect();
                {

                    using (DbCommand command = d.GetStoredProcCommand("UpdateUserDetails"))
                    {
                        d.AddInParameter(command, "@FirstName", DbType.String, u.FirstName);
                        d.AddInParameter(command, "@LastName", DbType.String, u.LastName);
                        d.AddInParameter(command, "@Email", DbType.String, str);
                        d.AddInParameter(command, "@NewEmail", DbType.String, u.Email);
                        //d.AddInParameter(command, "@TypeId", DbType.String, u.);
                        using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                        {
                            //while (reader.Read())
                            //{
                            //    u.Email = (reader["Email"].ToString());
                            //    u.Password = ((reader["Password"].ToString()));
                            //}
                        }
                    }
                   
            }
           
        }

        public static void AddReputationPoints(int rep)
        {
            Database d = DatabaseConnection.Connection.Connect();
            {

                using (DbCommand command = d.GetStoredProcCommand("AddReputation"))
                {
                    d.AddInParameter(command, "@UserId", DbType.Int32, rep);
                    using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {

                            //u.FirstName = (reader["FirstName"].ToString());
                            //u.Password = ((reader["Password"].ToString()));
                            //u.UserId = (Convert.ToInt32(reader["UserId"]));
                            //us.Email = ((reader["Email"].ToString()));
                        }
                    }
                }

            }
            

        }
        public static void AddLoyaltyPoints(int rep)
        {
            Database d = DatabaseConnection.Connection.Connect();
            {

                using (DbCommand command = d.GetStoredProcCommand("AddLoyaltyPoints"))
                {
                    d.AddInParameter(command, "@UserId", DbType.Int32, rep);
                    using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {

                            //u.FirstName = (reader["FirstName"].ToString());
                            //u.Password = ((reader["Password"].ToString()));
                            //u.UserId = (Convert.ToInt32(reader["UserId"]));
                            //us.Email = ((reader["Email"].ToString()));
                        }
                    }
                }

            }


        }
        public static string EncryptPassword(string password)
        {
            //byte[] data = new byte[password];
            //byte[] result;

            //SHA1 sha = new SHA1CryptoServiceProvider();
            //// This is one implementation of the abstract class SHA1.
            //result = sha.ComputeHash(data);
            string pass = "";
            if(password != "")
            {
                using (System.Security.Cryptography.SHA256 mySHA256 = System.Security.Cryptography.SHA256.Create())
                {
                    var data = System.Text.Encoding.ASCII.GetBytes(password);
                    data = System.Security.Cryptography.SHA1.Create().ComputeHash(data);
                     pass = Convert.ToBase64String(data);
                     
                    //byte[] data = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(password));
                    //////data.ToString();
                    //StringBuilder sBuilder = new StringBuilder();

                    ////// Loop through each byte of the hashed data  
                    ////// and format each one as a hexadecimal string. 
                    //for (int i = 0; i < data.Length; i++)
                    //{
                    //    sBuilder.Append(data[i].ToString("x1"));
                    //}
                    //////string hashedpassword = data.ToString();
                    //return sBuilder.ToString();
                }
            }
            //byte[] hash = System.Security.Cryptography.MD5.(password);
            //string hashString = System.Security.Cryptography.MD5
            return pass;


        }
        public static void AddSessionId(string ses)
        {
            Database d = DatabaseConnection.Connection.Connect();
            {

                using (DbCommand command = d.GetStoredProcCommand("AddSessionId"))
                {
                    d.AddInParameter(command, "@sessionid", DbType.String, ses);
                    using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {

                            //u.FirstName = (reader["FirstName"].ToString());
                            //u.Password = ((reader["Password"].ToString()));
                            //u.UserId = (Convert.ToInt32(reader["UserId"]));
                            //us.Email = ((reader["Email"].ToString()));
                        }
                    }
                }

            }


        }
        public static string GetSessionId()
        {
            string sesid = "";
            Database d = DatabaseConnection.Connection.Connect();
            {

                using (DbCommand command = d.GetStoredProcCommand("GetSessionId"))
                {
                    //d.AddInParameter(command, "@sessionid", DbType.String, ses);
                    using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {
                            sesid = (reader["SessionId"].ToString());
                            
                        }
                    }
                }

            }

            return sesid;
        }
    }
}