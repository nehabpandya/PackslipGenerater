using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PackSlipApp.Filter
{
    public class SessionCheckFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as Controller;
            var session = controller?.Session;

            if (session != null && session.IsNewSession)
            {
                string sessionCookie = controller.Request.Headers["Cookie"];
                if ((sessionCookie != null) && (sessionCookie.IndexOf("ASP.NET_SessionId", StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    // Session expired, redirect to login page
                    filterContext.Result = new RedirectResult("~/Authentication/SignInCover");
                    return;

                }
            }
            if (session["Username"] == null)
            {
                filterContext.Result = new RedirectResult("~/Authentication/SignInCover");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}