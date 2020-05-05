using EBookMart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBookMart.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Authentication authentication)
        {
            try
            {
                AuthenticationContext authenticationContext = new AuthenticationContext();
                Authentication authentication1 = authenticationContext.Authentications.SingleOrDefault(entity => entity.Email == authentication.Email);
                if (authentication1 == null)
                {
                    authenticationContext.Authentications.Add(authentication);
                    authenticationContext.SaveChanges();
                    return View("Login");
                }
                else
                {
                    return Content("Account already exists. Try going back and logging in");
                }
            }
            catch (Exception e)
            {
                return Content("Unable to create account due to " + Convert.ToString(e));
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginStructure loginStructure)
        {
            AuthenticationContext authenticationContext = new AuthenticationContext();
            Authentication authentication = authenticationContext.Authentications.SingleOrDefault(entity => entity.Email == loginStructure.Email);
            if (authentication != null)
            {
                if(authentication.Password == loginStructure.Password)
                {
                    return RedirectToAction("ListBook", "BookShop",new { id = authentication.id });
                }
                else
                {
                    return Content("Please check the password");
                }
            }
            else
            {
                return Content("Account does not exists. Please call again later");
            }
        }
    }
}