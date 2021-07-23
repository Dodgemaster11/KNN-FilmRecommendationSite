using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ShopProj.Controllers
{
    public class FilmInformationController : Controller
    {


        FilmContext db;


        public FilmInformationController(FilmContext context)
        {
            db = context;
        }
        // GET: FilmInformationController/Details/5
        public async Task<IActionResult> Film(int id)
        {
            var film = await db.Films.Include(k => k.Marks).FirstOrDefaultAsync(f => f.Id == id);
            var user = db.Users.Include(user => user.Marks).FirstOrDefault(u => u.user_email == User.Identity.Name);
            var mark = user.Marks.FirstOrDefault(x => x.Film == film);
            if (mark != null)
            {
                ViewBag.Mark = mark.Mark;
            }
            if (film != null) {
                if (film.Marks.Count == 0)
                {
                    ViewBag.MarkAvg = "Фильм никто не оценил";
                }
                else
                {
                    var avgmark = film.Marks.Average(a => a.Mark);
                    ViewBag.MarkAvg = avgmark;
                }
            }




            return View(film);
        }

        // GET: FilmInformationController/Create
        public ActionResult Create()
        {
            return View();
        }

    }
}
