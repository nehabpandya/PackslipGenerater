using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PackSlipApp.Filter
{
    public class UserFilter : SessionCheckFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            if (session["Usertype"] == null)
            {
                filterContext.Result = new RedirectResult("~/Authentication/Index");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}