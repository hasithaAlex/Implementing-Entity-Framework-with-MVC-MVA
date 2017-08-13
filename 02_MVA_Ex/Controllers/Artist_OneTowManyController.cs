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
    public class Artist_OneTowManyController : Controller
    {
        private MusicStoreDataContext db = new MusicStoreDataContext();

        // GET: Artist_OneTowMany
        public ActionResult Index()
        {
            return View(db.OneTowMany_tbl_Artists.ToList());
        }

        // GET: Artist_OneTowMany/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist_OneTowMany artist_OneTowMany = db.OneTowMany_tbl_Artists.Find(id);
            if (artist_OneTowMany == null)
            {
                return HttpNotFound();
            }
            return View(artist_OneTowMany);
        }

        // GET: Artist_OneTowMany/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artist_OneTowMany/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Artist_OneTowManyID,Name")] Artist_OneTowMany artist_OneTowMany)
        {
            if (ModelState.IsValid)
            {
                db.OneTowMany_tbl_Artists.Add(artist_OneTowMany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artist_OneTowMany);
        }

        // GET: Artist_OneTowMany/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist_OneTowMany artist_OneTowMany = db.OneTowMany_tbl_Artists.Find(id);
            if (artist_OneTowMany == null)
            {
                return HttpNotFound();
            }
            return View(artist_OneTowMany);
        }

        // POST: Artist_OneTowMany/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Artist_OneTowManyID,Name")] Artist_OneTowMany artist_OneTowMany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artist_OneTowMany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artist_OneTowMany);
        }

        // GET: Artist_OneTowMany/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist_OneTowMany artist_OneTowMany = db.OneTowMany_tbl_Artists.Find(id);
            if (artist_OneTowMany == null)
            {
                return HttpNotFound();
            }
            return View(artist_OneTowMany);
        }

        // POST: Artist_OneTowMany/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artist_OneTowMany artist_OneTowMany = db.OneTowMany_tbl_Artists.Find(id);
            db.OneTowMany_tbl_Artists.Remove(artist_OneTowMany);
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
