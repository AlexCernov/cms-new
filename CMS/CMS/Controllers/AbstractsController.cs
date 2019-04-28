using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMS.Models;

namespace CMS.Controllers
{
    public class AbstractsController : Controller
    {

        // THIS IS GENERATED CODE : A controller can't use DatabaseContext ( that's why we have services, so if you want to use the code bellow look at Authors or PCMembers controllers and see
        // how things work there

        // There might not be a use for all the views/methods that were automatically generated
        private DatabaseContext db = new DatabaseContext();

        // GET: Abstracts
        public ActionResult Index()
        {
            return View(db.Abstracts.ToList());
        }

        // GET: Abstracts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abstract @abstract = db.Abstracts.Find(id);
            if (@abstract == null)
            {
                return HttpNotFound();
            }
            return View(@abstract);
        }

        // GET: Abstracts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Abstracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Keywords,Description")] Abstract @abstract)
        {
            if (ModelState.IsValid)
            {
                db.Abstracts.Add(@abstract);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@abstract);
        }

        // GET: Abstracts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abstract @abstract = db.Abstracts.Find(id);
            if (@abstract == null)
            {
                return HttpNotFound();
            }
            return View(@abstract);
        }

        // POST: Abstracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Keywords,Description")] Abstract @abstract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@abstract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@abstract);
        }

        // GET: Abstracts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abstract @abstract = db.Abstracts.Find(id);
            if (@abstract == null)
            {
                return HttpNotFound();
            }
            return View(@abstract);
        }

        // POST: Abstracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Abstract @abstract = db.Abstracts.Find(id);
            db.Abstracts.Remove(@abstract);
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
