using Microsoft.EntityFrameworkCore;
using MVP.Date.Models;

namespace MVP.Date
{
    public class AppDB : DbContext
    {
        public AppDB(DbContextOptions<AppDB> options) : base(options) { }
        
        public DbSet<Title> DBTitle { get; set; }

    }
}
