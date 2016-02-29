using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using ScholarBarter.Models.DataContexts;

namespace ScholarBarter.Models
{
    public class ListingsManager
    {
        internal static void insertBookListing(FormDataCollection formData){
            ListingsDataContext dc = new ListingsDataContext();

            Listing list = new Listing();

            list.CreationTime = DateTime.Now;
            list.Active = false;
            list.Description = "temp";
            list.ListingType = "book";
            list.Price = 45.4m;
            list.Title = "JABFS - Just Another Book For Sale";
            list.UserId = 1;

            dc.Listings.InsertOnSubmit(list);

            dc.SubmitChanges();
        }
    }
}