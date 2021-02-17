using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: Db tabloları ile proje classlarını bağlamak.
    //DbContext: context'imiz. Entityframework ile gelen bir base class'tır.
    public class NorthwindContext :DbContext
    {
        //projemizle ilişkili olan veritabanını belirttiğimiz yer
        //override on  => yazınca bu metot geliyor
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=174.45.2.12");  sql server'ımızın nerede olduğunu anlatır.Normalde böyle Ip ile yaparız.
            //geliştirme ortamında (localdb)\MSSQLLocalDB
            //Database : yazdığımız serverdaki hangi database'i kullanacağımızı yazıyoruz.
            //Trusted_Connection : kullanıcı adı,şifre doğrulaması. Olmadığı için true döndürdük.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");

        }
        //hangi nesnem hangi nesneye karşılık gelecek
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
