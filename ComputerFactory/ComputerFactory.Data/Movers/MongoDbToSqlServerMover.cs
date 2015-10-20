namespace ComputerFactory.Data.Movers
{
    using System.Data.Entity;
    using System.Linq;

    using ComputerFactory.Data.Repositories;
    using ComputerFactory.Models.SqlServer;
    using ComputerFactory.Models.MongoDb;

    using SqlVendor = ComputerFactory.Models.SqlServer.Vendor;
    using MongoVendor = ComputerFactory.Models.MongoDb.Vendor;

    public class MongoDbToSqlServerMover : IDataMover
    {
        private DbContext sqlServerContext;
        private IComputerFactoryMongoDbContext mongoContext;

        public MongoDbToSqlServerMover(DbContext efContext, IComputerFactoryMongoDbContext mongoContext)
        {
            this.sqlServerContext = efContext;
            this.mongoContext = mongoContext;
            this.MoveAll();
        }

        public void MoveAll()
        {
            IRepository<SqlVendor> repo = new EfRepository<SqlVendor>();
            repo.Add(new SqlVendor()
            {
                Name = "Corsair"
            });
            repo.SaveChanges();
        }
    }
}
