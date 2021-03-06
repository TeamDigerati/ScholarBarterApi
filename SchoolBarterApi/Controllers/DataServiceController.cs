﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.OData;
using ScholarBarterApi.Model;
using ScholarBarterApi.Models;


namespace ScholarBarterApi.Controllers
{
    [EnableCors(origins: "http://www.scholarbarter.com", headers: "*", methods: "*")]
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
            var listingQuery = from ul in dc.UserListings
                               where ul.Active && ul.Enabled
                               select ul;

            var listings = listingQuery.ToList();
            HttpContext.Current.Response.Headers.Add("X-InlineCount", listings.Count.ToString(CultureInfo.InvariantCulture));
            return Request.CreateResponse(HttpStatusCode.OK, listings.AsQueryable());
        }

        [HttpGet]
        [EnableQuery]
        public HttpResponseMessage AllListings()
        {
            var listingQuery = from ul in dc.UserListings
                               where ul.Active && ul.Enabled
                               select ul;

            var listings = listingQuery.ToList();

            HttpContext.Current.Response.Headers.Add("X-InlineCount", listings.Count.ToString(CultureInfo.InvariantCulture));
            return Request.CreateResponse(HttpStatusCode.OK, listings.AsQueryable());
        }

        [HttpGet]
        [EnableQuery]
        public HttpResponseMessage ListingById(int id)
        {
            var listingQuery = from ul in dc.UserListings
                               where ul.ListingId == id && ul.Active && ul.Enabled
                               select ul;

            var listings = listingQuery.ToList();

            HttpContext.Current.Response.Headers.Add("X-InlineCount", listings.Count.ToString(CultureInfo.InvariantCulture));
            return Request.CreateResponse(HttpStatusCode.OK, listings.AsQueryable());
        }

        [HttpGet]
        [EnableQuery]
        public HttpResponseMessage ListingTypes()
        {
            var listingTypesQuery = from listingType in dc.ListingTypes
                                    where listingType.Active
                                    select listingType;

            var listingTypes = listingTypesQuery.ToList();
            HttpContext.Current.Response.Headers.Add("X-InlineCount", listingTypes.Count.ToString(CultureInfo.InvariantCulture));
            return Request.CreateResponse(HttpStatusCode.OK, listingTypes.AsQueryable());
        }


        [HttpPost]
        public HttpResponseMessage Login([FromBody]UserLogin userLogin)
        {
            var validUser =
              dc.Users.FirstOrDefault(
                   user => user.EduEmail == userLogin.UserName 
                       && user.PasswordHash == userLogin.Password
                       && user.Enabled);

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
            try
            {
                newUser.Enabled = false;
                newUser.Username = newUser.FirstName + newUser.LastName;
                newUser.Email = newUser.EduEmail;
                newUser.CreationTime = DateTime.Now;
                dc.Users.InsertOnSubmit(newUser);
                dc.SubmitChanges();

                EmailValidator.sendValidationEmail(newUser);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpGet]
        [EnableQuery]
        public HttpResponseMessage ActiveUsers()
        {
            var userQuery = from user in dc.Users
                            where user.Enabled
                            select user;
            var users = userQuery.ToList();

            foreach (User u in users)
                u.PasswordHash = "";

            HttpContext.Current.Response.Headers.Add("X-InlineCount", users.Count().ToString(CultureInfo.InvariantCulture));
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        [HttpGet]
        [EnableQuery]
        public HttpResponseMessage AllUsers()
        {
            var userQuery = from user in dc.Users
                            select user;

            var users = userQuery.ToList();
            foreach (User u in users)
                u.PasswordHash = "";

            HttpContext.Current.Response.Headers.Add("X-InlineCount", users.Count().ToString(CultureInfo.InvariantCulture));
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        [HttpGet]
        public HttpResponseMessage ValidateUser(int userId, string validationKey)
        {
            try
            {
                EmailValidator.validateUser(userId, validationKey);
            }
            catch (Exception e)
            {
                var errorResponse = Request.CreateErrorResponse(HttpStatusCode.ServiceUnavailable, e.Message);
                return errorResponse;
            }

            var user = from u in dc.Users
                       where u.UserId == userId
                       select u;

            user.First().Enabled = true;

            dc.SubmitChanges();

            var response = Request.CreateResponse(HttpStatusCode.Moved);
            response.Headers.Location = new Uri("http://www.scholarbarter.com");
            return response;
        }
    }
}
