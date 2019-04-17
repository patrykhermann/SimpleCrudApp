using SimpleCrudApp.DAL;
using SimpleCrudApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SimpleCrudApp.Controllers
{
    public class ManageController : Controller
    {
        MyDbContext db = new MyDbContext();

        // GET: Manage
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        // GET: Manage/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var emp = db.Employees.Find(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        // GET: Manage/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Manage/Create
        [HttpPost]
        public ActionResult Add(Employee emp)
        {
            try
            {
                db.Employees.Add(emp);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manage/Edit/5
        public ActionResult Edit(int id)
        {
            var emp = db.Employees.Find(id);
            return View(emp);
        }

        // POST: Manage/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee emp)
        {
            try
            {
                db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manage/Delete/5
        public ActionResult Delete(int id)
        {
            var emp = db.Employees.Where(e => e.EmployeeId == id).FirstOrDefault();
            return View(emp);
        }

        // POST: Manage/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee emp)
        {
            try
            {
                db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
