namespace ComputerFactory.CLI
{
    using System;
    using System.Linq;
    using System.Data.Entity;

    using ComputerFactory.Data;
    using ComputerFactory.Data.Importers;
    using ComputerFactory.Data.Movers;
    using ComputerFactory.Data.Migrations;

    public class Startup
    {
        public static void Main(string[] args)
        {
            DbContext sqlServerDbContext = new ComputerFactorySqlDbContext();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ComputerFactorySqlDbContext, Configuration>());
            IComputerFactoryMongoDbContext mongoDbContext = new ComputerFactoryMongoDbContext();

            IDataImporter mongoImporter = new MongoImporter(mongoDbContext, Console.Out);
            mongoImporter.ImportAll();

            IDataMover mongoToSqlServerMover = new MongoDbToSqlServerMover(sqlServerDbContext, mongoDbContext);
        }
    }
}