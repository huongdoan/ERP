using SuiteSolution.Service.Implement;
using SuiteSolution.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuiteSolution.Service.BusinessRules
{
    public class ProductBusinessRules : ValidationRules
    {
        IProductService productService { get; set; }
        public ProductBusinessRules(IProductService service)
        {
            productService = service;
        }
    }
}
