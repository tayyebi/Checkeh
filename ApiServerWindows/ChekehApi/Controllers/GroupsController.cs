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
    public class GroupsController : ApiController
    {
        DcDataContext dc = new DcDataContext();
        public IEnumerable<vGroup> Get()
        {
            return dc.vGroups.ToList();
        }

        // GET: api/Groups/5
        public vGroup Get(Guid id)
        {
            return dc.vGroups.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/Groups
        public HttpResponseMessage Post(FormDataCollection values)
        {
            try
            {
                dc.Group_Insert(values["Name"]);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch {

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }
        // DELETE: api/Groups/5
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                dc.Group_Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch {

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
