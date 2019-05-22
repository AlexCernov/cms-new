using CMS.Models;
using CMS.Repositories.Users;
using CMS.Services.Users;
using CMS.ViewModels.PCMemberViewModels;
using System.Linq;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class PCMembersController : Controller
    {
        private readonly PCMemberService PCMemberService;

        public PCMembersController()
        {
            PCMemberService = new PCMemberService(new PCMemberRepository());
        }

        // GET : PcMembers/Register
        public ActionResult Register()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("PermissionDenied");
            }

            RegisterPCMemberViewModel model = new RegisterPCMemberViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Id,Email,Username,Password,Name,Affiliation,WebPage")] PCMember pCMember)
        {
            try
            {

                RegisterPCMemberViewModel model = new RegisterPCMemberViewModel(ModelState.IsValid, pCMember, PCMemberService);
                return View(model);
            }
            catch (System.Exception)
            {
                return RedirectToRoute("~/Shared/Error");
            }
        }


        // GET : PCMembers/Login

        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("PermissionDenied");
            }
            LoginPCMemberViewModel model = new LoginPCMemberViewModel();
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password, bool rememberMe)
        {
            try
            {

                LoginPCMemberViewModel model = new LoginPCMemberViewModel(ModelState.IsValid, username, password, rememberMe, PCMemberService, out int response);
                if (response == 1)
                {
                    Response.Cookies.Add(model.Cookie);
                    return RedirectToAction("Index");//we want to load a new page with new url, not just rendering the view
                }
                return View(model);
            }
            catch
            {
                return RedirectToRoute("~/Shared/Error");
            }
        }


        // POST : PCMember/Register



        // GET: PCMembers
        public ActionResult Index()
        {
            return View(PCMemberService.FindAll());
        }


        // GET: PCMembers/All
        [HttpGet]
        public JsonResult All(string term)
        {
            return Json(PCMemberService.FindAll().AsEnumerable().Where(a => a.Username.Contains(term)).Select(a => new {label = a.Username }), JsonRequestBehavior.AllowGet);
        }

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
