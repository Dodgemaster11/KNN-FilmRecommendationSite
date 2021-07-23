
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopProj.Models.Interfaces
{
    public interface IAllFilms
    {
        IEnumerable<Film> Films { get; }

        IEnumerable<Film> getFavFilms { get; set; }

        Film getObjectFilm(int filmId);

    }
}
