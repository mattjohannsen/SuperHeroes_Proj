using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroes.Data;
using SuperHeroes.Models;

namespace SuperHeroes.Controllers
{
    public class SuperHeroesController : Controller
    {
        public ApplicationDbContext _context;
        //private object context;

        public SuperHeroesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: SuperHeroes
        public ActionResult Index()
        {
            //return View();
            var superheroes = _context.SuperHeroes;
            return View(superheroes);
        }

        // GET: SuperHeroes/Details/5
        public ActionResult Details(int id)
        {
            SuperHero superHeroFromDb = _context.SuperHeroes.Where(s => s.Id == id).FirstOrDefault();
            return View(superHeroFromDb);
            //return View();
        }

        // GET: SuperHeroes/Create
        public ActionResult Create()
        {
           return View();

        }

        // POST: SuperHeroes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuperHero superHero)
        {
            try
            {
                // TODO: Add insert logic here // I added this below here.
                _context.SuperHeroes.Add(superHero);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroes/Edit/5
        public ActionResult Edit(int id)
        {
            // get superhero with this id and send into view
            try
            {
                // TODO: Add update logic here //Added
                SuperHero superHeroFromDb = _context.SuperHeroes.Where(s => s.Id == id).FirstOrDefault();

                _context.SaveChanges();
                return RedirectToAction(nameof(Edit));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View();
            }
            //Need to change it to be like something below
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //SuperHero superHero = _context.SuperHeroes.Find(id);
            //if (superHero == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(movie);
        }

        // POST: SuperHeroes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SuperHero superHero)
        {
            try
            {
                // TODO: Add update logic here //Added
                SuperHero superHeroFromDb = _context.SuperHeroes.Where(s => s.Id == superHero.Id).FirstOrDefault();
                superHeroFromDb.name = superHero.name;
                superHeroFromDb.alterEgo = superHero.alterEgo;
                superHeroFromDb.primaryAbility = superHero.primaryAbility;
                superHeroFromDb.secondaryAbility = superHero.secondaryAbility;
                superHeroFromDb.catchphrase = superHero.catchphrase;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View();
            }
        }

        // GET: SuperHeroes/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                SuperHero superHero = _context.SuperHeroes.Where(s => s.Id == id).FirstOrDefault();
                _context.SuperHeroes.Remove(superHero);
                // TODO: Add delete logic here// I added this
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return View("Index");
            }
        }

        // POST: SuperHeroes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SuperHero superHero)
        {

            try
            {
                superHero = _context.SuperHeroes.Where(a => a == superHero).FirstOrDefault();
                _context.SuperHeroes.Remove(superHero);
                // TODO: Add delete logic here// I added this
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return View();
            }
        }
    }
}