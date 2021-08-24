using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.DAL.Models;

namespace WebService.DAL.Interfaces
{
    public interface IRepository
    {
        IEnumerable<User> GetAll();
        User Get(int id);
        void Create(User item);
        void Update(User item);
        void Delete(User id);
    }
}
