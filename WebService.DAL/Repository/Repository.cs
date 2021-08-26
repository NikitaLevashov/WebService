using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebService.DAL.EFCore;
using WebService.DAL.Interfaces;
using WebService.DAL.Models;

namespace WebService.DAL.Repository
{
    public class UserRepository : IRepository
    {
        UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        }
        public IEnumerable<UserDAL> GetAll() 
            => _context.Users.AsNoTracking().Include(x => x.Details);
        public UserDAL GetById(int id) => _context.Users.Find(id);
        public void Create(UserDAL user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(UserDAL user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void Update(UserDAL user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.Entry(user.Details).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
