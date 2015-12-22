using SuiteSolution.Service.Entities;
using SuiteSolution.Service.Entities.SearchResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuiteSolution.Service.Interface
{
    public interface IProductService
    {
        IPagedList<Product> Search(ProductCriteria criteria);
    }
}
