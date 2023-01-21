using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCORE6.CodeFirst.DAL
{
    public class AppDbContext : DbContext
    {
        //BasePerson eklenirse tek bir tabloda 2sini birleştirir.
        //public DbSet<BasePerson> People { get; set; }
        //public DbSet<Manager> Managers { get; set; }
        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<ProductFeature> ProductFeatures { get; set; }
        //public DbSet<ProductFull> ProductFulls { get; set; }



        

        public AppDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MATEBOOK-SEDAT\\SQLEXPRESS;initial Catalog=EFCORE6CodeFirstDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().ToTable("ProductTb", "products");
            //modelBuilder.Entity<Product>().HasIndex(x => x.Name).IncludeProperties(x => x.Price);
        }
    }
}
