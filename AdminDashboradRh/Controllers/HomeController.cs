using AdminDashboradRh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminDashboradRh.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserApp u)
        {
            // this action is for handle post (login)
            if (ModelState.IsValid) // this is check validity
            {
                using (RhContext dc = new RhContext())
                {
                    var v = dc.Users.Where(a => a.Name_User.Equals(u.Name_User) && a.Password_User.Equals(u.Password_User)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserID"] = v.Name_User.ToString();
                        Session["LogedUserFullname"] = v.Password_User.ToString();
                        return RedirectToAction("Index", "Succes");
                    }
                }
            }
            return View(u);
        }
    }
}