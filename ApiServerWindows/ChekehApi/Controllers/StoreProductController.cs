using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace ChekehApi.Controllers
{
    public class StoreProductController : ApiController
    {

        DcDataContext dc = new DcDataContext();

        // GET: api/StoreProduct
        public IEnumerable<vProductAvailabiliityResult> Get(Guid Id) // Id is StoreId
        {
            return dc.vProductAvailabiliity(Id).ToList();
        }

        // POST: api/StoreProduct
        public HttpResponseMessage Post(FormDataCollection values)
        {
            try
            {
                bool wasAvailable = Convert.ToBoolean(values["Poseess"]);
                if (wasAvailable)
                {
                    dc.StoreProduct_Delete(new Guid(values["StoreId"]), new Guid(values["ProductId"]));
                }
                else
                {
                    dc.StoreProduct_Insert(new Guid(values["ProductId"]), new Guid(values["StoreId"]));
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

    }
}