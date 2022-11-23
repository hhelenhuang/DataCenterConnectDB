using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DBmanager dBmanager = new DBmanager();
            List<LoginContact> loginContacts = dBmanager.GetLoginContact();
            ViewBag.loginContacts = loginContacts;
            return View();
        }
        public ActionResult CreateLoginContact()
        {
            return View();
        }
    }
}