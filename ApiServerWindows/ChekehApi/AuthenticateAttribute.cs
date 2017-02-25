using System;
using System.Net;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ChekehApi.Controllers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    internal class AuthenticateAttribute : ActionFilterAttribute
    {
        public bool IsAdmin { get; set; }
        DcDataContext dc = new DcDataContext();
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (IsAdmin)
            {

            }
            /*
            try
            {
                var queryString = actionContext.Request.RequestUri.Query;
                if (!String.IsNullOrWhiteSpace(queryString))
                {
                    if (!Convert.ToBoolean(dc.CheckLogin(HttpUtility.ParseQueryString(queryString.Substring(1))["Username"], HttpUtility.ParseQueryString(queryString.Substring(1))["Password"])))
                        actionContext.Response = new System.Net.Http.HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
            }
            catch
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            base.OnActionExecuting(actionContext);
            */
        }
    }
}