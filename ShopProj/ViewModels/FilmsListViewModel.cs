using ShopProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopProj.ViewModels
{
    public class FilmsListViewModel
    {
        public IEnumerable<Film> allFilms { get; set; }

        public string currCategory { get; set; }
    }
}
