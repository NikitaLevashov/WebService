using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class User
    {
        [StringLength(15)]
        [Required(ErrorMessage = "Missing user name value")]
        public string Name { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Missing user surname value")]
        public string Surname { get; set; }
        public Details Details { get; set; }
    }
}
