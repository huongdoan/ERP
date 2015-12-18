using SuiteSolution.Service.Entities;
using SuiteSolution.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuiteSolution.Service.BusinessRules
{
    public class AccountsBusinessRules : ValidationRules
    {
        IUserService UserService { get; set; }
        public AccountsBusinessRules(IUserService userService)
        {
            UserService = userService;
        }
        /// <summary>
        /// Validate User
        /// </summary>
        /// <param name="user"></param>
        /// <param name="dataService"></param>
        public void ValidateUser(User user )
        {
            InitializeValidationRules(user);

            ValidateRequired("FirstName", "First Name");
            ValidateRequired("LastName", "Last Name");
            ValidateRequired("UserName", "User Name");
            ValidateRequired("Password", "Password");
            ValidateRequired("EmailAddress", "Email Address");
            ValidateEmailAddress("EmailAddress", "Email Address");
        }

        /// <summary>
        /// Validate Unique User Name
        /// </summary>
        /// <param name="userName"></param>
        public void ValidateUniqueUserName(string userName)
        {

            var users = UserService.FindBy(u => u.UserName == userName);
            if (users.Count()>0)
            {
                AddValidationError("UserName", "User Name " + userName + " already exists.");
            }

        }

    }
}
