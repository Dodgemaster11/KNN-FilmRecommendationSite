using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopProj.Models;
using ShopProj.ViewModels;

namespace ShopProj.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private FilmContext db;
        public AdminController(FilmContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Upsert(int? id)
        {
            if (id == null)
            {
                //this is for create
                return View();
            }
            var film = await db.Films.FirstOrDefaultAsync(item => item.Id == id);
            UpsertModel model = new UpsertModel
            {
                Id = film.Id,
                film_name = film.film_name,
                prod_year = film.prod_year,              
                shortDesc = film.shortDesc,
                longDesc = film.longDesc,
                poster = film.poster,
                trailer = film.trailer,
                film_time = film.film_time
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(UpsertModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    var film = new Film
                    {                    
                        film_name = model.film_name,
                        prod_year = model.prod_year,                      
                        shortDesc = model.shortDesc,
                        longDesc = model.longDesc,
                        poster = model.poster,
                        trailer = model.trailer,
                        film_time = model.film_time
                    };

                    db.Films.Add(film);
                }
                else
                {
                    var film = db.Films.FirstOrDefault(item => item.Id == model.Id);
                   
                    film.film_name = model.film_name;
                    film.prod_year = model.prod_year;               
                    film.shortDesc = model.shortDesc;
                    film.longDesc = model.longDesc;
                    film.poster = model.poster;
                    film.trailer = model.trailer;
                    film.film_time = model.film_time;

                    db.Films.Update(film);
                    await db.SaveChangesAsync();

                    return RedirectToAction("Film", "FilmInformation", new { @id = film.Id });
                }

                await db.SaveChangesAsync();

                return RedirectToAction("Upsert", "Admin");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var film = db.Films.FirstOrDefault(item => item.Id == id);
            if (film != null)
            {
                db.Remove(film);
                await db.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
