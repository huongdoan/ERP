using System;

namespace SuiteSolution.Service.Entities
{
    public class ApplicationMenu
    {
        public Guid MenuId { get; set; }
        public string Description { get; set; }
        public string Route { get; set; }
        public string Module { get; set; }
        public int MenuOrder { get; set; }
        public Boolean RequiresAuthenication { get; set; }
    }
}
