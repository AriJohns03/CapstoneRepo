using System.Collections.Generic;
using Capstone1.Models;
using Microsoft.EntityFrameworkCore;

namespace Capstone1.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
