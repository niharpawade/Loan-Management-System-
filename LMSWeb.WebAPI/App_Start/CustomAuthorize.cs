using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;

namespace LMSWeb.WebAPI
{
    public class CustomAuthorize : System.Web.Http.AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            try
            {
                // base.OnAuthorization(actionContext);
                if (actionContext.Request.Headers.GetValues("authenticationtoken") != null)
                {

                    HttpContext.Current.Response.AddHeader("AuthenticationStatus", "Authorized");
                    return;
                }

                HttpContext.Current.Response.AddHeader("AuthenticationStatus", "NotAuthorized");
                return;
            }
            catch
            {
                HttpContext.Current.Response.AddHeader("AuthenticationStatus", "NotAuthorized");
                return;

            }
        }
    }
}