using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace ChekehApi.Controllers
{
    [Authenticate(IsAdmin = true)]
    public class CitiesController : ApiController
    {
        DcDataContext dc = new DcDataContext();

        // GET: api/Cities
        public IEnumerable<vCity> Get()
        {
            return dc.vCities;
        }

        // GET: api/Cities/5
        public vCity Get(Guid id)
        {
            return dc.vCities.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/Cities
        public HttpResponseMessage Post(FormDataCollection values)
        {
            try
            {
                dc.City_Insert(values["name"]);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT: api/Cities/5
        public HttpResponseMessage Put(Guid id, FormDataCollection values)
        {
            try
            {
                dc.City_Update(id, values["name"]);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE: api/Cities/5
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                dc.City_Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
