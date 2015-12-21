using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using SuiteSolution.Service.Interface;
using SuiteSolution.Service.Entities;
using SuiteSolution.Service.EF;
using SuiteSolution.Web.Models;
using AutoMapper;
using Microsoft.AspNet.Http.Authentication;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SuiteSolution.Web.API
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        
        IUserService UserService { get; set; }

        IApplicationDataService ApplicationDataService { get; set; }

        private AuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Authentication;
            }
        }


        public UserController(IApplicationDataService applicationDataService, IUserService userService)
        {
            ApplicationDataService = applicationDataService;
            UserService = userService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return  UserService.GetAll().ToList();
            // return users;

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Register User
        /// </summary>
        /// <param name="request"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("RegisterUser")]
        [HttpPost]
        public AccountsApiModel RegisterUser([FromBody] UserDTO userDTO)
        {
            AccountsApiModel accountsWebApiModel = new AccountsApiModel();
            TransactionalInformation transaction = new TransactionalInformation();

            Mapper.CreateMap<UserDTO,User>();
            User user = Mapper.Map<User>(userDTO);

            UserService.RegisterUser(user, out transaction);

            if (transaction.ReturnStatus == false)
            {
                accountsWebApiModel.ReturnMessage = transaction.ReturnMessage;
                accountsWebApiModel.ReturnStatus = transaction.ReturnStatus;
                accountsWebApiModel.ValidationErrors = transaction.ValidationErrors;
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return accountsWebApiModel;
            }

            List<ApplicationMenu> menuItems = ApplicationDataService.GetMenuItems(true, out transaction);

            if (transaction.ReturnStatus == false)
            {
                accountsWebApiModel.ReturnMessage = transaction.ReturnMessage;
                accountsWebApiModel.ReturnStatus = transaction.ReturnStatus;
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return accountsWebApiModel;
            }

            accountsWebApiModel.IsAuthenicated = true;
            accountsWebApiModel.ReturnStatus = transaction.ReturnStatus;
            accountsWebApiModel.ReturnMessage.Add("Register User successful.");
            accountsWebApiModel.MenuItems = menuItems;
            accountsWebApiModel.User = user;

            var claims = new List<Claim>
            {
                new Claim("userid", user.Id.ToString()),
            };
            var id = new ClaimsIdentity(claims, "userid");
            AuthenticationManager.SignInAsync("Cookies", new ClaimsPrincipal(id));
            return accountsWebApiModel;


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
