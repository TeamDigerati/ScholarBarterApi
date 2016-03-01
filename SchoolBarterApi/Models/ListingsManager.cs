using System;
using System.Net.Http.Formatting;
using ScholarBarterApi;

namespace ScholarBarter.Models
{
    public class ListingsManager
    {
        internal static void insertBookListing(FormDataCollection fd)
        {
            {
                DataClassesDataContext dc = new DataClassesDataContext();
                               
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
                    
                    dc.Books.InsertOnSubmit(bk);
                    dc.SubmitChanges();
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