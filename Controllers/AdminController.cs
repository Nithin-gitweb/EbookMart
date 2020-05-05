using EBookMart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBookMart.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            AuthenticationContext authenticationContext = new AuthenticationContext();
            List<Authentication> authentication = authenticationContext.Authentications.ToList();
            ViewBag.authentication = authentication;
            return View("Index");
        }
        
    }
}