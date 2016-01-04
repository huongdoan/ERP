using SuiteSolution.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuiteSolution.Web.Models
{
    public class ProductsApiModel : TransactionalInformation
    {
        public List<Product> Products;
        public Product Product;

        public ProductsApiModel()
        {
            Product = new Product();
            Products = new List<Product>();
        }
    }
}
