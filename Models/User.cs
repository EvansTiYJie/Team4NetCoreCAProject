using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Team4NetCoreCAProject.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string Username { get; set; }
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
