using CMS.Models;
using CMS.Repositories.Entities;
using CMS.Services.Entities;
using CMS.ViewModels.PaperViewModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class PapersController : Controller
    {

        // THIS IS GENERATED CODE : A controller can't use DatabaseContext ( that's why we have services, so if you want to use the code bellow look at Authors or PCMembers controllers and see
        // how things work there

        // There might not be a use for all the views/methods that were automatically generated
        private PaperService serivce;

        public PapersController()
        {
            this.serivce = new PaperService(new PaperRepository());
        }

        // GET: Papers
        public ActionResult Index()
        {
            return View(serivce.FindAll());
        }


        // GET: Papers/Submit
        public ActionResult Submit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            SubmitPaperViewModel model = new SubmitPaperViewModel(id.GetValueOrDefault());
            return View(model);
        }

        // POST: Papers/Submit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submit([Bind(Include = "File,CallForPapersId")]SubmitPaperViewModel model)
        {

            try
            {
                model.Upload(serivce);
                return View(model);
            }
            catch (System.Exception e)
            {

                return RedirectToRoute("~/Shared/Error");
            }
        }

        //// GET: Papers/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Paper paper = db.Papers.Find(id);
        //    if (paper == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(paper);
        //}


        //// GET: Papers/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Paper paper = db.Papers.Find(id);
        //    if (paper == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(paper);
        //}

        //// POST: Papers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,FilePath")] Paper paper)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(paper).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(paper);
        //}

        //// GET: Papers/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Paper paper = db.Papers.Find(id);
        //    if (paper == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(paper);
        //}

        //// POST: Papers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Paper paper = db.Papers.Find(id);
        //    db.Papers.Remove(paper);
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
