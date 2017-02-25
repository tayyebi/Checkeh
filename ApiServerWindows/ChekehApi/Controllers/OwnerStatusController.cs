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
    public class OwnerStatusController : ApiController
    {
        DcDataContext dc = new DcDataContext();
        public IEnumerable<vOwnerStatus> GET(string id = "NotConfirmed") // id is show all or not
        {
            var query = (from a in dc.vOwnerStatus select new vOwnerStatus { Id = a.Id, Username = a.Username, Status = a.Status });

            if (id == "Confirmed")
            {
                query = query.Where(a => a.Status == "Confirmed");
            }
            else if (id == "NotConfirmed")
            {
                query = query.Where(a => a.Status == "NotConfirmed");
            }
            return query.ToList();

        }
        public HttpResponseMessage POST(Guid id, FormDataCollection values) // id is ownerId
        {
            try
            {
                dc.vAdminOwner_SetStatus(id, null, values["Status"]);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}