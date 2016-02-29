using System;
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
    public class AddBookListingController : ApiController
    {
        [HttpPost]
        public string post(FormDataCollection formData)
        {
            try
            {
                ListingsManager.insertBookListing(formData);
            }
            catch (Exception e)
            {
                return string.Format(
                    "Could not add the book. The following error was given: {0}",
                    e.Message);
            }

            return "Success";
        }

    }
}
