using SuiteSolution.Service.Implement;
using SuiteSolution.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuiteSolution.Service.Entities;

namespace SuiteSolution.Service.BusinessRules
{
    public class ProductBusinessRules : ValidationRules
    {
        IProductService productService { get; set; }
        public ProductBusinessRules(IProductService service)
        {
            productService = service;
        }

        internal void ValidateProduct(Product value)
        {

            InitializeValidationRules(value);
            ValidateRequired("Code", "Code");
            ValidateRequired("Name", "Name");
            ValidateRequired("UnitOfMeasure", "Unit Of Measure");
            ValidateDecimalIsNotZero("UnitPrice", "Unit Price");
            ValidateDecimalGreaterThanZero("UnitPrice", "Unit Price");

            if(!string.IsNullOrEmpty(value.Code))
            ValidateUniqueProductCode(value);
        }

        /// <summary>
        /// Validate Unique Product Code
        /// </summary>
        /// <param name="productCode"></param>
        public void ValidateUniqueProductCode(Product product)
        {
            Boolean valid = productService.ValidateDuplicateProduct(product);
            if (valid == false)
            {
                AddValidationError("ProductCode", "Product Code " + product.Code + " already exists.");
            }

        }
    }
}
