﻿using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using ScholarBarter.Models;
using ScholarBarter.Models.DataContexts;
using ScholarBarter.Models.Exceptions;

namespace ScholarBarter.Controllers
{
    public class AllListingsController : ApiController
    {
        [HttpPost]
        public IEnumerable<Listing> post(FormDataCollection formData)
        {
            string key = formData.FirstOrDefault(a => a.Key == "sessionKey").Value;

            if (!SessionValidator.Validate(key))
                throw new InvalidSessionException();

            ListingsDataContext dc = new ListingsDataContext();

            var result =
                from a in dc.GetTable<Listing>()
                select a;

            return result;
        }
    }
}
