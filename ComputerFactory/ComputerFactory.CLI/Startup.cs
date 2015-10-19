namespace ComputerFactory.CLI
{
    using System;
    using System.Linq;
    using System.Data.Entity;
    using System.IO;

    using ComputerFactory.Data;
    using ComputerFactory.Data.Importers;
    using ComputerFactory.Data.Movers;
    using ComputerFactory.Data.Migrations;
    using ComputerFactory.Data.ExcelLoader;
    using Data.LoadDataFromXml;

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

            // Load from xml file into mongoDb and mssql
            XmlDataLoader.Load();

            // Unzip and load excel reports
            string currentDirectory = Directory.GetCurrentDirectory();
            string dataFolderDirectory = currentDirectory + @"..\..\..\..\Data";
            string computersBuiltReportPath = dataFolderDirectory + @"\Computers-Built-Reports";

            ReportsUnzipper.Unzip(dataFolderDirectory + @"\Computers-Built-Reports.zip", dataFolderDirectory);

            var excelReportsTraverser = new ExcelReportsTraverser(computersBuiltReportPath);
            excelReportsTraverser.Traverse();

            
        }
    }
}