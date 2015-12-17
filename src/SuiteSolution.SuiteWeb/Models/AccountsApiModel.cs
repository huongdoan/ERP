using SuiteSolution.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuiteSolution.Web.Models
{
    public class AccountsApiModel
    {
        public List<ApplicationMenu> MenuItems;
        public User User;

        public AccountsApiModel()
        {
            User = new User();
            MenuItems = new List<ApplicationMenu>();
        }

       
    }
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }

    public class LoginUserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
