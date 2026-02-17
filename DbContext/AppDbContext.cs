using Microsoft.EntityFrameworkCore;
using Core.DAL.Orders;
using System.Collections.Generic;
using System.Reflection.Emit;
using Core.DAL.Branches;
using Core.DAL.Staff;
using Core.DAL.Stocks;

namespace Data.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<CoffeeChain> CoffeeChains { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BranchProduct> BranchProducts { get; set; }
        public DbSet<Promotion> Promotions { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Подтягиваем все конфигурации из папки Configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
