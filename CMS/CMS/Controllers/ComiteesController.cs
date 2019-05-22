using CMS.Models;
using CMS.Services.Entities;
using CMS.ViewModels.ComiteeViewModels;
using System.Linq;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class ComiteesController : Controller
    {

       
        private readonly ComiteeService service;

        public ComiteesController()
        {
            this.service = new ComiteeService(new Repositories.Entities.ComiteeRepository());
        }

        // GET: Comitees
        public ActionResult Index()
        {
            return View(service.FindAll().ToList());
        }



        // GET: Comitees/Create
        public ActionResult Create()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("PermissionDenied");
            }
            CreateComiteeViewModel model = new CreateComiteeViewModel();
            return View(model);
        }

        // POST: Comitees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Comitee,rawPCMembers")]CreateComiteeViewModel model)
        {
            try
            {
                model.addComitee(ModelState.IsValid, service);
                return View(model);
            }
            catch (System.Exception e)
            {
                return RedirectToRoute("~/Shared/Error");
            }
        }

        //// GET: Comitees/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Comitee comitee = db.Comitees.Find(id);
        //    if (comitee == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(comitee);
        //}

        //// GET: Comitees/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Comitee comitee = db.Comitees.Find(id);
        //    if (comitee == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(comitee);
        //}

        //// POST: Comitees/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name")] Comitee comitee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(comitee).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(comitee);
        //}

        // GET: Comitees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("PermissionDenied");
            }
            DeleteComiteeViewModel model = new DeleteComiteeViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Comitee comitee)
        {
            try
            {
                DeleteComiteeViewModel model = new DeleteComiteeViewModel(ModelState.IsValid, comitee, service);
                return View(model);
            }
            catch (System.Exception)
            {
                return RedirectToRoute("~/Shared/Error");
            }
        }

        //// POST: Comitees/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Comitee comitee = service.FindAll().Find(id);
        //    service.Delete(comitee);
        //    return RedirectToAction("Index");
        //}



    }
}
