using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public IEnumerable<User> GetAll()
        {
            return _context.Users.AsNoTracking().Include(x => x.Details);
        }
        public User Get(int id)
        {
            return _context.Users.Find(id);
        }
        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
