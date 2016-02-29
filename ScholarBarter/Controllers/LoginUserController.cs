using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Security.Cryptography;
using System.Web.Http;
using ScholarBarter.Models.DataContexts;
using ScholarBarter.Library;

namespace ScholarBarter.Controllers
{
    public class LoginUserController : ApiController
    {
        [HttpPost]
        public string post(FormDataCollection formData)
        {   
            SessionsDataContext sdc = new SessionsDataContext();            
            Session s = new Session();

            try
            {
                string eduEmail = formData.Get("EduEmail");
                string passhash = formData.Get("PasswordHash");

                UsersDataContext dc = new UsersDataContext();
                var result =
                    from a in dc.GetTable<User>()
                    where a.EduEmail == eduEmail && a.PasswordHash.ToLower() == passhash.ToLower()
                    select a;

                if (result.Count() == 1)
                {
                    int id = result.First().UserId;

                    string pText = string.Format("{0}:{1}${2}",
                        id.ToString(), passhash, eduEmail);

                    s.UserId = id;
                    s.SessionKey = Md5Hasher.GetMd5Hash(pText).ToLower();
                    s.ValidationTime = DateTime.Now;

                    sdc.Sessions.InsertOnSubmit(s);
                    sdc.SubmitChanges();
                }
            }
            catch (Exception e)
            {
                
                return e.Message;
            }

            return s.SessionKey;
        }
    }

}
