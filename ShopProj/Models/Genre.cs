using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopProj.Models
{
    public class Genre
    {
        public int Id { set; get; }

        public string genreName { set; get; }

        public List<Film> films { set; get; } = new List<Film>();

    }
}
