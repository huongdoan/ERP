using SuiteSolution.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuiteSolution.Service.Interface
{
    public interface IApplicationDataService : IDisposable
    {
        List<ApplicationMenu> GetMenuItems(Boolean isAuthenicated, out TransactionalInformation transaction);
    }
}
