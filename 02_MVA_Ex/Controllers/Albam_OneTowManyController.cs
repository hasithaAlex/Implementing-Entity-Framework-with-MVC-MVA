using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _02_MVA_Ex.Models.OneToOne;
using _02_MVA_Ex.Models.OneTowMany;

namespace _02_MVA_Ex.Controllers
{
    public class Albam_OneTowManyController : Controller
    {
        private MusicStoreDataContext db = new MusicStoreDataContext();

        // GET: Albam_OneTowMany
        public ActionResult Index()
        {
            return View(db.OneTowMany_tbl_Albams.ToList());
        }

        // GET: Albam_OneTowMany/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albam_OneTowMany albam_OneTowMany = db.OneTowMany_tbl_Albams.Find(id);
            if (albam_OneTowMany == null)
            {
                return HttpNotFound();
            }
            return View(albam_OneTowMany);
        }

        // GET: Albam_OneTowMany/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albam_OneTowMany/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Albam_OneTowManyID,Title,ArtistID")] Albam_OneTowMany albam_OneTowMany)
        {
            if (ModelState.IsValid)
            {
                db.OneTowMany_tbl_Albams.Add(albam_OneTowMany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(albam_OneTowMany);
        }

        // GET: Albam_OneTowMany/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albam_OneTowMany albam_OneTowMany = db.OneTowMany_tbl_Albams.Find(id);
            if (albam_OneTowMany == null)
            {
                return HttpNotFound();
            }
            return View(albam_OneTowMany);
        }

        // POST: Albam_OneTowMany/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Albam_OneTowManyID,Title,ArtistID")] Albam_OneTowMany albam_OneTowMany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(albam_OneTowMany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(albam_OneTowMany);
        }

        // GET: Albam_OneTowMany/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albam_OneTowMany albam_OneTowMany = db.OneTowMany_tbl_Albams.Find(id);
            if (albam_OneTowMany == null)
            {
                return HttpNotFound();
            }
            return View(albam_OneTowMany);
        }

        // POST: Albam_OneTowMany/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Albam_OneTowMany albam_OneTowMany = db.OneTowMany_tbl_Albams.Find(id);
            db.OneTowMany_tbl_Albams.Remove(albam_OneTowMany);
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
