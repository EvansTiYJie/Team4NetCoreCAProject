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

        //long is a data type used inprograming that can stroe a single 64 bit signed integer
        [Required]
        public long Timestamp { get; set; }

        [Required]
        [MaxLength(36)]
        public string UserId { get; set; }
        public virtual User User { get; set; }

    }

   
}
