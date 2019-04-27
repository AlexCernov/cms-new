using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMS.Models;
using CMS.Repositories;
using CMS.Services;
using CMS.ViewModels;

namespace CMS.Controllers
{
    public class PCMembersController : Controller
    {
        PCMemberService PCMemberService;

        public PCMembersController()
        {
            PCMemberService = new PCMemberService(new PCMemberRepository());
        }

        // GET : PcMembers/Register
        public ActionResult Register()
        {
            var model = new RegisterPCMemberViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Id,Email,Username,Password,Name,Affiliation,WebPage")] PCMember pCMember)
        {
            try
            {

                var model = new RegisterPCMemberViewModel(ModelState.IsValid, pCMember, PCMemberService);
                return View(model);
            }
            catch (System.Exception e)
            {
                return RedirectToRoute("~/Shared/Error");
            }
        }


        // POST : PCMember/Register



        //// GET: PCMembers
        //public ActionResult Index()
        //{
        //    return View(db.PCMembers.ToList());
        //}

        //// GET: PCMembers/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PCMember pCMember = db.PCMembers.Find(id);
        //    if (pCMember == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(pCMember);
        //}

        //// GET: PCMembers/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: PCMembers/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Email,Username,Password,Name,Affiliation,WebPage")] PCMember pCMember)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.PCMembers.Add(pCMember);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(pCMember);
        //}

        //// GET: PCMembers/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PCMember pCMember = db.PCMembers.Find(id);
        //    if (pCMember == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(pCMember);
        //}

        //// POST: PCMembers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Email,Username,Password,Name,Affiliation,WebPage")] PCMember pCMember)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(pCMember).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(pCMember);
        //}

        //// GET: PCMembers/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PCMember pCMember = db.PCMembers.Find(id);
        //    if (pCMember == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(pCMember);
        //}

        //// POST: PCMembers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    PCMember pCMember = db.PCMembers.Find(id);
        //    db.PCMembers.Remove(pCMember);
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
