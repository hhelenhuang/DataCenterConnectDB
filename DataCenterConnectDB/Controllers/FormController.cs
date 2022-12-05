using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataCenterConnectDB.Models;


namespace DataCenterConnectDB.Controllers
{
    public class FormController : Controller
    {

            // GET: Login
            public ActionResult Index()
            {
                return View();
            }
            public ActionResult CreateForm()
            {
                return View();
            }

        //        [HttpPost]
        //        public ActionResult CreateForm(Form form)
        //        {
        //            DBmanager dBmanager = new DBmanager();
        //            try
        //            {
        //                dBmanager.NewLoginContact(form);
        //            }
        //            catch (Exception e)
        //            {
        //                Console.WriteLine(e.ToString());
        //            }
        //            return RedirectToAction("Login/CreateLoginContact");
        //        }

        //        public ActionResult EditLoginContact(int id)
        //        {
        //            DBmanager dBmanager = new DBmanager();
        //            LoginContact loginContact = dBmanager.GetLoginContactById(id);
        //            return View(loginContact);
        //        }
        //        [HttpPost]
        //        public ActionResult EditLoginContact(LoginContact loginContact)
        //        {
        //            DBmanager dBmanager = new DBmanager();
        //            dBmanager.UpdateLoginContact(loginContact);
        //            return RedirectToAction("Login/EditLoginContact");

        //        }

        //        public ActionResult DeleteLoginContact(int id)
        //        {
        //            DBmanager dBmanager = new DBmanager();
        //            dBmanager.DeleteLoginContactById(id);
        //            return RedirectToAction("Login/DeleteLoginContact");
        //        }

        public ActionResult Form()
        {
            //DBmanager dBmanager = new DBmanager();
            //List<Form> forms = dBmanager.GetForm();
            //ViewBag.forms = forms;
            return View();
        }
        //    }
        //}
    }
