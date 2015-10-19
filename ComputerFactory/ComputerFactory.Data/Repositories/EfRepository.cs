namespace ComputerFactory.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class EfRepository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> dbSet;

        public EfRepository(DbContext dataContext)
        {
            this.dbSet = dataContext.Set<T>();
        }

        public void Add(T entity)
        {
            this.dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            this.dbSet.Remove(entity);
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return this.dbSet.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return this.dbSet.AsQueryable();
        }

        public T GetById(int id)
        {
            return this.dbSet.Find(id);
        }
    }
}
