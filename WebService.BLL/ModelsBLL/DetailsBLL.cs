using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.BLL.ModelsBLL
{
    public class DetailsBLL
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Adress { get; set; }
        public int UserId { get; set; }
        public UserBLL UserBLL { get; set; }
    }
}
