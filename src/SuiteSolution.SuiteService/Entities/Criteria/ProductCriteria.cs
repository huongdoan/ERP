using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuiteSolution.Service.Entities
{
    public class ProductCriteria : DataGridPagingInformation
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
