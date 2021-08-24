using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.DAL.Models;

namespace WebService.DAL.EFCore
{
    public class UserContext : DbContext
    {
        public DbSet<UserDAL> Users { get; set; }
        public DbSet<DetailsDAL> Details { get; set; }
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
