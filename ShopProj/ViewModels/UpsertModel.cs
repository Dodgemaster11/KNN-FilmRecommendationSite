using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopProj.ViewModels
{
    public class UpsertModel 
    {
        public int Id { set; get; }

        [Required]
        public string film_name { set; get; }

        [Required]
        public string prod_year { set; get; }

        [Required]
        public string shortDesc { set; get; }

        [Required]
        public string longDesc { set; get; }

        [Required]
        public string poster { set; get; }

        [Required]
        public string trailer { set; get; }

        [Required]
        public string film_time { set; get; }
      

    }
}