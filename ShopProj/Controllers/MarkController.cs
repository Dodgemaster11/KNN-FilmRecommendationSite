using Microsoft.AspNetCore.Mvc;
using ShopProj.Models;
using ShopProj.ViewModels;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ShopProj.Controllers
{
    public class MarkController : Controller
    {
        private FilmContext db;
        public MarkController(FilmContext context)
        {
            db = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMark(MarkViewModel model)
        {
            if (ModelState.IsValid)
            {
              
                var film = await db.Films.FirstOrDefaultAsync(f => f.Id == model.FilmId);
                var user = db.Users.Include(user => user.Marks).FirstOrDefault(u => u.user_email == User.Identity.Name);
                var mark = user.Marks.FirstOrDefault(x => x.Film == film);


              

                if (mark == null)
                {
                    user.Marks.Add(new Marks { Film = film, Mark = model.Mark });
                }else
                {
                    mark.Mark = model.Mark;
                }
                
               
                await db.SaveChangesAsync();
               
            }

            return RedirectToAction("Film", "FilmInformation", new { @id = model.FilmId });
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
