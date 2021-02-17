using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{   
    //Generic constraint : genel kısıt, T türünü sınırlandırmak istersek kullanıyoruz. => where T:class
    //class : referans tip demek,class olabilir demek değildir.
    //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    //new() : new'lenebilir olmalı
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //expression: tüm datayı getirmek yerine filtre ile getirebilmemizi sağlıyor.
        //expression yapısıyla birlikte category'ye göre,rengine göre getir diye artık ayrı ayrı metodlar yazman gerekmeyecek.
        //filitrelemeden datayı getirebiilmesi için null verdik.
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        //filitrelemek zorunlu
        T Get(Expression<Func<T,bool>>filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        //expression'ı ekledikten sonra bu koda ihtiyacımız kalmadı.
        //List<T> GetAllByCategory(int categoryId);
    }
}
