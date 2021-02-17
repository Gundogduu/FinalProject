using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        //Id yi int vermedik çünkü nortwind deki Customer tablomuzda string verilmiş.
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
    }
}
