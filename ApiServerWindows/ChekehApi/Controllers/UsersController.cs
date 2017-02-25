using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace ChekehApi.Controllers
{
    public class UsersController : ApiController
    {
        DcDataContext dc = new DcDataContext();

        [Authenticate(IsAdmin = true)]
        public IEnumerable<vUser> Get()
        {
            return dc.vUsers.ToList();
        }

        // GET: api/Users/5

        [Authenticate]
        public vUser Get(Guid id)
        {
            return dc.vUsers.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/Users
        public HttpResponseMessage Post(FormDataCollection values)
        {
            try
            {
                dc.User_Insert(values["Username"], values["Password"], values["FirstName"], values["LastName"], null, values["PhoneNumber"]);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT: api/Users/5
        [Authenticate]
        public HttpResponseMessage Put(Guid id, FormDataCollection values)
        {
            try
            {
                dc.User_Update(id,values["Username"], values["Password"], values["FirstName"], values["LastName"], null, values["PhoneNumber"]);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}