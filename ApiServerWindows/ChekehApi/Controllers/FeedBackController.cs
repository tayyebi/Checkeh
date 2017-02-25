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
    public class FeedBackController : ApiController
    {
        public DcDataContext dc = new DcDataContext();

        public IEnumerable<vFeedBack> GET(Guid Id) // Id is reciver
        {
            try {
                if (dc.vHuman_GetType(Id).FirstOrDefault().UserType.ToString() == "admin")
                    return (from a in dc.vFeedBacks select new vFeedBack { SenderId = a.SenderId, Id = a.Id, Value = a.Value }).OrderByDescending(m => m.Id).Take(10).OrderBy(n => n.Id);

                else return (from a in dc.vFeedBacks where (a.ReciverId == Id || a.SenderId == Id) select new vFeedBack { SenderId = a.SenderId, Id = a.Id, Value = a.Value }).OrderByDescending(m => m.Id).Take(10).OrderBy(n => n.Id);
            }
            catch
            {
                return null;
            }
        }
        public HttpResponseMessage POST(Guid Id, FormDataCollection values) // Id is sender
        {
            try
            {
                if (values["ReciverId"] != "00000000-0000-0000-0000-000000000000")
                    dc.FeedBack_Insert(Id, new Guid(values["ReciverId"]), values["Value"].ToString());
                else if (values["ReciverId"] == "00000000-0000-0000-0000-000000000000")
                    dc.FeedBack_Insert(Id, null, values["Value"].ToString());
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}