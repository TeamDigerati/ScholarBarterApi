using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using ScholarBarterApi.Model;

namespace ScholarBarterApi.Controllers
{
    public class DataServiceController : ApiController
    {
        private DataClassesDataContext dc;

        public DataServiceController()
        {
            dc = new DataClassesDataContext();
        }

        [HttpGet]
        [EnableQuery]
        public HttpResponseMessage ActiveListings()
        {
            var listingQuery = from user in dc.Users
                               join listing in dc.Listings
                               on user.UserId equals listing.UserId
                               where listing.Active && user.Enabled
                               select new { listing, user.FirstName, user.LastName };

            var listings = listingQuery.ToList();
            HttpContext.Current.Response.Headers.Add("X-InlineCount", listings.Count.ToString(CultureInfo.InvariantCulture));
            return Request.CreateResponse(HttpStatusCode.OK, listings.AsQueryable());
        }

        [HttpGet]
        [EnableQuery]
        public HttpResponseMessage AllListings()
        {
            var listings = from user in dc.Users
                           join listing in dc.Listings
                           on user.UserId equals listing.UserId
                           select new { listing, user.FirstName, user.LastName };

            HttpContext.Current.Response.Headers.Add("X-InlineCount", listings.ToList().Count.ToString(CultureInfo.InvariantCulture));
            return Request.CreateResponse(HttpStatusCode.OK, listings.AsQueryable());
        }

        [HttpGet]
        [EnableQuery]
        public HttpResponseMessage ListingTypes()
        {
            var listingTypesQuery = from listingType in dc.ListingTypes
                                    where listingType.Active
                                    select new { listingType.Type, listingType.Description };

            var listingTypes = listingTypesQuery.ToList();
            HttpContext.Current.Response.Headers.Add("X-InlineCount", listingTypes.Count.ToString(CultureInfo.InvariantCulture));
            return Request.CreateResponse(HttpStatusCode.OK, listingTypes.AsQueryable());
        }

        [HttpPost]
        public HttpResponseMessage Login([FromBody]UserLogin userLogin)
        {
            var validUser =
              dc.Users.FirstOrDefault(user => user.EduEmail == userLogin.UserName && user.PasswordHash == userLogin.Password);
            return Request.CreateResponse(HttpStatusCode.OK, validUser);
        }

        [HttpPost]
        public HttpResponseMessage AddListing([FromBody]Listing newListing)
        {
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
            var user = dc.Users.FirstOrDefault(u => u.UserId == id);
            user.PasswordHash = "";
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpPost]
        public HttpResponseMessage AddUser([FromBody]User newUser)
        {
            // TODO: add validator email
            try
            {
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
            var userQuery = from user in dc.Users
                            where user.Enabled
                            select new { user.UserId, user.FirstName, user.LastName, user.EduEmail, user.Gender };
            var users = userQuery.ToList();

            HttpContext.Current.Response.Headers.Add("X-InlineCount", users.Count().ToString(CultureInfo.InvariantCulture));
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        [HttpGet]
        [EnableQuery]
        public HttpResponseMessage AllUsers()
        {
            var userQuery = from user in dc.Users
                            select new { user.UserId, user.FirstName, user.LastName, user.EduEmail, user.Gender };
            var users = userQuery.ToList();

            HttpContext.Current.Response.Headers.Add("X-InlineCount", users.Count().ToString(CultureInfo.InvariantCulture));
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }
    }
}
