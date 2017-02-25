using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChekehApi.Controllers
{
    public class DownloadController : Controller
    {
        DcDataContext dc = new DcDataContext();
        // GET: Download
        public ActionResult ProductImage(Guid id)
        {
            var file = dc.vProducts.Where(y => y.ProductId == id).FirstOrDefault();
            return File(file.Image.ToArray(), "image/png", file.ProductName);
        }
    }
}