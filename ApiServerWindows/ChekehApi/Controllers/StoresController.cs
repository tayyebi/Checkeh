using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace ChekehApi.Controllers
{
    [Authenticate]
    public class StoresController : ApiController
    {
        DcDataContext dc = new DcDataContext();
        // GET: api/Store
        public IEnumerable<vStore> Get(Guid Id) //OwnerId
        {
            var query = (from a in dc.vStores where a.OwnerId == Id select new vStore { StoreId = a.StoreId, StoreName = a.StoreName }).ToList();
            return query;
        }

        // POST: api/Store
        public HttpResponseMessage Post(FormDataCollection values)
        {
            try
            {
                dc.Store_Insert(values["Address"], values["postalCode"], new Guid(values["cityId"]), values["Name"],new Guid(values["OwnerId"]));
                return Request.CreateResponse(HttpStatusCode.OK);

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT: api/Store
        public HttpResponseMessage Put(Guid id,FormDataCollection values)
        {
            try
            {
                dc.Store_Update(id, values["name"], values["Address"], values["postalCode"], new Guid(values["cityId"]));
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE: api/Store/5
        public HttpResponseMessage Delete(Guid Id) //StoreId
        {
            try
            {
                dc.Store_Delete(Id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            }
        }
    }
}