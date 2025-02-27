using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PackSlipApp.Controllers
{
    public class UserInputController : Controller
    {
        // GET: UserInput
        public ActionResult AddPackslipData()
        {
            return View();
        }
    }
}