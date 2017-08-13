using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _03_MVA_Ex_RepoPatern.Models;
using _03_MVA_Ex_RepoPatern.Models.Models;

namespace _03_MVA_Ex_RepoPatern.Controllers
{
    public class AlbamsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Albams
        public ActionResult Index()
        {
            var albams = db.Albams.Include(a => a.Artist);
            return View(albams.ToList());
        }

        // GET: Albams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albam albam = db.Albams.Find(id);
            if (albam == null)
            {
                return HttpNotFound();
            }
            return View(albam);
        }

        // GET: Albams/Create
        public ActionResult Create()
        {
            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name");
            return View();
        }

        // POST: Albams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbamID,Title,ArtistID")] Albam albam)
        {
            if (ModelState.IsValid)
            {
                db.Albams.Add(albam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name", albam.ArtistID);
            return View(albam);
        }

        // GET: Albams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albam albam = db.Albams.Find(id);
            if (albam == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name", albam.ArtistID);
            return View(albam);
        }

        // POST: Albams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbamID,Title,ArtistID")] Albam albam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(albam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "Name", albam.ArtistID);
            return View(albam);
        }

        // GET: Albams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albam albam = db.Albams.Find(id);
            if (albam == null)
            {
                return HttpNotFound();
            }
            return View(albam);
        }

        // POST: Albams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Albam albam = db.Albams.Find(id);
            db.Albams.Remove(albam);
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
