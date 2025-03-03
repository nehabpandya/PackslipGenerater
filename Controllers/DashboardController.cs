using PackSlipApp.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PackSlipApp.Controllers
{
    [SessionCheckFilter]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Analytics()
        {
            return View();
        }
    }
}