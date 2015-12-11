using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

using Microsoft.AspNet.Http.Authentication;
using System.Security.Claims;
using SuiteSolution.Service.Interface;
using SuiteSolution.Service.Entities;

namespace SuiteSolution.Web.API
{
    [Route("api/[controller]")]
    public class MainController : Controller
    {

        [FromServices]
        public IApplicationDataService ApplicationDataService { get; set; }

        private AuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Authentication;
            }
        }


        /// <summary>
        /// Initialize Application
        /// </summary>
        /// <returns></returns>
        [Route("AuthenicateUser")]
        [HttpGet]
        public TransactionalInformation AuthenicateUser(string route)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            transaction.IsAuthenicated = User.Identity.IsAuthenticated;
            return transaction;

        }

        [Route("Logout")]
        [HttpGet]
        public TransactionalInformation Logout()
        {
            TransactionalInformation transaction = new TransactionalInformation();
            transaction.IsAuthenicated = false;
            AuthenticationManager.SignOutAsync("Cookies");
            return transaction;

        }

        // POST api/values
        /// <summary>
        /// Initialize Application
        /// </summary>
        /// <returns></returns>
        [Route("InitializeApplication")]
        [HttpGet]
        public ApplicationApiModel InitializeApplication()
        {
            ApplicationApiModel applicationWebApiModel = new ApplicationApiModel();
            TransactionalInformation transaction = new TransactionalInformation();

            List<ApplicationMenu> menuItems = ApplicationDataService.GetMenuItems(User.Identity.IsAuthenticated, out transaction);

            if (transaction.ReturnStatus == false)
            {
                applicationWebApiModel.ReturnMessage = transaction.ReturnMessage;
                applicationWebApiModel.ReturnStatus = transaction.ReturnStatus;
                applicationWebApiModel.HttpStatusCode = "400";
                return applicationWebApiModel;
            }
            applicationWebApiModel.ReturnMessage.Add("Application has been initialized.");
            applicationWebApiModel.ReturnStatus = transaction.ReturnStatus;
            applicationWebApiModel.MenuItems = menuItems;
            applicationWebApiModel.IsAuthenicated = User.Identity.IsAuthenticated;
            return applicationWebApiModel;

        }

        
        [Route("Login")]
        [HttpPost]
        public string Login()
        {
            AuthenticationManager.SignOutAsync("Cookies");

            // var identity = await CustomUserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            var claims = new List<Claim>
            {
                new Claim("sub", "username"),
                new Claim("name", "bob"),
                new Claim("email", "bob@smith.com")
            };
            var id = new ClaimsIdentity(claims, "local", "name", "role");

            AuthenticationManager.SignInAsync("Cookies", new ClaimsPrincipal(id));//http://leastprivilege.com/2015/07/21/the-state-of-security-in-asp-net-5-and-mvc-6-claims-authentication/
            return "OK";
        }


    }
}
