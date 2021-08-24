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
        IEnumerable<UserDAL> GetAll();
        UserDAL Get(int id);
        void Create(UserDAL item);
        void Update(UserDAL item);
        void Delete(UserDAL id);
    }
}
