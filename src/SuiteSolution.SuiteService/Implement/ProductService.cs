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

        public Product CreateProduct(Product value, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            try
            {
                ProductBusinessRules.ValidateProduct(value);
               
                if (ProductBusinessRules.ValidationStatus == true)
                {
                    Add(value);
                    transaction.ReturnStatus = true;
                    transaction.ReturnMessage.Add("Product successfully created.");
                }
                else
                {
                    transaction.ReturnStatus = ProductBusinessRules.ValidationStatus;
                    transaction.ReturnMessage = ProductBusinessRules.ValidationMessage;
                    transaction.ValidationErrors = ProductBusinessRules.ValidationErrors;
                }
            }
            catch (Exception ex)
            {
                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
            }
            finally
            {
            }
            return value;

        }

        public bool ValidateDuplicateProduct(Product product)
        {
            
            if (product.Id == Guid.Empty)
            {
                return !Context.Products.Any(p => p.Code == product.Code);
            }
            else
            {
                return !Context.Products.Any(p => p.Code == product.Code&&p.Id == product.Id);
            }
        }

       
    }
}
