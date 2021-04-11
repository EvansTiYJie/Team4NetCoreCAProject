using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Team4NetCoreCAProject.Models
{
    public class Session
    {
        [Required]
        [MaxLength(36)]
        public string Id { get; set; }

        [Required]
        public long TimeStamp { get; set; } //?

        [Required]
        [MaxLength]
        public string UserId{ get; set; }

        public virtual User User { get; set; }

    }
}
