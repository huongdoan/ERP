

using System;
using SuiteSolution.Service.EF;
using SuiteSolution.Service.Entities;
using SuiteSolution.Service.Interface;

namespace SuiteSolution.Service.Implement
{
    public class UserService : GenericRepository<SuiteDBContext, User>, IUserService
    {
        public UserService(SuiteDBContext db):base(db)
        {

        }

        public void RegisterUser(User user, out TransactionalInformation transaction)
        {
        }
    }
}
