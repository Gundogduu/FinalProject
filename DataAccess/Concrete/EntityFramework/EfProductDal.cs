using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet : Başkalarının yazdığı ortak kodların bulunduğu ve yönetildiği bir ortam. 
    //NuGet ile dataaccess içine entityframeworkcore.sqlserver paketini ekledik.
    //biz artık dataaccess içerisinde entityframework kodu yazabiliriz.
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //SEARCH!: IDispossible pattern implementation of c#
            //using içerisine yazdığımız nesneler using bitince bellekten temizleniyor.Bu sayede daha performanslı ürün elde etmiş oluyoruz.
            //tab tab
            using (NorthwindContext context = new NorthwindContext())
            {
                //Entry: framework'e ait metot
                //verikaynağıyla eşleştirme
                var addedEntity = context.Entry(entity);
                //State: durum
                //eklenecek nesne
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);

            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                //arka planda select * from Product döndürüyor.Filtre null ise veritabanındaki Product'ın tüm datasını listele demek.
                //Ternary operatörü kullandık.
                return filter == null
                    ? context.Set<Product>().ToList()
                    : context.Set<Product>().Where(filter).ToList();

            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
//bu kodlar diğer nesnelerde de standart kodlardır.Standart olduğunda Generic Base haline getireceğiz ve ortak olarak çekeceğiz. 
