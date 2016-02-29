using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web;
using ScholarBarter.Models.DataContexts;

namespace ScholarBarter.Models
{
    public class ListingsManager
    {
        internal static void insertBookListing(FormDataCollection fd)
        {
            {
                ListingsDataContext lc = new ListingsDataContext();
                               
                Listing lstng = new Listing();
                lstng.CreationTime = DateTime.Now;
                lstng.Active = true;
                lstng.Description = fd.Get("Description");
                lstng.ListingType = "book";
                lstng.Price = Convert.ToDecimal(fd.Get("Price"));
                lstng.Title = fd.Get("Title");
                lstng.UserId = Convert.ToInt32(fd.Get("UserId"));

                lc.Listings.InsertOnSubmit(lstng);
                lc.SubmitChanges();

              try
                {   
                    BooksDataContext bc = new BooksDataContext();

                    Book bk = new Book();
                    bk.ListingId = lstng.ListingId;
                    bk.Condition = fd.Get("Condition");
                    bk.Isbn10 = fd.Get("Isbn10");
                    
                    bc.Books.InsertOnSubmit(bk);
                    bc.SubmitChanges();
                }
                catch (Exception)
                {
                    lc.Listings.DeleteOnSubmit(lstng);
                    lc.SubmitChanges();
                    throw;
                }
            }
        }
    }
}