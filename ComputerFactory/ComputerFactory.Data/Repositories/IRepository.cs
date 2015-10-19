namespace ComputerFactory.Data.Repositories
{
    using System.Linq;

    public interface IRepository<T>
    {
        void Add(T entity);

        void Delete(T entity);

        T GetById(int id);

        IQueryable<T> GetAll();
    }
}