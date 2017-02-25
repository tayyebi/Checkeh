using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChekehApi.Controllers
{
    public class LoginController : ApiController
    {
        DcDataContext dc = new DcDataContext();
        public string GET(string Username, string Password)
        {
            if (Convert.ToBoolean(dc.vCheckLogin(Username, Password)))
            {
                return dc.vHuman_GetType(dc.vHuman_GetIdFromUsername(Username).FirstOrDefault().Id).FirstOrDefault().UserType.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}