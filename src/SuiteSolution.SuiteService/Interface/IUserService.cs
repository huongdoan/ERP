﻿using SuiteSolution.Service.EF;
using SuiteSolution.Service.Entities;


namespace SuiteSolution.Service.Interface
{
    public interface IUserService : IGenericRepository<User>
    {
        User RegisterUser(User user, out TransactionalInformation transaction);
    }
}
