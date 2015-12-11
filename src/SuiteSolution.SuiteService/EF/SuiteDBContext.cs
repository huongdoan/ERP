
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using SuiteSolution.Service.Entities;
using System;

namespace SuiteSolution.Service.EF
{
    public class SuiteDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        //public SuiteDBContext()
        //{ }

        //public SuiteDBContext(DbContextOptions options)
        //: base(options)
        // { }

        //public SuiteDBContext(DbContextOptions options)
        //: base(options)
        //{ }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                var entity = (Entity) entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = DateTime.Now;
                    entity.UpdatedDate = DateTime.Now;
                    
                }
                else if (entry.State == EntityState.Modified)
                {
                    entity.UpdatedDate = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}
