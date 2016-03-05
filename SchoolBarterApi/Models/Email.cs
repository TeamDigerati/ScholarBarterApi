using System;
using System.ComponentModel.DataAnnotations;
using Simplify.Mail;
using ScholarBarter.Models.Exceptions;

namespace ScholarBarter.Models
{
    public class Email
    {
        public string From { set; get; }
        public string To { set; get; }
        public string Subject { set; get; }
        public string Body { set; get; }

        public void send()
        {
            if (Email.isValid(To) && Email.isValid(From))
            {
                MailSender sndr = new MailSender();
                sndr.Send(From, To, Subject, Body);
            }
            else
            {
                throw new InvalidEmailException();
            }
        }

        public static bool isValid(string address)
        {
            var validator = new EmailAddressAttribute();

            return (validator.IsValid(address));
            
        }
    }
}