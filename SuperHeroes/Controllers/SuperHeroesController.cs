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
            try
            {
                SuperHero superHeroFromDb = _context.SuperHeroes.Where(s => s.Id == id).FirstOrDefault();
                return View(superHeroFromDb);
            }
            catch (Exception e)
            {
                return View();
            }
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
                _context.SuperHeroes.Add(superHero);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: SuperHeroes/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                SuperHero superHeroFromDb = _context.SuperHeroes.Where(s => s.Id == id).FirstOrDefault();
                return View(superHeroFromDb);
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // POST: SuperHeroes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SuperHero superHero)
        {
            try
            {
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
                return View();
            }
        }

        // GET: SuperHeroes/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                SuperHero superHeroFromDb = _context.SuperHeroes.Where(s => s.Id == id).FirstOrDefault();
                return View(superHeroFromDb);
            }
            catch (Exception e)
            {
                return View();
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
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}