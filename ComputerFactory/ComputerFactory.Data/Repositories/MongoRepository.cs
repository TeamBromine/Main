namespace ComputerFactory.Data.Repositories
{
    using System.Linq;

    using ComputerFactory.Models.MongoDb;

    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using MongoDB.Driver.Linq;

    public class MongoRepository<T> : IRepository<T> where T : IMongoEntity
    {
        protected MongoCollection<T> table;

        public MongoRepository(IComputerFactoryMongoDbContext dataContext)
        {
            this.table = dataContext.Database.GetCollection<T>(typeof(T).Name.ToLower() + "s");
        }

        public virtual void Add(T entity)
        {
            this.table.Save(entity);
        }

        public virtual void Delete(T entity)
        {
            this.table.Remove(Query<T>.EQ(x => x.Id, new ObjectId(entity.Id.ToString())), RemoveFlags.None, WriteConcern.Acknowledged);
        }

        public virtual T GetById(int id)
        {
            var entityQuery = Query<T>.EQ(x => x.Id, new ObjectId(id.ToString()));
            return this.table.FindOne(entityQuery);
        }

        public IQueryable<T> GetAll()
        {
            return table.AsQueryable<T>();
        }
    }
}