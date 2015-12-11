using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using SuiteSolution.Service.Interface;
using SuiteSolution.Service.Entities;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SuiteSolution.Web.API
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        
        IUserService UserService { get; set; }

        IApplicationDataService ApplicationDataService { get; set; }

        public UserController(IApplicationDataService applicationDataService, IUserService userService)
        {
            ApplicationDataService = applicationDataService;
            UserService = userService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
           var users =   UserService.GetAll().ToList();
            return users;
          
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
