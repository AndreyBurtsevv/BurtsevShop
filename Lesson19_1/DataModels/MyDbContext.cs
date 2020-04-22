using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.DataModels
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
           Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ModelData>().HasData(
                new ModelData { Id = 3, Name = "G30", BrandDataId = 3}); ;
                           
            modelBuilder.Entity<BrandData>().HasData(
                new BrandData {Id = 3, Name = "Cenon", Description = "For photos" });

            modelBuilder.Entity<OrderData>();

            modelBuilder.Entity<LogData>();

            modelBuilder.Entity<BasketData>();

        }
       
        public DbSet<BrandData> BrandData { get; set; }

        public DbSet<ModelData> ModelData { get; set; }

        public DbSet<LogData> LogData { get; set; }

        public DbSet<BasketData> BasketData { get; set; }

        public DbSet<OrderData> OrderData { get; set; }
    }
}