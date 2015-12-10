
using Microsoft.Data.Entity;
using SuiteSolution.Service.Entities;

namespace SuiteSolution.Service.EF
{
    public class SuiteDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
