using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;

namespace ChekehApi.Controllers
{
    public class Owner
    {
        public Guid Identifier { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string NationalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }

        public HttpPostedFile Image { get; set; }
    }

    public class OwnerController : ApiController
    {
        [Authenticate]
        public Owner Get(Guid id)
        {
            var query = (from a in dc.vOwners where a.Id == id select a).FirstOrDefault();
            Owner owner = new Owner();
            owner.Identifier = query.Id;
            owner.Username = query.Username;
            owner.Password = null;
            owner.NationalCode = query.NationalCode;
            owner.FirstName = query.FirstName;
            owner.LastName = query.LastName;
            owner.Address = query.Address;
            owner.PostalCode = query.PostalCode;
            owner.PhoneNumber = query.PhoneNumber;
            return owner;
        }

        DcDataContext dc = new DcDataContext();
        public HttpResponseMessage Post([FromBody] Owner value)
        {
            try
            {
                byte[] data = null;
                if (value.Image != null)
                {
                    MemoryStream target = new MemoryStream();
                    value.Image.InputStream.CopyTo(target);
                    data = target.ToArray();
                }
                dc.Owner_Insert(value.Username, value.Password, value.FirstName, value.LastName, data, value.NationalCode, value.Address, value.PostalCode, value.PhoneNumber);

                return Request.CreateResponse(HttpStatusCode.OK, value);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        //        [Authenticate]
        public HttpResponseMessage Put(Guid id, FormDataCollection values)
        {
            try
            {
                Owner value = new Owner { FirstName = values["FirstName"], Address = values["Address"], Identifier = id, LastName = values["LastName"], NationalCode = values["NationalCode"], Password = values["Password"], PhoneNumber = values["PhoneNumber"], PostalCode = values["PostalCode"], Username = values["Username"] };
                byte[] data = null;
                if (value.Image != null)
                {
                    MemoryStream target = new MemoryStream();
                    value.Image.InputStream.CopyTo(target);
                    data = target.ToArray();
                }
                dc.Owner_Update(id, value.Username, value.Password, value.FirstName, value.LastName, data, value.NationalCode, value.Address, value.PostalCode, value.PhoneNumber);
                return Request.CreateResponse(HttpStatusCode.OK, value);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}