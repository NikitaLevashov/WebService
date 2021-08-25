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
        Task<IQueryable<UserDAL>> GetAllAsync();
        Task<UserDAL> GetAsync(int id);
        Task CreateAsync(UserDAL item);
        Task UpdateAsync(UserDAL item);
        Task DeleteAsync(UserDAL id);
    }
}
