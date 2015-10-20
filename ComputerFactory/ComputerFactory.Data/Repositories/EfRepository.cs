namespace ComputerFactory.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IComputerFactorySqlDbContext data;
        private readonly IDbSet<TEntity> set;

        public EfRepository()
            : this(new ComputerFactorySqlDbContext())
        {

        }

        public EfRepository(IComputerFactorySqlDbContext data)
        {
            this.data = data;
            this.set = data.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            this.UpdateState(entity, EntityState.Added);
        }

        public void Delete(TEntity entity)
        {
            this.set.Remove(entity);
        }

        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return this.set.Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.set;
        }

        public TEntity GetById(int id)
        {
            return this.set.Find(id);
        }

        public void SaveChanges() {
            this.data.SaveChanges();
        }

        private void UpdateState(TEntity entity, EntityState state)
        {
            var trackedEntry = this.data.Entry(entity);
            trackedEntry.State = state;
        }
    }
}
