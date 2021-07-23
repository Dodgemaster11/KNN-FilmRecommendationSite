using Microsoft.AspNetCore.Mvc;
using ShopProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShopProj.Controllers
{
    public class ProfileController : Controller
    {


        FilmContext db;


        public ProfileController(FilmContext context)
        {
            db = context;
        }
      
        public async Task<IActionResult> Profile()
        {
            var user = await db.Users
                .Include(user => user.Marks)
                .ThenInclude(m => m.Film)
                .FirstOrDefaultAsync(u => u.user_email == User.Identity.Name);
            return View(user);
        }

        // GET: FilmInformationController/Create
        public ActionResult Create()
        {
            return View();
        }

    }
}
