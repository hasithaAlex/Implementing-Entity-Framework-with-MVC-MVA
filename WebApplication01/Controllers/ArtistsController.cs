using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication01.Models;

namespace WebApplication01.Controllers
{
    public class ArtistsController : Controller
    {
        MusicStoreDataContext context = new MusicStoreDataContext();
        // GET: Artists
        public ActionResult Index()
        {
            return View(context.Artists.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public ActionResult Create(Artist artist)
        {
            if (!ModelState.IsValid)
                return View(artist);

            context.Artists.Add(artist);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}