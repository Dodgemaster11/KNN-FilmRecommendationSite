using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopProj.Models
{
    public class Users
    {
        public int Id { set; get; }
        
     
        public string user_first_name { set; get; }
        
        
        public string user_patronymic { set; get; }

      
        public string user_last_name { set; get; }

       
        public string user_login { set; get; }

      
        public string user_email { set; get; }

        public string user_password { set; get; }

        public string user_dateOfBirth { set; get; }

        public List<Film> Films { get; set; } = new List<Film>();
        public List<Marks> Marks { get; set; } = new List<Marks>();

        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }

}
