

using System;
using SuiteSolution.Service.EF;
using SuiteSolution.Service.Entities;
using SuiteSolution.Service.Interface;
using SuiteSolution.Service.BusinessRules;

namespace SuiteSolution.Service.Implement
{
    public class UserService : GenericRepository<SuiteDBContext, User>, IUserService
    {
        
        AccountsBusinessRules AccountsBusinessRules { get; set; }

        public UserService(SuiteDBContext db, AccountsBusinessRules accountsBusinessRules) :base(db)
        {
            AccountsBusinessRules = accountsBusinessRules;
        }

        public void RegisterUser(User user, out TransactionalInformation transaction)
        {
            user.FirstName = Utilities.UppercaseFirstLetter(user.FirstName.Trim());
            user.LastName = Utilities.UppercaseFirstLetter(user.LastName.Trim());
            user.Password = user.Password.Trim();
            user.UserName = user.UserName.Trim();

            AccountsBusinessRules.ValidateUser(user, accountsDataService);
            AccountsBusinessRules.ValidatePassword(password, passwordConfirmation);

            if (AccountsBusinessRules.ValidationStatus == true)
            {

            }
    }
}
