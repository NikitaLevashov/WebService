using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class Details
    {
        [Range(0,100)]
        [Required(ErrorMessage = "Missing age value")]
        public int Age { get; set; }

        [StringLength(50)]
        public string Adress { get; set; }
    }
}
