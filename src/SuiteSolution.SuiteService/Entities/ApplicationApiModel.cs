using System.Collections.Generic;

namespace SuiteSolution.Service.Entities
{
    public class ApplicationApiModel : TransactionalInformation
    {
        public List<ApplicationMenu> MenuItems;

        public ApplicationApiModel()
        {
            MenuItems = new List<ApplicationMenu>();
        }
    }
}
