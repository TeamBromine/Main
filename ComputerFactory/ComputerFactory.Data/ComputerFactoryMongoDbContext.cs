namespace ComputerFactory.Data
{
    using MongoDB.Driver;

    public class ComputerFactoryMongoDbContext : IComputerFactoryMongoDbContext
    {
        private string connectionString;
        private string databaseName;

        public ComputerFactoryMongoDbContext(string connectionString = "mongodb://localhost", string databaseName = "ComputerFactory")
        {
            this.connectionString = connectionString;
            this.databaseName = databaseName;
        }

        public MongoDatabase Database
        {
            get
            {
                var mongoClient = new MongoClient(this.connectionString);
                var mongoServer = mongoClient.GetServer();
                return mongoServer.GetDatabase(this.databaseName);
            }
        }
    }
}
