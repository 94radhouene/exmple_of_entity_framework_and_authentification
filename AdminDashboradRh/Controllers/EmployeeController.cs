using AdminDashboradRh.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminDashboradRh.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        private EmplyeeContext db = new EmplyeeContext();
        public ActionResult Index(int? page)
        {

            var employees = db.Employees.OrderBy(e => e.Name_Employee);
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(employees.ToPagedList(pageNumber, pageSize)); ;
        }
        [HttpGet]
        public ActionResult Create()
        {
          
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        [ActionName("Create")]
        public ActionResult Create([Bind(Include = "Name_Employee,Age_Employee,Poste_Employee")] EmployeeApp Employees)
        {
            if (ModelState.IsValid)
            {
               
                db.Employees.Add(Employees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

         
            return RedirectToAction("Create");
        }


    }
}