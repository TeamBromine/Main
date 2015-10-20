

namespace ComputerFactory.Data.LoadDataFromXml.DataImporters
{
    using ComputerFactory.Data.LoadDataFromXml.Models;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System.Collections.Generic;

    public class XmlToMongoDbDataImporter : IDataImporter
    {
        private const string DatabaseHost = "mongodb://localhost";
        private const string DatabaseName = "ComputerFactory";

        public void ImportData(IEnumerable<Sale> sales)
        {
            var db = GetDatabase(DatabaseName, DatabaseHost);

            foreach (var sale in sales)
            {
                foreach (var computer in sale.Computers)
                {
                    var computerToAdd = new ComputerFactory.Models.MongoDb.Computer(computer.Model, computer.Price);
                    db.GetCollection<Computer>("Computers").Insert(computerToAdd);
                }

                db.GetCollection<Sale>("Sales").Insert(new ComputerFactory.Models.MongoDb.Sale(sale.Month));
            }
        }

        private MongoDatabase GetDatabase(string name, string fromHost)
        {
            var mongoClient = new MongoClient(fromHost);
            var server = mongoClient.GetServer();
            return server.GetDatabase(name);
        }
    }
}
