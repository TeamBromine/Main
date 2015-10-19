namespace ComputerFactory.Data
{
    using MongoDB.Driver;

    public interface IComputerFactoryMongoDbContext
    {
        MongoDatabase Database { get; }
    }
}
