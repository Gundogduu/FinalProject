﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal: IEntityRepository<Product>
    {
        //buradaki ortak özellikleri IEntityRepository'den çekiyoruz artık.
    }
}
