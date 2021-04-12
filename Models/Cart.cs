using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Team4NetCoreCAProject.Models
{
    public class Cart
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
    }
}
