using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _02_MVA_Ex.Models.OneToOne;

namespace _02_MVA_Ex.Controllers
{
    public class OneToOne_ArtistDetailsController : Controller
    {
        private MusicStoreDataContext db = new MusicStoreDataContext();

        // GET: OneToOne_ArtistDetails
        public ActionResult Index()
        {
            var artistDetails = db.ArtistDetails.Include(a => a.Artist);
            return View(artistDetails.ToList());
        }

        // GET: OneToOne_ArtistDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistDetails artistDetails = db.ArtistDetails.Find(id);
            if (artistDetails == null)
            {
                return HttpNotFound();
            }
            return View(artistDetails);
        }

        // GET: OneToOne_ArtistDetails/Create
        public ActionResult Create()
        {
            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name");
            return View();
        }

        // POST: OneToOne_ArtistDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtistID,Bio")] ArtistDetails artistDetails)
        {
            if (ModelState.IsValid)
            {
                db.ArtistDetails.Add(artistDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name", artistDetails.ArtistID);
            return View(artistDetails);
        }

        // GET: OneToOne_ArtistDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistDetails artistDetails = db.ArtistDetails.Find(id);
            if (artistDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name", artistDetails.ArtistID);
            return View(artistDetails);
        }

        // POST: OneToOne_ArtistDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtistID,Bio")] ArtistDetails artistDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artistDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name", artistDetails.ArtistID);
            return View(artistDetails);
        }

        // GET: OneToOne_ArtistDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistDetails artistDetails = db.ArtistDetails.Find(id);
            if (artistDetails == null)
            {
                return HttpNotFound();
            }
            return View(artistDetails);
        }

        // POST: OneToOne_ArtistDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArtistDetails artistDetails = db.ArtistDetails.Find(id);
            db.ArtistDetails.Remove(artistDetails);
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
