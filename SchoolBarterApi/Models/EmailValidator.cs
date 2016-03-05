using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScholarBarter.Models;
using ScholarBarterApi.Model;

namespace ScholarBarterApi.Models
{
    public class EmailValidator
    {
        public static void sendValidationEmail(User user)
        {
            string ValidationKey = getNewValidationKey(user);
            string emailAddress = user.EduEmail;
            if (Email.isValid(emailAddress) && emailAddress.EndsWith("edu", StringComparison.InvariantCultureIgnoreCase))
                sendValidEmail(user);
            else
                sendInvalidEmail(user);
        }

        private static void sendInvalidEmail(User user)
        {
            Email e = new Email();
            if(Email.isValid(user.EduEmail))
            {
                e.From = "support@scholarbarter.com";
                e.To = user.EduEmail;
                e.Subject = "ScholarBarter Account Validation Email";
                e.Body =
                    "Thank you for joining ScholarBarter<br/><br/>" +
                    "Unfortunately, ScholarBarter only accepts verifiable university email addresses.<br/><br/>" +
                    "Please create a new account with your university email address<br/><br/>"+
                    "Thank you for choosing ScholarBarter<br/>";
                e.send();
            }
        }

        private static void sendValidEmail(User user)
        {
            Email e = new Email();
            string ValidationKey = getNewValidationKey(user);
            string validationLink = string.Format(
                "<a href='http://api.scholarbarter.com:8080/api/dataservice/validateuser?userid={0}&validationkey={1}'>Validate Me</a>",
                user.UserId, ValidationKey);

            e.From = "support@scholarbarter.com";
            e.To = user.EduEmail;
            e.Subject = "ScholarBarter Account Validation Email";
            e.Body = string.Format(
                "Thank you for joining ScholarBarter<br/>" +
                "Please click on the following link to validate your account: <br/><br/>" +
                "{0} <br/><br/>" +
                "This link will activate your account and return you to ScholarBarter.com<br/>",
                validationLink);
            e.send();
        }

        private static string getNewValidationKey(User user)
        {
            DataClassesDataContext dc = new DataClassesDataContext();
            AccountValidation av = new AccountValidation();

            av.UserId = user.UserId;
            av.ValidationKey = Md5Hasher.GetMd5Hash(
                user.UserId.ToString() + user.PasswordHash
                );
            av.CreationTime = DateTime.Now;

            dc.AccountValidations.InsertOnSubmit(av);
            dc.SubmitChanges();

            return av.ValidationKey;
        }

        public static void validateUser(int userId, string validationKey)
        {
            DataClassesDataContext dc = new DataClassesDataContext();
            var valid = from v in dc.AccountValidations
                             where v.UserId == userId && v.ValidationKey == validationKey && v.ValidationTime == null
                             select v;
            
            if (valid.ToList().Count == 1)
            {
                valid.First().ValidationTime = DateTime.Now;

                dc.SubmitChanges();
            }        
        }
    }
}