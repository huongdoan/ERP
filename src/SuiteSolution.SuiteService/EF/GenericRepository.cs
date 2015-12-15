
using Microsoft.Data.Entity;
using System;
using System.Linq;

namespace SuiteSolution.Service.EF
{
    public abstract class GenericRepository<C, T> :
     IGenericRepository<T> where T : class where C : DbContext, new()
    {
        
        public C Context { get; set; }

        public   GenericRepository(C Cxx)
        {

            Context = Cxx;
        }


        public virtual IQueryable<T> GetAll()
        {

            IQueryable<T> query = Context.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = Context.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            Context.SaveChanges();
        }
    }
}
