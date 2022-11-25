using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataCenterConnectDB.Models;

namespace DataCenterConnectDB.Controllers
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

        [HttpPost]
        public ActionResult CreateLoginContact(LoginContact loginContact) {
            DBmanager dBmanager = new DBmanager();
            try
            {
                dBmanager.NewLoginContact(loginContact);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return RedirectToAction("Index");
        }
        public ActionResult EditLoginContact(int id)
        {
            DBmanager dBmanager = new DBmanager();
            LoginContact loginContact = dBmanager.GetLoginContactById(id);
            return View(loginContact);
        }

        public ActionResult DeleteLoginContact(int id, LoginContact loginContact)
        {
            DBmanager dBmanager = new DBmanager();
            dBmanager.DeleteLoginContactById(id, loginContact);
            return RedirectToAction("Index");
        }

    }
}