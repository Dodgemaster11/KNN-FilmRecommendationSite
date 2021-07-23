using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopProj.Models
{
    public class Film
    {
        public int Id { set; get; }

        public string film_name { set; get; }

        public string genre_name { set; get; }

        public string prod_year { set; get; }
        public ushort price { set; get; }

        public string trailer { set; get; }

        public string shortDesc { set; get; }

        public string longDesc { set; get; }

        public string poster { set; get; }

        public string film_time { set; get; }

        public List<Genre> genre { set; get; } = new List<Genre>();

        public List<Users> Users { get; set; } = new List<Users>();
        public List<Marks> Marks { get; set; } = new List<Marks>();


    }
}
