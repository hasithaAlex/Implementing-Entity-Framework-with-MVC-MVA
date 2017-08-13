using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication01.Models;
using WebApplication01.Models.Repositories;

namespace WebApplication01.Controllers
{
    public class ArtistUsingRepoController : Controller
    {
        ArtistRepository repository = new ArtistRepository(); 
        // GET: ArtistUsingRepo
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }
        
        public ActionResult Details(int id) {
            Artist artist = repository.Get(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(artist);
            }
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

            repository.Add(artist);
            repository.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}