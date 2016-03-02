using System;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using ScholarBarterApi.Model;
using ScholarBarterApi.DataClasses;

namespace ScholarBarterApi.Controllers
{
    public class DataServiceController : ApiController
    {
        [HttpGet]
        [EnableQuery]
        public HttpResponseMessage ActiveListings()
        {
            ListingsDataContext dc = new ListingsDataContext();
            var listings = dc.Listings.Where(listing => listing.Active).ToList();
            HttpContext.Current.Response.Headers.Add("X-InlineCount", listings.Count.ToString(CultureInfo.InvariantCulture));
            return Request.CreateResponse(HttpStatusCode.OK, listings.AsQueryable());
        }

        [HttpGet]
        [EnableQuery]
        public HttpResponseMessage AllListings()
        {
            ListingsDataContext dc = new ListingsDataContext();
            var listings = dc.Listings.ToList();
            HttpContext.Current.Response.Headers.Add("X-InlineCount", listings.Count.ToString(CultureInfo.InvariantCulture));
            return Request.CreateResponse(HttpStatusCode.OK, listings.AsQueryable());
        }

        [HttpGet]
        [EnableQuery]
        public HttpResponseMessage ListingTypes()
        {
            ListingTypesDataContext dc = new ListingTypesDataContext();
            var listingTypes = dc.ListingTypes.Where(lt => lt.Active).ToList();
            HttpContext.Current.Response.Headers.Add("X-InlineCount", listingTypes.Count.ToString(CultureInfo.InvariantCulture));
            return Request.CreateResponse(HttpStatusCode.OK, listingTypes.AsQueryable());
        }

        [HttpPost]
        public HttpResponseMessage Login([FromBody]UserLogin userLogin)
        {
            UsersDataContext dc = new UsersDataContext();
            var validUser =
              dc.Users.FirstOrDefault(user => user.EduEmail == userLogin.UserName && user.PasswordHash == userLogin.Password);
            return Request.CreateResponse(HttpStatusCode.OK, validUser);
        }

        [HttpPost]
        public HttpResponseMessage AddListing([FromBody]Listing newListing)
        {
            ListingsDataContext dc = new ListingsDataContext();
            try
            {
                newListing.Active = true;
                newListing.CreationTime = DateTime.Now;
                dc.Listings.InsertOnSubmit(newListing);
                dc.SubmitChanges();
                return Request.CreateResponse(HttpStatusCode.Created, newListing);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage UserById(int id)
        {
            UsersDataContext dc = new UsersDataContext();
            var user = dc.Users.FirstOrDefault(u => u.UserId == id);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpPost]
        public HttpResponseMessage AddUser([FromBody]User newUser)
        {
            // TODO: add validator email
            try
            {
                UsersDataContext dc = new UsersDataContext();
                newUser.Enabled = false;
                newUser.CreationTime = DateTime.Now;
                dc.Users.InsertOnSubmit(newUser);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.Created, newUser);
        }
        
        [HttpGet]
        [EnableQuery]
        public HttpResponseMessage ActiveUsers()
        {
            UsersDataContext dc = new UsersDataContext();
            var users = dc.Users.Where(u => u.Enabled).ToList();

            foreach(User u in users)
                u.PasswordHash = "";

            HttpContext.Current.Response.Headers.Add("X-InlineCount", users.Count().ToString(CultureInfo.InvariantCulture));
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        [HttpGet]
        [EnableQuery]
        public HttpResponseMessage AllUsers()
        {
            UsersDataContext dc = new UsersDataContext();
            var users = dc.Users.ToList();

            foreach (User u in users)
                u.PasswordHash = "";
            
            HttpContext.Current.Response.Headers.Add("X-InlineCount", users.Count().ToString(CultureInfo.InvariantCulture));
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }
    }
}
