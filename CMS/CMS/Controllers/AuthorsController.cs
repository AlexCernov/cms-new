using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMS.Models;
using CMS.Services;
using CMS.Repositories;
using CMS.ViewModels;

namespace CMS.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly AuthorService AuthorService;

        public AuthorsController()
        {
            AuthorService = new AuthorService(new AuthorRepository());
        }

        // GET: Authors/Register
        public ActionResult Register()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("PermissionDenied");
            }

            RegisterAuthorViewModel model = new RegisterAuthorViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Id,Email,Username,Password,Name,Affiliation")] Author author)
        {
            try
            {
                RegisterAuthorViewModel model = new RegisterAuthorViewModel(ModelState.IsValid, author, AuthorService);
                return View(model);
            }
            catch (System.Exception)
            {
                return RedirectToRoute("~/Shared/Error");
            }
        }

        // generated code

        //private DatabaseContext db = new DatabaseContext();

        //// GET: Authors
        //public ActionResult Index()
        //{
        //    return View(db.Authors.ToList());
        //}

        //// GET: Authors/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Author author = db.Authors.Find(id);
        //    if (author == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(author);
        //}

        //// GET: Authors/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Authors/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Email,Username,Password,Name,Affiliation")] Author author)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Authors.Add(author);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(author);
        //}

        //// GET: Authors/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Author author = db.Authors.Find(id);
        //    if (author == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(author);
        //}

        //// POST: Authors/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Email,Username,Password,Name,Affiliation")] Author author)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(author).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(author);
        //}

        //// GET: Authors/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Author author = db.Authors.Find(id);
        //    if (author == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(author);
        //}

        //// POST: Authors/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Author author = db.Authors.Find(id);
        //    db.Authors.Remove(author);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
