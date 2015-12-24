

using System;
using SuiteSolution.Service.EF;
using SuiteSolution.Service.Entities;
using SuiteSolution.Service.Interface;
using SuiteSolution.Service.BusinessRules;
using System.Collections.Generic;

namespace SuiteSolution.Service.Implement
{
    public class UserService : GenericRepository<SuiteDBContext, User>, IUserService
    {
        
        AccountsBusinessRules AccountsBusinessRules { get; set; }

        //public UserService(SuiteDBContext db, AccountsBusinessRules accountsBusinessRules) :base(db)
        //{
        //    AccountsBusinessRules = accountsBusinessRules;
        //}

        public UserService(SuiteDBContext db) : base(db)
        {
            AccountsBusinessRules = new AccountsBusinessRules(this);
        }

        public User RegisterUser(User user, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            try
            {
                
                user.FirstName = Utilities.UppercaseFirstLetter(user.FirstName.Trim());
                user.LastName = Utilities.UppercaseFirstLetter(user.LastName.Trim());
                user.Password = user.Password.Trim();
                user.UserName = user.UserName.Trim();

                AccountsBusinessRules.ValidateUser(user);
                AccountsBusinessRules.ValidatePassword(user.Password, user.PasswordConfirm);

                if (AccountsBusinessRules.ValidationStatus == true)
                {
                    //accountsDataService.RegisterUser(user);
                    Add(user);
                    Save();
                    transaction.ReturnStatus = true;
                    transaction.ReturnMessage.Add("User registered successfully.");
                }
                else
                {
                    transaction.ReturnStatus = AccountsBusinessRules.ValidationStatus;
                    transaction.ReturnMessage = AccountsBusinessRules.ValidationMessage;
                    transaction.ValidationErrors = AccountsBusinessRules.ValidationErrors;
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

            return user;

        }
    }
}
