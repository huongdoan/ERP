using SuiteSolution.Service.BusinessRules;
using SuiteSolution.Service.EF;
using SuiteSolution.Service.Entities;
using SuiteSolution.Service.Entities.SearchResult;
using SuiteSolution.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuiteSolution.Service.Implement
{
    public class ProductService : GenericRepository<SuiteDBContext, Product>, IProductService
    {

        ProductBusinessRules ProductBusinessRules { get; set; }

        public ProductService(SuiteDBContext db) :base(db)
        {
            ProductBusinessRules = new ProductBusinessRules(this);
        }

        public IPagedList<Product> Search(ProductCriteria criteria)
        {
            var productQuery = GetAll();


            return new PagedList<Product>(productQuery, criteria.CurrentPageNumber, criteria.PageSize);
        }
    }
}
