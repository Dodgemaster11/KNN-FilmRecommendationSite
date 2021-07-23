using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopProj.Controllers
{
    public class NearestController : Controller
    {
        FilmContext db;
        public NearestController(FilmContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Nearest()
        {
            int ID;
            int K = 5;  //сколько соседей будет использовано для прогноза
            int COUNT_OF_MARKS_USER = 3; // в выборку соседей не будут попадать те пользователи кто оценил меньше n фильмов
            int COUNT_OF_MARKS_FILM = 0; // не будет рекомедоваться фильм у которого меньше n оценок

            var user = await db.Users.AsNoTracking()
                .Include(user => user.Marks)
                .FirstOrDefaultAsync(u => u.user_email == User.Identity.Name);

            ID = user.Id;

            var nn = await db.Users.AsNoTracking()
                    .Include(u => u.Marks)
                    .Where(zx => zx.Marks.Count >= COUNT_OF_MARKS_USER)
                    .ToListAsync();

            nn = nn.OrderByDescending(x => {
                if (x.Id == ID) return -1;
                return euclideanDistance(user.Marks, x.Marks);
            }).ToList();

            var films = await db.Films.AsNoTracking()
                    //.Include(q => q.Marks)
                    .Where(y => y.Marks.Count > COUNT_OF_MARKS_FILM)
                    .ToListAsync();

            films = films
                    .Where(y => user.Marks.FindIndex(z => z.FilmId == y.Id) == -1)
                    .OrderByDescending(film => {
                        film.Users = null;
                        var k = nn.Count > K ? K : nn.Count - 1;
                        var weightedSum = 0d;
                        var similaritySum = 0d;
                        for (int j = 0; j < k; j++)
                        {
                            var m = nn[j].Marks.FirstOrDefault(z => z.FilmId == film.Id);
                            if (m != null)
                            {
                                var sim = euclideanDistance(user.Marks, nn[j].Marks);
                                weightedSum += m.Mark * sim;
                                similaritySum += sim;
                            }
                        }
                        var stars = weightedSum / similaritySum;
                        if (Double.IsNaN(stars))
                        {
                            var m = db.Films.AsNoTracking().Include(m => m.Marks).First(ph => ph.Id == film.Id);
                            stars = m.Marks.Average(x => x.Mark);
                        }
                        return stars;
                    })
                    .ToList();
            return View(films);
        }
        private double euclideanDistance(List<Marks> mark1, List<Marks> mark2)
        {
            double sumSquares = 0;
            foreach (var item in mark1)
            {
                var suck = mark2.FindIndex(x => x.FilmId == item.FilmId);
                if (suck != -1)
                {
                    var diff = item.Mark - mark2[suck].Mark;
                    sumSquares += diff * diff;
                }
            }
            var d = Math.Sqrt(sumSquares);
            var similarity = 1 / (1 + d);
            return similarity;
        }
    }
}
