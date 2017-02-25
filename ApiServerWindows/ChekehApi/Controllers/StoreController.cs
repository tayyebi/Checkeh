using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChekehApi.Controllers
{
    [Authenticate]
    public class StoreController : ApiController
    {
        DcDataContext dc = new DcDataContext();
        // GET: api/Store/5
        public vStore Get(Guid Id) // StoreId
        {
            return (from a in dc.vStores where a.StoreId == Id select a).FirstOrDefault();
        }
    }
}
