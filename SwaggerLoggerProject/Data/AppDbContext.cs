using Microsoft.EntityFrameworkCore;
using SwaggerLoggerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerLoggerProject.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<MenuItem> MenuItems { set; get; }
        // public DbSet<Reservation> Reservations { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySql(@"server=localhost;user=root;password=;database=swaggerdb;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
