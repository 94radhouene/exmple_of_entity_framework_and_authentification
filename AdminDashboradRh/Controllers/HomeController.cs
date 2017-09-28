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
                    var v = dc.Users.Where(a => a.username.Equals(u.username) && a.Password.Equals(u.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserID"] = v.username.ToString();
                        Session["LogedUserFullname"] = v.Password.ToString();
                        return View("Success");
                    }
                }
            }
            return View(u);
        }
    }
}