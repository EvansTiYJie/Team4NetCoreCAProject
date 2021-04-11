using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Team4NetCoreCAProject.Models
{
    public class User
    {
        [Required]
        [MaxLength(36)]
        public string Id { get; set; }

        [MaxLength(50)]
        public string Username { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }


        public string SessionId { get; set; }
        /*
        public List<string> Likes { get; set; }

        public User()
        {
            Likes = new List<string>();
        }*/
    }
}
