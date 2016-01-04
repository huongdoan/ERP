using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using SuiteSolution.Service.Interface;
using SuiteSolution.Service.Entities;
using SuiteSolution.Service.Entities.SearchResult;
using SuiteSolution.Web.Models;
using System.Net;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SuiteSolution.Web.API
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        
        public IProductService ProductService { get; set; }


        public ProductController(IProductService productService)
        {
            ProductService = productService;
        }
        // GET: api/values
        [HttpGet]
        public PagedList<Product> Get(ProductCriteria criteria)
        {

            var rs =  ProductService.Search(criteria);
            return (PagedList<Product>) rs;
        }

        [Route("CreateProduct")]
        [HttpPost]
        public ProductsApiModel CreateProduct([FromBody]Product value)
        {
            ProductsApiModel productsWebApiModel = new ProductsApiModel();
            TransactionalInformation transaction = new TransactionalInformation();

            var product = ProductService.CreateProduct(value,out transaction);

            if (transaction.ReturnStatus == false)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            }

            productsWebApiModel.ReturnMessage = transaction.ReturnMessage;
            productsWebApiModel.ReturnStatus = transaction.ReturnStatus;
            productsWebApiModel.ValidationErrors = transaction.ValidationErrors;
            productsWebApiModel.Product = product;

            return productsWebApiModel;
        }



        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
