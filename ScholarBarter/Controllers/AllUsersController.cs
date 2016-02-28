using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Helpers;
using System.Web.Http;
using ScholarBarter.Models;
using ScholarBarter.Models.DataContexts;
using ScholarBarter.Models.Exceptions;

namespace ScholarBarter.Controllers
{
    public class AllUsersController : ApiController
    {
        [HttpPost]
        public string post(FormDataCollection formData)
        {
            string key = formData.FirstOrDefault(a => a.Key == "sessionKey").Value;

            if (!SessionValidator.Validate(key))
                throw new InvalidSessionException();

            UsersPublicDataContext dc = new UsersPublicDataContext();

            var result =
                from a in dc.GetTable<PublicUser>()
                select a;

            return Json.Encode(result);
        }
    }
}
