using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuiteSolution.Service.Entities
{
    public class Product : Entity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string UnitOfMeasure { get; set; }
        public byte[] ThumbNailPhoto { get; set; }

        public string FileName { get; set; }
        public Guid ProductType { get; set; }

        public string Description { get; set; }

    }
}
