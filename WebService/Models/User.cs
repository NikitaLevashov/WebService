using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Details Details { get; set; }
    }
}
