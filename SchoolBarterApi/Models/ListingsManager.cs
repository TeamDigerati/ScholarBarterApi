using System;
using System.Net.Http.Formatting;
using ScholarBarterApi;
using ScholarBarterApi.DataClasses;

namespace ScholarBarter.Models
{
    public class ListingsManager
    {
        internal static void insertBookListing(FormDataCollection fd)
        {
            {
                ListingsDataContext dc = new ListingsDataContext();
                BooksDataContext bc = new BooksDataContext();
               
                Listing lstng = new Listing();
                lstng.CreationTime = DateTime.Now;
                lstng.Active = true;
                lstng.Description = fd.Get("Description");
                lstng.ListingType = "book";
                lstng.Price = Convert.ToDecimal(fd.Get("Price"));
                lstng.Title = fd.Get("Title");
                lstng.UserId = Convert.ToInt32(fd.Get("UserId"));

                dc.Listings.InsertOnSubmit(lstng);
                dc.SubmitChanges();

              try
                {   
                    Book bk = new Book();
                    bk.ListingId = lstng.ListingId;
                    bk.Condition = fd.Get("Condition");
                    bk.Isbn10 = fd.Get("Isbn10");
                    
                    bc.Books.InsertOnSubmit(bk);
                    bc.SubmitChanges();
                }
                catch (Exception)
                {
                    dc.Listings.DeleteOnSubmit(lstng);
                    dc.SubmitChanges();
                    throw;
                }
            }
        }
    }
}