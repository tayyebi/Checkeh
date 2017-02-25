using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChekehApi.Controllers
{
    public class AdminOwnerController : ApiController
    {
        DcDataContext dc = new DcDataContext();
        [Authenticate]
        // GET: api/AdminOwner/5
        public string Get(string id)
        {
            try
            {
                // id is username
                return dc.vAdminOwner_GetStatus(dc.vHuman_GetIdFromUsername(id).FirstOrDefault().Id).FirstOrDefault().Status;
            }
            catch { }
            return null;
        }
    }
}
