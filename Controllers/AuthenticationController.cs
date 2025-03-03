using PackSlipApp.Database.Models;
using PackSlipApp.Filter;
using PackSlipApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PackSlipApp.Controllers
{
   
    public class AuthenticationController : Controller
    {
       
        // GET: Authentication
        ITe_INDIAEntities1 context = new ITe_INDIAEntities1();
        LoginViewModel loginModel = new LoginViewModel();
        [ActionName("SignInCover")]
        public ActionResult SignInCover()
        {
            return View(loginModel);
        }
        public ActionResult Login(LoginViewModel _Model)
        {
            try
            {
                int? id = int.TryParse(_Model.Username, out int tempId) ? tempId : 0;

                

                USER_MST _user = context.USER_MST.Where(p => (p.LOGIN_ID == _Model.Username || p.personID == id) && p.PASSWORD_CHNG == _Model.Password).FirstOrDefault();
                if (_user != null)
                {
                    Session["user_id"] = _user.personID;
                    Session["Username"] = _user.LOGIN_ID;
                    Session["EmployeePosition"] = _user.EmployeePosition;
                    Session["userimg"] = "http://192.168.1.97/pic/" + _user.personID;
                    FormsAuthentication.SetAuthCookie(_Model.Username, false);
                    if (Session["user_id"].ToString() == "7315")
                    {
                        Session["Usertype"] = "admin";
                    }
                    return RedirectToAction("Analytics", "Dashboard", new { id });

                }
                else
                {
                    TempData["ErrorMessage"] = "Please check your Credentials.";
                    return RedirectToAction("SignInCover", "Authentication");
                }
            }

            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                    }
                }
                TempData["ErrorMessage"] = "Please check your Credentials.";

                return RedirectToAction("SignInCover", "Authentication");
            }
        }

        [ActionName("LogoutBasic")]
        public ActionResult LogoutBasic()
        {
            return View();
        }
    }
}