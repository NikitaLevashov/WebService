using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.BLL.ModelsBLL
{
    public class UserBLL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DetailsBLL Details { get; set; }
    }
}
