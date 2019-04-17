using SimpleCrudApp.DAL;
using SimpleCrudApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace SimpleCrudApp.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext db = new MyDbContext();

        // GET: Home
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PosSortParm = sortOrder == "position" ? "position_desc" : "position";

            if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var emps = from e in db.Employees select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                emps = emps.Where(e => e.FirstName.ToLower().Contains(searchString.ToLower())
                                || e.LastName.ToLower().Contains(searchString.ToLower()));
            }

            switch(sortOrder)
            {
                case "name_desc":
                    emps = emps.OrderByDescending(e => e.LastName);
                    break;
                case "position":
                    emps = emps.OrderBy(e => e.Position);
                    break;
                case "position_desc":
                    emps = emps.OrderByDescending(e => e.Position);
                    break;
                default:
                    emps = emps.OrderBy(e => e.LastName);
                    break;
            }

            int pageSize = 8;
            int pageNumber = (page ?? 1);

            return View(emps.ToPagedList(pageNumber, pageSize));
        }
    }
}