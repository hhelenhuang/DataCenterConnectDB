using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataCenterConnectDB.Models;

namespace DataCenterConnectDB.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateLoginContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateLoginContact(LoginContact loginContact)
        {
            DBmanager dBmanager = new DBmanager();
            try
            {
                dBmanager.NewLoginContact(loginContact);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return RedirectToAction("Login/CreateLoginContact");
        }

        public ActionResult EditLoginContact(int id)
        {
            DBmanager dBmanager = new DBmanager();
            LoginContact loginContact = dBmanager.GetLoginContactById(id);
            return View(loginContact);
        }
        [HttpPost]
        public ActionResult EditLoginContact(LoginContact loginContact)
        {
            DBmanager dBmanager = new DBmanager();
            dBmanager.UpdateLoginContact(loginContact);
            return RedirectToAction("Login/EditLoginContact");
        }

        public ActionResult DeleteLoginContact(int id)
        {
            DBmanager dBmanager = new DBmanager();
            dBmanager.DeleteLoginContactById(id);
            return RedirectToAction("Login/DeleteLoginContact");
        }

        public ActionResult Login()
        {
            DBmanager dBmanager = new DBmanager();
            List<LoginContact> loginContacts = dBmanager.GetLoginContact();
            ViewBag.loginContacts = loginContacts;
            return View();
        }
    }
}