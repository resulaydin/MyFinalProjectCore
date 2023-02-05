using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext : DbContext
    {

        // Bu metot projenin hangi veritabanı ile ilişkilendirileceğini gösterir.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Burada kullanılan "Trusted_Connection=true" ifadesi herhangi bir username password olmadan giriş yap

            optionsBuilder.UseSqlServer(@"Server=(localdb)\projectmodels;Database=Northwind;Trusted_Connection=true");

            //base.OnConfiguring(optionsBuilder);
        }


        // Burada 1. alanda  veritabanına " Product " gönder ve bunu DB' deki " Products " tablosu ile eşleştir.
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
