namespace ComputerFactory.Data.Repositories
{
    using System.Linq;

    public interface IRepository<T>
    {
        void Create(T entity);

        void Delete(string id);

        T GetById(string id);

        IQueryable<T> GetAll();
    }
}