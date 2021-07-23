using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopProj.Models;
using ShopProj.Models.Interfaces;
using ShopProj.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShopProj.Controllers
{
    public class HomeController : Controller
    {

     
        FilmContext db;

       
        public HomeController(FilmContext context)
        {
            db = context;
        }


        [Authorize]
        public async Task<IActionResult> IndexAsync(string filter)
        {
            List<Film> films;

            if (filter == "popular") {             
                films = await db.Films.Include(x => x.Marks).OrderByDescending(y => y.Marks.Average(z => z.Mark)).ToListAsync();
            }
            else if (filter == "news")
            {
                films = await db.Films.OrderByDescending(i => i.Id).ToListAsync();
            }
            else
            {
                films = await db.Films.ToListAsync();
            }

            
            return View(films);          
        }
      

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
