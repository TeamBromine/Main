namespace ComputerFactory.Data.Repositories
{
    using System.Linq;

    using ComputerFactory.Data.Models;

    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using MongoDB.Driver.Linq;

    public abstract class MongoRepository<T> : IRepository<T> where T : IMongoEntity
    {
        protected MongoCollection<T> table;

        protected MongoRepository(MongoDatabase db)
        {
            this.table = db.GetCollection<T>(typeof(T).Name.ToLower() + "s");
        }

        public virtual void Create(T entity)
        {
            this.table.Save(entity);
        }

        public virtual void Delete(string id)
        {
            this.table.Remove(Query<T>.EQ(x => x.Id, new ObjectId(id)), RemoveFlags.None, WriteConcern.Acknowledged);
        }

        public virtual T GetById(string id)
        {
            var entityQuery = Query<T>.EQ(x => x.Id, new ObjectId(id));
            return this.table.FindOne(entityQuery);
        }

        public IQueryable<T> GetAll()
        {
            return table.AsQueryable<T>();
        }
    }
}