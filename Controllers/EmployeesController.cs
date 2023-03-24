using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;
using System.Xml.Schema;
using TylerTech.Models;

namespace TylerTech.Controllers
{
    public class EmployeesController : Controller
    {
        private Context db = new Context();
        
        public List<string> Generate()
        {
            return db.Employees.ToList().Select(a => a.ManagerName).Distinct().ToList();
        }


        // GET: Employees
        public ActionResult Index()
        {
            var ManagerList = Generate();
            ViewBag.list = ManagerList;
            Empvmodel evm = new Empvmodel()
            {

                emplist = db.Employees.ToList()
            };
            return View(evm);
        }


        [HttpPost]
        public ActionResult Search(Empvmodel e)
        {
            var Tlist=db.Employees.ToList();
            List<Employee> Elist = new List<Employee>();

            //Using Referential Integrity -Self join
            foreach(var x in Tlist)
            {
                if(x.ManagerName == e.employee.ManagerName)
                { 
                    Elist.Add(x);
                }
            }
            ViewBag.message = e.employee.ManagerName;
            return View(Elist);
        }


        // GET: Employees/Create
        public ActionResult Create()
        {
            var ManagerList = db.Employees.ToList().Select(a => a.Firstname+" "+a.LastName).ToList();
            ViewBag.list = ManagerList;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,LastName,Firstname,Roles,ManagerName")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }










        /*I have added some more functionalities like Edit, Details and Delete Employee information apart from specified requirements. */
        /*Below code is responsible for the Edit,Details and Delete functionalites */
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,LastName,Firstname,Roles,ManagerName")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
