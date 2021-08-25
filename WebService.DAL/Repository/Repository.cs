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
        public IEnumerable<UserDAL> GetAll()
        {
            return _context.Users.AsNoTracking().Include(x => x.Details);
        }
        public UserDAL Get(int id)
        {
            return _context.Users.Find(id);
        }
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
            //_context.Details.Attach(user.Details);
            //_context.Entry(user.Details).Property(p => p.Adress).IsModified = true;
            //_context.Entry(user.Details).Property(p => p.Age).IsModified = true;
            _context.Entry(user).State = EntityState.Modified;
            _context.Entry(user.Details).State = EntityState.Modified;
            //_context.Users.Remove(user);
            //_context.SaveChanges();
            //_context.Users.Add(user);
            //_context.Users.Attach(user);
            //_context.Entry(user).Property(p => p.Name).IsModified = true;
            //_context.Entry(user).Property(p => p.Surname).IsModified = true;
            //_context.Entry(user).Property(p => p.Details.Age).IsModified = true;
            //_context.Entry(user).Property(p => p.Details.Adress).IsModified = true;
            _context.SaveChanges();
        }
    }
}
