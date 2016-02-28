using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Helpers;
using System.Web.Http;
using ScholarBarter.Models;
using ScholarBarter.Models.DataContexts;
using ScholarBarter.Models.Exceptions;

namespace ScholarBarter.Controllers
{
    public class AllBookListingsController : ApiController
    {
       [HttpPost]
        public string post(FormDataCollection formData)
        {
            string key = formData.FirstOrDefault(a => a.Key == "sessionKey").Value;

            if (!SessionValidator.Validate(key))
                throw new InvalidSessionException();

            BookListingsDataContext dc = new BookListingsDataContext();

            var result =
                from b in dc.GetTable<BookListing>()
                select b;

            return Json.Encode(result);
        }
    }
}
