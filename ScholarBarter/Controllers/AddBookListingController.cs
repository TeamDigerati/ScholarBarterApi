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
            ListingsManager.insertBookListing(formData);

            return "cool";
        }

    }
}
