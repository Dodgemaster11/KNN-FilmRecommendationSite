using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopProj.ViewModels
{
    public class MarkViewModel
    {
        [Required]
        public int FilmId { get; set; }

        [Required]
        [Range(1,10)]
        public int Mark { get; set; } 
    }
}
