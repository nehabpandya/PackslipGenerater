using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PackSlipApp.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        [ActionName("SignInCover")]
        public ActionResult SignInCover()
        {
            return View();
        }


        [ActionName("LogoutBasic")]
        public ActionResult LogoutBasic()
        {
            return View();
        }
    }
}