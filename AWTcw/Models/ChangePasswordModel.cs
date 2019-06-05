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
    public class ChangePasswordModel
    {

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public static void UpdatePassword(ChangePasswordModel cha, string email)
        {
            Database d = DatabaseConnection.Connection.Connect();
            {
                string oldhashpassword = UserModel.EncryptPassword(cha.OldPassword);
                string newhashpassword = UserModel.EncryptPassword(cha.NewPassword);

                using (DbCommand command = d.GetStoredProcCommand("UpdatePassword"))
                {
                    d.AddInParameter(command, "@OldPassword", DbType.String, oldhashpassword);
                    d.AddInParameter(command, "@Password", DbType.String, newhashpassword);
                    d.AddInParameter(command, "@Email", DbType.String, email);
                    using (IDataReader reader = (IDataReader)d.ExecuteReader(command))
                    {
                        while (reader.Read())
                        {

                        }
                    }
                }

            }


        }
    }
}