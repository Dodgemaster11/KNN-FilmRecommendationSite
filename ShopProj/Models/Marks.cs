using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopProj.Models
{
    public class Marks
    {
      
        public int FilmId { set; get; }
        public Film Film { get; set; }



        public int UsersId { set; get; }

        public Users Users { get; set; }

        public int Mark { get; set; }

       
    }
}
