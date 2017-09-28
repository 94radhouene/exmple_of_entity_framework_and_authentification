using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AdminDashboradRh.Controllers
{
    public class SuccesController : Controller
    {
        // GET: Succes
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            if (Session["LogedUserID"].ToString() == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Session.Clear();
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request

            return RedirectToAction("Index", "Home");
        }
    }
}