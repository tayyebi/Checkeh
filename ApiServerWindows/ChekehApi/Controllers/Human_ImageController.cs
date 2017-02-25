using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ChekehApi.Controllers
{
    public class Human_ImageController : ApiController
    {
        DcDataContext dc = new DcDataContext();
        [Authenticate]
        public HttpResponseMessage GET(string Id)
        {
            var image = dc.vHumans.Where(m => m.Id == new Guid(Id)).Select(z => z.Image).FirstOrDefault();

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                result.Content = new StreamContent(new MemoryStream(image.ToArray()));
            }
            catch {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            return result;
        }
    }
}
