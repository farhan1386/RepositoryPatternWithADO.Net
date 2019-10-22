using RepositoryPatternWithADO.Net.Models;
using RepositoryPatternWithADO.Net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RepositoryPatternWithADO.Net.Controllers
{
    public class HomeController : Controller
    {
        private readonly MockEmployee db = new MockEmployee();

        public ActionResult Index()
        {
            var employee = db.GetEmployees();
            return View(employee);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.InsertNew(employee);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = db.GetEmployeeById(id);
            if (employee==null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            db.Update(employee);
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = db.GetEmployeeById(id);
            if (employee==null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var employee = db.GetEmployeeById(id);
            db.Delete(employee);
            return RedirectToAction("Index","Home");
        }
    }
}