using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.IO;

namespace DataAccess.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (optionsBuilder.IsConfigured)
        //    {
        //        base.OnConfiguring(optionsBuilder);
        //        return;
        //    }

        //    optionsBuilder.UseSqlServer("Server=DESKTOP-MNGD11O\\SQLEXPRESS;Database=test;Trusted_Connection=True;MultipleActiveResultSets=true");

        //    base.OnConfiguring(optionsBuilder);
        //}

        public DbSet<Company> Companies { get; set; }

        public DbSet<Genere> Generes { get; set; }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasMany(game => game.Generes).WithMany(x=>x.Games);
            modelBuilder.Entity<Game>().HasOne(game => game.Company);
        }
    }
}
