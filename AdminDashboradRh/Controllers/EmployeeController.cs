using AdminDashboradRh.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
        // create employee
        // get the view of creation 
        [HttpGet]
        public ActionResult Create()
        {
          
            return View();
        }
        // send the data 
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

        // detail of employee
        // get id of emplyee
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeApp tblEmployee = db.Employees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
      
            return View(tblEmployee);
        }
        // GET: tblEmployees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeApp tblEmployee = db.Employees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
          
            return View(tblEmployee);
        }

        // POST: tblEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            EmployeeApp tblEmployee = db.Employees.Find(id);
            UpdateModel<IEmployee>(tblEmployee);
            if (ModelState.IsValid)
            {
                db.Entry(tblEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
         
            return View(tblEmployee);
        }
        // GET: tblEmployees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeApp tblEmployee = db.Employees.Find(id);
            if (tblEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tblEmployee);
        }

        // POST: tblEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeApp tblEmployee = db.Employees.Find(id);
            db.Employees.Remove(tblEmployee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}