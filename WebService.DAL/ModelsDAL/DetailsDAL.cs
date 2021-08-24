using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.DAL.Models
{
    public class DetailsDAL
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Adress { get; set; }
        public int UserId { get; set; }
        public UserDAL User { get; set; }
    }
}
