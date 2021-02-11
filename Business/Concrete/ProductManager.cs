using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        //bağımlı yapmamak için IProductDal verdik.
        //artık InMemory de olabilir, Entity Framework de olabilir yarın başka birşey de olabilir.Kolayca ekleyebiliriz.
        public ProductManager(IProductDal productDal)
        {
            this._productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //iş kodları
            //yetkisi var mı?

            return _productDal.GetAll();
        }
    }
}
//dikkat business da ınMemory,entityFramework hiç bir şey yok.
//Business'ın bildiği tek şey IProductDal
