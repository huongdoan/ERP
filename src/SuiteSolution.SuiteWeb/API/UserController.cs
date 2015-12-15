using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using SuiteSolution.Service.Interface;
using SuiteSolution.Service.Entities;
using SuiteSolution.Service.EF;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SuiteSolution.Web.API
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        
        IUserService UserService { get; set; }

        IApplicationDataService ApplicationDataService { get; set; }

        SuiteDBContext Context { get; set; }

        public UserController(IApplicationDataService applicationDataService, IUserService userService, SuiteDBContext context)
        {
            ApplicationDataService = applicationDataService;
            UserService = userService;
            //Context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
            //return Context.Users.ToList();
            return  UserService.GetAll().ToList();
            // return users;

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
