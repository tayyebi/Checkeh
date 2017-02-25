using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ChekehApi.Controllers
{
    [Authenticate(IsAdmin = true)]
    public class ProductsController : ApiController
    {
        DcDataContext dc = new DcDataContext();
        // GET: api/Products
        public IEnumerable<vProduct> Get()
        {
            return dc.vProducts;
        }

        // GET: api/Products/5
        public vProduct Get(Guid id)
        {
            return dc.vProducts.Where(x => x.ProductId == id).Select(x => new vProduct { ProductId = x.ProductId, ProductName = x.ProductName, ProductDescription = x.ProductDescription }).FirstOrDefault();
        }

        // POST: api/Products
        public HttpResponseMessage Post(FormDataCollection values)
        {
            try
            {
                dc.Product_Update(new Guid(values["Id"]), values["Name"], null, values["Description"], new Guid(values["GroupId"]));
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public async Task<HttpResponseMessage> Put(Guid id)
        {
            try
            {
                var values = HttpContext.Current.Request;

                byte[] bytes = null;
                if (values.Files.Count > 0)
                {
                   using (var binaryReader = new BinaryReader(values.Files[0].InputStream))
                    {
                        bytes = binaryReader.ReadBytes(values.Files[0].ContentLength);
                    }
                }
                dc.Product_Update (id, values["Name"], new System.Data.Linq.Binary(bytes), values["Description"], new Guid(values["GroupId"]));
                return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
            }
            catch
            {
                return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest };
            }
        }

        // DELETE: api/Products/5
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                dc.Product_Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}