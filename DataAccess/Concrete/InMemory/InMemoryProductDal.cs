﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //fake veritabanımız
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId= 1, CategoryId= 1, ProductName= "Bardak", UnitPrice=15, UnitInStock= 15},
                new Product{ProductId= 2, CategoryId= 1, ProductName= "Kamera", UnitPrice=500, UnitInStock= 3},
                new Product{ProductId= 3, CategoryId= 2, ProductName= "Telefon", UnitPrice=1500, UnitInStock= 2},
                new Product{ProductId= 4, CategoryId= 2, ProductName= "Klavye", UnitPrice=150, UnitInStock= 65},
                new Product{ProductId= 5, CategoryId= 2, ProductName= "Fare", UnitPrice=85, UnitInStock= 1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query/dile gömülü sorgulama
            //linq ile liste bazlı yapıları aynen SQL gibi filtreleyebiliyoruz.
            //Lambda =>

            //LINQ olmadan
            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if(product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
            //_product.Remove(productToDelete);

            //LINQ ile
            //SingleOrDefault: tek tek dolaşmaya yarıyor.Genelde Id olan aramalarada kullanırız.
            //bunun yerine FirstOrDefault olur,First de olur.
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            //listelerde tek basına remove kullanılamaz.
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }
                                              //camel case yazıyoruz
        public List<Product> GetAllByCategory(int categoryId)
        {
            //where koşulu, içindeki şarta uyan bütün elemanları yeni bir liste haline getirir ve onu döndürür.
            //yani, sql deki where koşulunun yaptığını yapıyor.
            //&& ekleyip istediğimiz kadar koşul ekleyebiliriz.
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            //temel mantık bu, bunu gerçek hayat projelerinde bizim için bunu çok güzel bir şekilde yapan
            //Entity Framework,NIBR NET gibi teknolojileri kullanırız.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;
        }
    }
}
