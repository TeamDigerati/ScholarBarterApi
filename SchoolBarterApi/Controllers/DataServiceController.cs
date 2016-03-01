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

namespace ScholarBarterApi.Controllers
{
    public class DataServiceController : ApiController
    {
        private readonly DataClassesDataContext _dc;

        public DataServiceController()
        {
            _dc = new DataClassesDataContext(ConfigurationManager.ConnectionStrings["ApiConnectionString"].ConnectionString);
        }

        [HttpGet]
        [EnableQuery]
        public HttpResponseMessage Listings()
        {
            var listings = _dc.Listings.Where(listing => listing.Active).ToList();
            HttpContext.Current.Response.Headers.Add("X-InlineCount", listings.Count.ToString(CultureInfo.InvariantCulture));
            return Request.CreateResponse(HttpStatusCode.OK, listings.AsQueryable());
        }

        [HttpGet]
        [EnableQuery]
        public HttpResponseMessage ListingTypes()
        {
            var listingTypes = _dc.ListingTypes.ToList();
            HttpContext.Current.Response.Headers.Add("X-InlineCount", listingTypes.Count.ToString(CultureInfo.InvariantCulture));
            return Request.CreateResponse(HttpStatusCode.OK, listingTypes.AsQueryable());
        }

        [HttpPost]
        public HttpResponseMessage Login([FromBody]UserLogin userLogin)
        {
            var validUser =
              _dc.Users.FirstOrDefault(user => user.EduEmail == userLogin.UserName && user.PasswordHash == userLogin.Password);
            return Request.CreateResponse(HttpStatusCode.OK, validUser);
        }

        [HttpPost]
        public HttpResponseMessage AddListing([FromBody]Listing newListing)
        {
            try
            {
                newListing.Active = true;
                newListing.CreationTime = DateTime.Now;
                _dc.Listings.InsertOnSubmit(newListing);
                _dc.SubmitChanges();
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
            var user = _dc.Users.FirstOrDefault(u => u.UserId == id);
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
                _dc.Users.InsertOnSubmit(newUser);
                _dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.Created, newUser);
        }
        
        [HttpGet]
        [EnableQuery]
        public HttpResponseMessage GetActiveUsers()
        {
            var users = _dc.Users.Where(u => u.Enabled).ToList();

            foreach(User u in users)
                u.PasswordHash = "";

            HttpContext.Current.Response.Headers.Add("X-InlineCount", users.Count().ToString(CultureInfo.InvariantCulture));
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        [HttpGet]
        [EnableQuery]
        public HttpResponseMessage GetAllUsers()
        {
            var users = _dc.Users.ToList();

            foreach (User u in users)
                u.PasswordHash = "";
            
            HttpContext.Current.Response.Headers.Add("X-InlineCount", users.Count().ToString(CultureInfo.InvariantCulture));
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }
    }
}
