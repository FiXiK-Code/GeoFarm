using Microsoft.EntityFrameworkCore;
using MVP.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVP.Date
{
    public class AppDB : DbContext
    {
        public AppDB(DbContextOptions<AppDB> options) : base(options)
        {

        }
        
        public DbSet<Staff> DBStaff { get; set; }
       

    }
}
