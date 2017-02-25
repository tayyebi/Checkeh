using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChekehApi.Controllers
{
    public class HumanIdentifierController : ApiController
    {
        DcDataContext dc = new DcDataContext();
        [Authenticate]
        public Guid GET(string Id)
        {
            return dc.vHuman_GetIdFromUsername(Id).FirstOrDefault().Id;
        }
    }
}
